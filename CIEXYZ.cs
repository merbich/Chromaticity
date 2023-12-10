﻿using System;
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
        }

    }
}
