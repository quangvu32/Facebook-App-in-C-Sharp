﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an
{
    public partial class post : UserControl
    {
        public event EventHandler ButtonClicked;
        private Image _image;
        public Image Image
        {
            get { return _image; }
            set { _image = value; picProfile.Image = value; }
        }
        public post()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}