using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an
{
    public partial class feeds_image : UserControl
    {
        static string fileLocation()
        {
            string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
            string parentFolder = Directory.GetParent(projectFolder).FullName;
            string projectFolderPath = Directory.GetParent(parentFolder).FullName;
            string parent = Directory.GetParent(projectFolderPath).FullName;
            string parent2 = Directory.GetParent(parent).FullName;
            return parent2;
        }
        string path = $"{fileLocation()}";
        public feeds_image()
        {
            InitializeComponent();
            richTextBox1.Enabled = false;
            
        }
        private string _reaction;
        private Image _image;
        private string _username;
        private string _text;
        private string _date;
        private string _tag;
        private Image _user;
        public Image User
        {
            get { return _user; }
            set { _user = value; pic_user.Image = value; }
        }
        public string date
        {
            get { return _date; }
            set { _date = value; lb_date.Text = value; }
        }

        public Image image
        {
            get { return _image; }
            set { _image = value; pictureBox1.Image = value; }
        }
        public string reaction
        {
            get { return _reaction; }
            set { _reaction = value; lb_reaction.Text = value; }
        }

        public string username
        {
            get { return _username; }
            set { _username = value; lb_username.Text = value; } 
        }
        public string text
        {
            get { return _text; }
            set { _text = value; richTextBox1.Text = value; }
        }
        public string tag
        {
            get { return _tag; }
            set { _tag = value; pictureBox1.Tag = value; }
        }

        private void feeds_image_Load(object sender, EventArgs e)
        {
            panel_react.Visible = false;
            switch (lb_reaction.Text)
            {
                case "Thích": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\like.ico"); break; }
                case "Yêu thích": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\love.ico"); break; }
                case "Thương thương": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\care.ico"); break; }
                case "Haha": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\haha.ico"); break; }
                case "Wow": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\wow.ico"); break; }
                case "Buồn": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\sad.ico"); break; }
                case "Phẫn nộ": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\angry.ico"); break; }
            }
        }
        private void ReadFile()
        {
            string tenfile = $"{path}\\Do an\\users\\{lb_username.Text}\\post\\post.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
                string str;
                string s1 = ""; 
                string s2 = "";
                while ((str = sr.ReadLine()) != null)
                {
                    string[] st = str.Split('\t');
                    if (st[5] == pictureBox1.Tag.ToString())
                    {
                        s1 = st[0] + '\t' + st[1] + '\t' + st[2] + '\t' + st[3] + '\t' + st[4] + '\t' + st[5] + '\t' + st[6];
                        s2 = st[0] + '\t' + st[1] + '\t' + st[2] + '\t' + st[3] + '\t' + st[4] + '\t' + st[5] + '\t' + lb_reaction.Text;
                        break;
                    }
                }
                sr.Close();
                string fileContent = File.ReadAllText(tenfile);
                string update = fileContent.Replace(s1, s2);
                File.WriteAllText(tenfile, update);
            }
        }
        private void lb_reaction_Click(object sender, EventArgs e)
        {
            panel_react.Visible = true;
        }

        private void pic_like_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Thích"; panel_react.Visible = false;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\like.ico");
            ReadFile();
        }

        private void pic_love_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Yêu thích"; panel_react.Visible = false;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\love.ico");
            ReadFile();
        }

        private void pic_care_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Thương thương"; panel_react.Visible = false;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\care.ico");
            ReadFile();
        }

        private void pic_haha_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Haha"; panel_react.Visible = false;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\haha.ico");
            ReadFile();
        }

        private void pic_wow_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Wow"; panel_react.Visible = false;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\wow.ico");
            ReadFile();
        }

        private void pic_sad_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Buồn"; panel_react.Visible = false;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\sad.ico");
            ReadFile();
        }

        private void pic_angry_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Phẫn nộ"; panel_react.Visible = false;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\angry.ico");
            ReadFile();
        }

        private void panel_react_Leave(object sender, EventArgs e)
        {
            panel_react.Visible=false;
        }

        
    }
}
