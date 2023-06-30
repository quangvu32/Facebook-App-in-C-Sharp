using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an
{
    public partial class notification : UserControl
    {
        private Image _profile;
        private string _description;
        private string _date;
        public Image profile
        {
            get { return _profile; }
            set { _profile = value; pic_user.Image = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; richTextBox1.Text = value; }
        }

        public string date
        {
            get { return _date; }
            set { _date = value; label1.Text = value; }
        }
        public notification()
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
        }
        private void notification_Load(object sender, EventArgs e)
        {

        }
        private void Readfile()
        {
            string tenfile = $"{Form1.address}users\\{Form1.username_get}\\friend\\sent_request.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] st = str.Split('\t');
                    if (label1.Text == st[0])
                    {
                        if (st[1] != "sent")
                        {

                        }
                    }
                }
                sr.Close();
            }
        }  
    }
}
