using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an
{
    public partial class friend : UserControl
    {
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
        public friend()
        {
            InitializeComponent();
        }
        
        
    }
}
