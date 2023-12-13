using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromaticity
{
    public partial class CIEXYZ : Form
    {
        public CIEXYZ()
        {
            InitializeComponent();

            Logic.ChromaticPic = this.chromaticPicBox;
            Logic.BezierPic = this.BezierPictureBox;
            Logic.Init();

            //ColorPointsCheckBox.Checked = true;
        }

        private void BezierPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            for(int i = 0; i<Logic.ControlPoints.Length; i++)
            { 
                if(Logic.IsPointNearCursor(Logic.ControlPoints[i], e.Location))
                {
                    Logic.CurrentPoint = i;
                    Logic.IsPointMove = true;
                }
            }
        }

        private void BezierPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Logic.IsPointMove)
            {
                // move control points
                Point cursor = e.Location;
                Logic.MoveControlPoint(cursor);
                // draw new control points
                Logic.DrawControlPoints();
                //calculate bezier curve
                for(int t = 0; t<401; t++)
                {
                    Logic.TEMPCurveYLocations[t] = Logic.CurveYLocations[t];
                }
                Logic.DrawBezierCurve();
                Logic.ComputeXYZandConvert();
                //calculate color
                //Logic.ComputeXYZandConvert();
            }
        }

        private void BezierPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Logic.CurrentPoint = -1;
            Logic.IsPointMove = false;
        }

        private void ColorPointsCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if(ColorPointsCheckBox.Checked)
            {
                Logic.IsColorPoints = true;
                Logic.DrawC();
            }
            else
            {
                Logic.IsColorPoints = false;
                Logic.DrawC();
            }
        }
    }
}
