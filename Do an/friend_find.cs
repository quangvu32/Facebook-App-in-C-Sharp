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
    public partial class friend_find : UserControl
    {
        public friend_find()
        {
            InitializeComponent();
        }

        private string _user;
        private Image _profile;

        public string User
        {
            get { return _user; }
            set { _user = value; label1.Text = value; }
        }
        public Image profile
        {
            get { return _profile; }
            set { _profile = value; pic_profile.Image = value; }
        }

        private void pic_profile_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
