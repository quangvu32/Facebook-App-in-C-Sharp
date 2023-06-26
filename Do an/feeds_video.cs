using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Do_an
{
    public partial class feeds_video : UserControl
    {
        string path = Form1.path;
        private string _reaction;
        private string _username;
        private string _text;
        private string _date;
        private string _tag;
        private string _url;
        private Image _user;

        public Image User
        {
            get { return _user; }
            set { _user = value; pic_user.Image = value; }
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
        public string date
        {
            get { return _date; }
            set { _date = value; label2.Text = value; }
        }
        public string tag
        {
            get { return _tag; }
            set { _tag = value; video.Tag = value; }
        }
        public string url
        {
            get { return _url; }
            set { _url = value; video.URL = value; }
        }
        public feeds_video()
        {
            InitializeComponent();
            richTextBox1.Enabled = false;
            video.OpenStateChange += AxWindowsMediaPlayer1_OpenStateChange;
            video.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;
            slider.Height = 20;
        }

        #region slider control
        float Default_value = 0.1f, Min = 0.0f, Max = 1.0f;
        public void thumb(float value)
        {
            if (value < Min) value = Min;
            if (value > Max) value = Max;
            Default_value = value;
            slider.Refresh();
        }

        public float slider_width(int x)
        {
            return Min + (Max - Min) * x / (float)(slider.Width);
        }
        public float Bar(float value)
        {
            return (slider.Width - 24) * (value - Min) / (float)(Max - Min);
        }
        private void slider_Paint(object sender, PaintEventArgs e)
        {
            float bar_size = 0.45f;
            float x = Bar(Default_value);
            int y = (int)(slider.Height * bar_size);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillRectangle(Brushes.DimGray, 0, y, slider.Width, y / 2);
            e.Graphics.FillRectangle(Brushes.White, 0, y, x, slider.Height - 2 * y);
            using (Pen pen = new Pen(Color.White, 6))
            {
                e.Graphics.DrawEllipse(pen, x + 2, y - 4, slider.Height / 2, slider.Height / 2);
                e.Graphics.FillEllipse(Brushes.White, x + 2, y - 4, slider.Height / 2, slider.Height / 2);
            }

        }
        bool mouse = false;
        private void slider_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = true;
            thumb(slider_width(e.X));
            video.Ctlcontrols.currentPosition = video.currentMedia.duration * e.X / slider.Width;
        }
        private void slider_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouse) return;
            thumb(slider_width(e.X));
            video.Ctlcontrols.currentPosition = video.currentMedia.duration * e.X / slider.Width;
        }
        private void slider_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (video.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Max = (int)video.Ctlcontrols.currentItem.duration;
                Default_value = (int)video.Ctlcontrols.currentPosition;
                slider.Invalidate();

                lb_start.Text = video.Ctlcontrols.currentPositionString;
                lb_end.Text = video.Ctlcontrols.currentItem.durationString;
            }

        }
        #endregion
        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                pic_replay.Visible = true;
                pic_pause.Visible = false;
                pic_play.Visible = false;
            }
            if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                // Start updating the TrackBar and timer

                timer1.Start();
            }
            else
            {
                // Stop updating the TrackBar and timer
                timer1.Stop();
            }
        }
        private void AxWindowsMediaPlayer1_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            if ((WMPLib.WMPOpenState)e.newState == WMPLib.WMPOpenState.wmposMediaOpen)
            {
                video.Ctlcontrols.pause();
                pic_pause.Visible = false;
                pic_replay.Visible = false;
                lb_start.Text = "00:00";
                lb_end.Text = "00:00";
            }
        }
        private void feeds_video_Load(object sender, EventArgs e)
        {

            video.uiMode = "none";
            panel_react.Visible = false;
            switch (lb_reaction.ToString())
            {
                case "Thích": { pictureBox3.Image = Image.FromFile($"{path}\\icon\\emoji\\like.ico"); break; }
                case "Yêu thích": { pictureBox3.Image = Image.FromFile($"{path}\\icon\\emoji\\love.ico"); break; }
                case "Thương thương": { pictureBox3.Image = Image.FromFile($"{path}\\icon\\emoji\\care.ico"); break; }
                case "Haha": { pictureBox3.Image = Properties.Resources.haha; break; }
                case "Wow": { pictureBox3.Image = Image.FromFile($"{path}\\icon\\emoji\\wow.ico"); break; }
                case "Buồn": { pictureBox3.Image = Image.FromFile($"{path}\\icon\\emoji\\sad.ico"); break; }
                case "Phẫn nộ": { pictureBox3.Image = Image.FromFile($"{path}\\icon\\emoji\\angry.ico"); break; }
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
                    if (st[5] == video.Tag.ToString())
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
        #region Click reactions
        private void lb_reaction_Click(object sender, EventArgs e)
        {
            panel_react.Visible = true;
        }

        private void pic_like_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Thích"; panel_react.Visible = false;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\like.ico");
            ReadFile();
        }

        private void pic_love_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Yêu thích"; panel_react.Visible = false;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\love.ico");
            ReadFile();
        }

        private void pic_care_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Thương thương"; panel_react.Visible = false;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\care.ico");
            ReadFile();
        }

        private void pic_haha_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Haha"; panel_react.Visible = false;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\haha.ico");
            ReadFile();
        }

        private void pic_wow_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Wow"; panel_react.Visible = false;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\wow.ico");
            ReadFile();
        }

        private void pic_sad_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Buồn"; panel_react.Visible = false;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\sad.ico");
            ReadFile();
        }

        private void pic_angry_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Phẫn nộ"; panel_react.Visible = false;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\angry.ico");
            ReadFile();
        }
        #endregion
        private void panel_react_Leave(object sender, EventArgs e)
        {
            panel_react.Visible = false;
        }

        private void pic_play_Click(object sender, EventArgs e)
        {
            timer1.Start();
            pic_play.Visible = false;
            pic_pause.Visible = true;
            video.Ctlcontrols.play();
        }

        private void pic_pause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            pic_play.Visible = true;
            pic_pause.Visible = false;
            video.Ctlcontrols.pause();
        }

        private void pic_replay_Click(object sender, EventArgs e)
        {
            pic_replay.Visible = false;
            pic_pause.Visible = true;
            video.Ctlcontrols.play();
        }

    }
}
