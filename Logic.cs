using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromaticity
{
    public static class Logic
    {
        public static PictureBox ChromaticPic;
        public static PictureBox BezierPic;
        public static DirectBitmap ChromaticBitmap;
        public static DirectBitmap BezierBitmap;
        public static Graphics gC;
        public static Graphics gB;

        public static double[,] waves;
        public static PointF[] ControlPoints; // 5
        public static PointF[] CurveYLocations;
        public static (Point, Color)[] ChromaticBoundary;

        public static int CurrentPoint = -1;
        public static bool IsPointMove = false;
        public static bool IsColorPoints = false;
        public static int margin = 30;
        public static float k = 0;

        #region Init
        public static void Init()
        {
            ChromaticBoundary = new (Point, Color)[401];
            CurveYLocations = new PointF[401];
            ControlPoints = new PointF[5];
            ControlPoints[0] = new PointF(0f, 0.5f);
            ControlPoints[1] = new PointF(0.25f, 0.5f);
            ControlPoints[2] = new PointF(0.5f, 0.5f);
            ControlPoints[3] = new PointF(0.75f, 0.5f);
            ControlPoints[4] = new PointF(1f, 0.5f);

            //Image j = Image.FromFile("C:/Users/user/Desktop/sem5/GrafikaKomputerowa/Chromaticity/Chromaticity/hziJw.png");
            ChromaticBitmap = new DirectBitmap(ChromaticPic.Width, ChromaticPic.Height);
            BezierBitmap = new DirectBitmap(BezierPic.Width, BezierPic.Height);
            //ChromaticBitmap = new DirectBitmap(ChromaticPic.Width, ChromaticPic.Height);

            gC = Graphics.FromImage(ChromaticBitmap.Bitmap);
            ChromaticPic.Image = ChromaticBitmap.Bitmap;
            //gC = ChromaticPic.CreateGraphics();
            gB = Graphics.FromImage(BezierBitmap.Bitmap);
            BezierPic.Image = BezierBitmap.Bitmap;
            //gB = BezierPic.CreateGraphics();
            ReadFromTXT();

            //gC.Clear(Color.White);
            //Bitmap backgroundBitmap = new(new Bitmap(@"C:\Users\user\Desktop\sem5\GrafikaKomputerowa\Chromaticity\Chromaticity\hziJw.png"),
            //        (int)(0.9 * ChromaticPic.Width - margin),
            //        (int)(0.9 * ChromaticPic.Width - margin));
            //gC.DrawImage(backgroundBitmap, new Point(margin-10, ChromaticPic.Height - backgroundBitmap.Height - margin));

            CalculateChromaticBoundary();
            //DrawChromaticBoundary();
            //DrawAxes();
            DrawC();

            DrawControlPoints();
            DrawBezierCurve();
        }
        public static void ReadFromTXT()
        {
            // TODO
            string filePath = "C:/Users/user/Desktop/sem5/GrafikaKomputerowa/Chromaticity/Chromaticity/color_matching_functions.txt";
            waves = new double[401, 4];
            int index = 0;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split('\t');

                        int wave = int.Parse(values[0]);
                        double X = double.Parse(values[1]);
                        double Y = double.Parse(values[2]);
                        double Z = double.Parse(values[3]);

                        waves[index, 0] = wave;
                        waves[index, 1] = X;
                        waves[index, 2] = Y;
                        waves[index, 3] = Z;

                        k += (float)Y;

                        index++;
                    }
                }
            }
            else
            {
                throw new Exception("TXT file not found");
            }
        }
        public static void CalculateChromaticBoundary()
        {
            for(int i = 0; i<401; i++)
            {
                double X = waves[i, 1];
                double Y = waves[i, 2];
                double Z = waves[i, 3];

                double x, y;
                if (X + Y + Z == 0)
                {
                    x = 0;
                    y = 0;
                }
                else
                {
                    x = X / (X + Y + Z);
                    y = Y / (X + Y + Z);
                }

                //if (Y != 0)
                //{
                //    X = X / Y;
                //    Y = Y / Y;
                //    Z = Z / Y;
                //}

                int R = Math.Min((int)(255*Math.Pow(Math.Max(3.2404542 * X - 1.5371385 * Y - 0.4985314 * Z, 0), 1/2.2)), 255);
                int G = Math.Min((int)(255*Math.Pow(Math.Max(-0.9692660 * X + 1.8760108 * Y + 0.0415560 * Z, 0), 1/2.2)), 255);
                int B = Math.Min((int)(255*Math.Pow(Math.Max(0.0556434 * X - 0.2040259 * Y + 1.0572252 * Z, 0), 1/2.2)), 255);


                //R = adj(R);
                //G = adj(G);
                //B = adj(B);

                
                //Color color = Color.Black;
                //if (x < 0 || y <= 0) continue;
                Color color = Color.FromArgb(R, G, B);
                //gC.FillEllipse(new SolidBrush(color), (int)(x * ChromaticBitmap.Width) + margin-4, (int)(ChromaticBitmap.Height - (y * ChromaticBitmap.Height)) - margin - 4, 8, 8);
                ChromaticBoundary[i] = (new Point((int)(x * ChromaticBitmap.Width) + margin, (int)(ChromaticBitmap.Height - (y * ChromaticBitmap.Height)) - margin), color);
                //ChromaticBitmap.SetPixel((int)(x * ChromaticBitmap.Width)+30, (int)(ChromaticBitmap.Height - (y * ChromaticBitmap.Height))-30, color);
                //ChromaticPic.Refresh();
            }
        }
        public static void DrawChromaticBoundary()
        {
            for(int i = 0; i<401; i++)
            {
                Point p = ChromaticBoundary[i].Item1;
                Color c = ChromaticBoundary[i].Item2;

                gC.FillEllipse(new SolidBrush(c), p.X - 4, p.Y - 4, 8, 8);
                ChromaticPic.Refresh();
            }
        }
        public static double adj(double C)
        {
            if (C < 0.0031308)
            {
                return 12.92 * C;
            }
            return 1.055 * Math.Pow(C, 0.41666) - 0.055;
        }
        public static float adj(float C)
        {
            if (C < 0.0031308)
            {
                return 12.92f * C;
            }
            return 1.055f * (float)Math.Pow(C, 0.41666) - 0.055f;
        }
        public static void DrawAxes()
        {
            Font customFont = new Font("Arial", 6);
            using (Graphics g = Graphics.FromImage(BezierBitmap.Bitmap))
            {
                // Clear the bitmap
                g.Clear(Color.White);

                // Set up the coordinate transformation
                float xScale = 400 / (780f - 380f);
                float yScale = 400 / (1.8f);

                // Draw X-axis
                g.DrawLine(Pens.Black, 30, BezierBitmap.Bitmap.Height-30, 780 * xScale, BezierBitmap.Bitmap.Height-30);
                //DrawArrow(g, Pens.Black, new Point(30, BezierBitmap.Height-30), new Point(780, BezierBitmap.Height-30), 15);

                // Draw Y-axis
                g.DrawLine(Pens.Black, 30, 0, 30, BezierBitmap.Bitmap.Height-30);
                //DrawArrow(g, Pens.Black, new Point(30, 0), new Point(30, (int)(1.8f * yScale)), 15);
                // Draw tick marks and labels on X-axis
                for (int x = 380; x <= 780; x += 50)
                {
                    int xPos = (int)((x-320));
                    g.DrawLine(Pens.Black, (xPos-30), BezierBitmap.Bitmap.Height - 35, (xPos-30), BezierBitmap.Bitmap.Height - 25);
                    g.DrawString(x.ToString(), customFont, Brushes.Black, xPos - 45, BezierBitmap.Bitmap.Height - 20);
                }

                // Draw tick marks and labels on Y-axis
                for (float y = 0; y <= 1.9f; y += 0.2f)
                {
                    int yPos = BezierBitmap.Bitmap.Height - (int)(y * yScale)-30;
                    g.DrawLine(Pens.Black, 30 - 5, yPos, 30 + 5, yPos);
                    g.DrawString(y.ToString("0.0"), customFont, Brushes.Black, 0, yPos - 10);
                }
            }
            using (Graphics g = Graphics.FromImage(ChromaticBitmap.Bitmap))
            {
                // Clear the bitmap
                //g.Clear(Color.White);

                // Set up the coordinate transformation
                float xScale = 400 / 0.8f;
                float yScale = 400 / 0.8f;

                // Draw X-axis
                g.DrawLine(Pens.Black, 30, BezierBitmap.Bitmap.Height - 30, 780 * xScale, BezierBitmap.Bitmap.Height - 30);
                //DrawArrow(g, Pens.Black, new Point(30, BezierBitmap.Height-30), new Point(780, BezierBitmap.Height-30), 15);

                // Draw Y-axis
                g.DrawLine(Pens.Black, 30, 0, 30, BezierBitmap.Bitmap.Height - 30);
                //DrawArrow(g, Pens.Black, new Point(30, 0), new Point(30, (int)(1.8f * yScale)), 15);
                // Draw tick marks and labels on X-axis
                for (float x = 0; x <= 0.9f; x += 0.1f)
                {
                    int xPos = (int)((x * xScale)) + 60;
                    g.DrawLine(Pens.Black, (xPos - 30), BezierBitmap.Bitmap.Height - 35, (xPos - 30), BezierBitmap.Bitmap.Height - 25);
                    g.DrawString(x.ToString("0.0"), customFont, Brushes.Black, xPos - 45, BezierBitmap.Bitmap.Height - 20);
                }

                // Draw tick marks and labels on Y-axis
                for (float y = 0; y <= 0.9f; y += 0.1f)
                {
                    int yPos = BezierBitmap.Bitmap.Height - (int)(y * yScale) - 30;
                    g.DrawLine(Pens.Black, 30 - 5, yPos, 30 + 5, yPos);
                    g.DrawString(y.ToString("0.0"), customFont, Brushes.Black, 0, yPos - 10);
                }
            }
        }
        public static void DrawControlPoints()
        {
            gB.Clear(Color.White);
            DrawAxes();
            for(int i = 0; i<ControlPoints.Length; i++)
            {
                double x = ControlPoints[i].X;
                double y = ControlPoints[i].Y;

                x = x * 400 + 30;
                y = BezierBitmap.Height - (y * 400) - 30;

                gB.FillEllipse(Brushes.Red, (int)(x - 4), (int)(y - 4), 8, 8);
                gB.DrawEllipse(Pens.Black, (int)(x-4), (int)(y-4), 8, 8);
            }
            BezierPic.Refresh();
        }
        #endregion
        #region Bezier
        public static bool IsPointNearCursor(PointF point, Point cursor)
        {
            point = new PointF(point.X*400+30,BezierBitmap.Height - (point.Y*400)-30);
            if (cursor.X <= point.X + 20 && cursor.X >= point.X - 20)
                if (cursor.Y <= point.Y + 20 && cursor.Y >= point.Y - 20)
                    return true;
            return false;
        }
        public static void MoveControlPoint(Point newLocation)
        {
            //PointF point = new PointF(ControlPoints[CurrentPoint].X, ControlPoints[CurrentPoint].Y);
            //point = new PointF(point.X * 400 + 30, BezierBitmap.Height - (point.Y * 400) - 30);

            float x = (float)(newLocation.X - 30) / 400f;
            float y = (float)(BezierBitmap.Height - 30 - newLocation.Y) / 400f;
            if(CurrentPoint == 0)
            {
                if (x < 0 || x > (5f / 40f))
                {
                    ControlPoints[CurrentPoint] = new PointF(ControlPoints[CurrentPoint].X, y);
                    return;
                }
                if (y < 0 || y > 1)
                {
                    ControlPoints[CurrentPoint] = new PointF(x, ControlPoints[CurrentPoint].Y);
                    return;
                }
                ControlPoints[CurrentPoint] = new PointF(x, y);
            }
            if(CurrentPoint == 1)
            {
                if (x < (51f / 400f) || x > (150f / 400f))
                {
                    ControlPoints[CurrentPoint] = new PointF(ControlPoints[CurrentPoint].X, y);
                    return;
                }
                if (y < 0 || y > 1)
                {
                    ControlPoints[CurrentPoint] = new PointF(x, ControlPoints[CurrentPoint].Y);
                    return;
                }
                ControlPoints[CurrentPoint] = new PointF(x, y);
            }
            if(CurrentPoint == 2)
            {
                if (x < (151f / 400f) || x > (250f / 400f))
                {
                    ControlPoints[CurrentPoint] = new PointF(ControlPoints[CurrentPoint].X, y);
                    return;
                }
                if (y < 0 || y > 1)
                {
                    ControlPoints[CurrentPoint] = new PointF(x, ControlPoints[CurrentPoint].Y);
                    return;
                }
                ControlPoints[CurrentPoint] = new PointF(x, y);
            }
            if (CurrentPoint == 3)
            {
                if (x < (251f / 400f) || x > (350f / 400f))
                {
                    ControlPoints[CurrentPoint] = new PointF(ControlPoints[CurrentPoint].X, y);
                    return;
                }
                if (y < 0 || y > 1)
                {
                    ControlPoints[CurrentPoint] = new PointF(x, ControlPoints[CurrentPoint].Y);
                    return;
                }
                ControlPoints[CurrentPoint] = new PointF(x, y);
            }
            if (CurrentPoint == 4)
            {
                if (x < (351f / 400f) || x > 1)
                {
                    ControlPoints[CurrentPoint] = new PointF(ControlPoints[CurrentPoint].X, y);
                    return;
                }
                if (y < 0 || y > 1)
                {
                    ControlPoints[CurrentPoint] = new PointF(x, ControlPoints[CurrentPoint].Y);
                    return;
                }
                ControlPoints[CurrentPoint] = new PointF(x, y);
            }
        }
        public static double ComputeB(int i, int n, float t)
        {
            long r = 1;
            long d;
            int ntemp = n;
            for (d = 1; d <= i; d++)
            {
                r *= ntemp--;
                r /= d;
            }
            //if(n-i<0)
            //{
            //    if (1 - t == 0) return 0;
            //    return r * Math.Pow(t, i) * (1 / Math.Pow(1 - t, i - n));
            //}
            return r * Math.Pow(t, i) * Math.Pow(1 - t, n - i);
        }

        public static void DrawBezierCurve()
        {
            for(int t = 0; t<401; t++)
            {
                float T = (float)t / 400;
                float sumX = 0f;
                float sumY = 0f;
                for(int i = 0; i<ControlPoints.Length; i++)
                {
                    float B = (float)ComputeB(i, 4, T);
                    sumX += ControlPoints[i].X * B;
                    sumY += ControlPoints[i].Y * B;
                }
                PointF newBPoint = new PointF(sumX, sumY);
                // sumX, sumY are in 0-1
                CurveYLocations[t] = newBPoint;
                // !! wywala sie
                BezierBitmap.SetPixel((int)(sumX * 400)+30, BezierBitmap.Height - (int)(sumY * 400)-30, Color.Black);
            }
            BezierPic.Refresh();
        }
        #endregion
        #region XYZ
        public static void ComputeXYZandConvert()
        {
            float X = 0, Y = 0, Z = 0;
            for (int i = 0; i < 401; i++)
            {
                PointF point = CurveYLocations[i];
                // converting to 0-1.8
                float lambdaP = point.Y * 1.8f;
                float lambda = point.X;
                X += lambdaP * (float)waves[i, 1] * lambda;
                Y += lambdaP * (float)waves[i, 2] * lambda;
                Z += lambdaP * (float)waves[i, 3] * lambda;
            }

            //X *= k;
            //Y *= k;
            //Z *= k;

            int R = Math.Min((int)(255 * Math.Pow(Math.Max(3.2404542 * X - 1.5371385 * Y - 0.4985314 * Z, 0), 1 / 2.2)), 255);
            int G = Math.Min((int)(255 * Math.Pow(Math.Max(-0.9692660 * X + 1.8760108 * Y + 0.0415560 * Z, 0), 1 / 2.2)), 255);
            int B = Math.Min((int)(255 * Math.Pow(Math.Max(0.0556434 * X - 0.2040259 * Y + 1.0572252 * Z, 0), 1 / 2.2)), 255);

            //double R = 3.2404542 * X - 1.5371385 * Y - 0.4985314 * Z;
            //double G = -0.9692660 * X + 1.8760108 * Y + 0.0415560 * Z;
            //double B = 0.0556434 * X - 0.2040259 * Y + 1.0572252 * Z;

            //R = adj(R);
            //G = adj(G);
            //B = adj(B);

            Color color = Color.FromArgb(R, G, B);
            PutPoint(X, Y, Z);
            gC.FillRectangle(new SolidBrush(color), 450, 0, 50, 50);
            
            ChromaticPic.Refresh();
        }
        public static void PutPoint(float X, float Y, float Z)
        {
            float x, y;
            if(X+Y+Z == 0)
            {
                x = 0;
                y = 0;
            }
            else
            {
                x = X / (X + Y + Z);
                y = Y / (X + Y + Z);
            }
            

            x = x * 400 + 30;
            y = BezierBitmap.Height - (y * 400) - 30;

            DrawC();
            gC.FillEllipse(Brushes.Red, (int)(x - 4), (int)(y - 4), 8, 8);

            gC.DrawString("x: " + x.ToString("0.0"), new Font("Arial", 8), Brushes.Black, new PointF(400, 10));
            gC.DrawString("y: " + y.ToString("0.0"), new Font("Arial", 8), Brushes.Black, new PointF(400, 25));
        }
        public static void DrawC()
        {
            gC.Clear(Color.White);
            Bitmap backgroundBitmap = new(new Bitmap(@"C:\Users\user\Desktop\sem5\GrafikaKomputerowa\Chromaticity\Chromaticity\hziJw.png"),
                    (int)(0.9 * ChromaticPic.Width - margin),
                    (int)(0.9 * ChromaticPic.Width - margin));
            gC.DrawImage(backgroundBitmap, new Point(margin - 10, ChromaticPic.Height - backgroundBitmap.Height - margin));
            DrawAxes();
            if (IsColorPoints) DrawChromaticBoundary();
            ChromaticPic.Refresh();
        }
        #endregion
    }
    
}
