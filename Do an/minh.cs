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
    public partial class minh : UserControl
    {
        public minh()
        {
            InitializeComponent();
        }
        private string _text;

        public string text
        {
            get { return _text; }
            set { _text = value; richTextBox1.Text = value; }
        }
    }
}
