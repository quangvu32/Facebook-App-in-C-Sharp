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
    public partial class background : UserControl
    {
        public background()
        {
            InitializeComponent();
        }
        public event EventHandler ButtonClicked;
        public event EventHandler ButtonClicked2;
        private string _user;
        private Image _image;
        private Image _image2;
        public string User
        {
            get { return _user; }
            set { _user = value; label1.Text = value; }
        }
        public Image Image
        {
            get { return _image; }
            set { _image = value; guna2CirclePictureBox1.Image = value; }
        }
        public Image Image2
        {
            get { return _image2; }
            set { _image2 = value; guna2PictureBox1.Image = value; }
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            ButtonClicked2?.Invoke(this, EventArgs.Empty);
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
       
    }
}
