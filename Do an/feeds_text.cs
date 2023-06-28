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
    public partial class feeds_text : UserControl
    {
        public feeds_text()
        {
            InitializeComponent();
            richTextBox1.Enabled = false;
        }
        string path = Form1.path;

        private string _reaction;
        private string _username;
        private string _text;
        private string _date;
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

        private void feeds_text_Load(object sender, EventArgs e)
        {
            panel_react.Visible = false;
            switch (lb_reaction.Text)
            {
                case "Thích": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\like.ico"); lb_reaction.ForeColor = Color.DodgerBlue; break; }
                case "Yêu thích": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\love.ico"); lb_reaction.ForeColor = Color.Gold; break; }
                case "Thương thương": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\care.ico"); lb_reaction.ForeColor = Color.Gold; break; }
                case "Haha": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\haha.ico"); lb_reaction.ForeColor = Color.Gold; break; }
                case "Wow": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\wow.ico"); lb_reaction.ForeColor = Color.Gold; break; }
                case "Buồn": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\sad.ico"); lb_reaction.ForeColor = Color.Gold; break; }
                case "Phẫn nộ": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\angry.ico"); lb_reaction.ForeColor = Color.OrangeRed; break; }
                case "Thích ": { pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\default.png"); lb_reaction.ForeColor = Color.Black; break; }
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
                    if (richTextBox1.Text == st[4])
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
        private bool isState1 = true;
        private void lb_reaction_Click(object sender, EventArgs e)
        {
            if (isState1 && lb_reaction.Text == "Thích ")
            {
                lb_reaction.Text = "Thích"; lb_reaction.ForeColor = Color.DodgerBlue;
                pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\like.ico");
                ReadFile();
            }
            else
            {
                lb_reaction.Text = "Thích "; lb_reaction.ForeColor = Color.Black;
                pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\default.png");
                ReadFile();
            }
            panel_react.Visible = false;
            isState1 = !isState1;
        }

        private void pic_like_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Thích"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.DodgerBlue;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\like.ico");
            ReadFile();
        }

        private void pic_love_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Yêu thích"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.Gold;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\love.ico");
            ReadFile();
        }

        private void pic_care_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Thương thương"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.Gold;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\care.ico");
            ReadFile();
        }

        private void pic_haha_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Haha"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.Gold;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\haha.ico");
            ReadFile();
        }

        private void pic_wow_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Wow"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.Gold;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\wow.ico");
            ReadFile();
        }

        private void pic_sad_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Buồn"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.Gold;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\sad.ico");
            ReadFile();
        }

        private void pic_angry_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Phẫn nộ"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.OrangeRed;
            pictureBox2.Image = Image.FromFile($"{path}\\icon\\emoji\\angry.ico");
            ReadFile();
        }

        private Timer visibilityTimer;
        private const int VisibilityDelay = 1000;

        private void timer2_Tick(object sender, EventArgs e)
        {
            visibilityTimer.Stop();
            visibilityTimer = null;
            panel_react.Visible = false;
        }

        private void lb_reaction_MouseEnter_1(object sender, EventArgs e)
        {
            visibilityTimer?.Stop();
            visibilityTimer = null;
            panel_react.Visible = true;
        }

        private void lb_reaction_MouseLeave_1(object sender, EventArgs e)
        {
            visibilityTimer = new Timer();
            visibilityTimer.Interval = VisibilityDelay;
            visibilityTimer.Tick += timer2_Tick;
            visibilityTimer.Start();
        }
    }
}
