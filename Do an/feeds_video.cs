﻿using System;
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
        private Image _trangthai;
        private string _trangthai2;

        public string trangthai2
        {
            get { return _trangthai2;}
            set { _trangthai2 = value; }
        }
        public Image trangthai
        {
            get { return _trangthai; }
            set { _trangthai = value; pictureBox3.Image = value; }
        }
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
            set { _date = value; lb_date.Text = value; }
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
            richTextBox1.ReadOnly = true;
            video.OpenStateChange += AxWindowsMediaPlayer1_OpenStateChange;
            video.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;
            slider.Height = 20;
            guna2TrackBar1.Value = 50;
            panel_option.Visible = false;
            pictureBox2.Visible = false;
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
                timer1.Start();
            }
            else
            {
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
            switch (lb_reaction.Text)
            {
                case "Thích": { pictureBox1.Image = Image.FromFile(Path.Combine($"{path}\\icon\\emoji\\","like.ico")); lb_reaction.ForeColor = Color.DodgerBlue; break; }
                case "Yêu thích": { pictureBox1.Image = Image.FromFile(Path.Combine($"{path}\\icon\\emoji\\", "love.ico")); lb_reaction.ForeColor = Color.Gold; break; }
                case "Thương thương": { pictureBox1.Image = Image.FromFile(Path.Combine($"{path}\\icon\\emoji\\", "like.ico")); lb_reaction.ForeColor = Color.Gold; break; }
                case "Haha": { pictureBox1.Image = Image.FromFile(Path.Combine($"{path}\\icon\\emoji\\", "haha.ico")); lb_reaction.ForeColor = Color.Gold; break; }
                case "Wow": { pictureBox1.Image = Image.FromFile(Path.Combine($"{path}\\icon\\emoji\\", "wow.ico")); lb_reaction.ForeColor = Color.Gold; break; }
                case "Buồn": { pictureBox1.Image = Image.FromFile(Path.Combine($"{path}\\icon\\emoji\\", "sad.ico")); lb_reaction.ForeColor = Color.Gold;break; }
                case "Phẫn nộ": { pictureBox1.Image = Image.FromFile(Path.Combine($"{path}\\icon\\emoji\\", "angry.ico")); lb_reaction.ForeColor = Color.OrangeRed; break; }
                case "Thích ": { pictureBox1.Image = Image.FromFile(Path.Combine($"{path}\\icon\\emoji\\", "default.png")); lb_reaction.ForeColor = Color.Black; break; }
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
        private bool isState1 = true;
        private void lb_reaction_Click(object sender, EventArgs e)
        {
            if(isState1 && lb_reaction.Text == "Thích ")
            {
                lb_reaction.Text = "Thích";
                lb_reaction.ForeColor = Color.DodgerBlue;
                pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\like.ico");
                ReadFile();
            }    
            else
            {
                lb_reaction.Text = "Thích ";
                lb_reaction.ForeColor = Color.Black;
                pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\default.png");
                ReadFile();
            }    
            panel_react.Visible = false;
            isState1 = !isState1;

        }
        private void pic_like_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Thích"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.DodgerBlue;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\like.ico");
            ReadFile();
        }

        private void pic_love_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Yêu thích"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.Gold;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\love.ico");
            ReadFile();
        }

        private void pic_care_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Thương thương"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.Gold;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\care.ico");
            ReadFile();
        }

        private void pic_haha_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Haha"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.Gold;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\haha.ico");
            ReadFile();
        }

        private void pic_wow_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Wow"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.Gold;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\wow.ico");
            ReadFile();
        }

        private void pic_sad_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Buồn"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.Gold;
            pictureBox1.Image = Image.FromFile($"{path}\\icon\\emoji\\sad.ico");
            ReadFile();
        }

        private void pic_angry_Click(object sender, EventArgs e)
        {
            lb_reaction.Text = "Phẫn nộ"; panel_react.Visible = false;
            lb_reaction.ForeColor = Color.OrangeRed;
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

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            video.settings.volume = guna2TrackBar1.Value;
        }
        private Timer visibilityTimer;
        private const int VisibilityDelay = 1000;
        private void lb_reaction_MouseLeave(object sender, EventArgs e)
        {
            visibilityTimer = new Timer();
            visibilityTimer.Interval = VisibilityDelay;
            visibilityTimer.Tick += timer2_Tick;
            visibilityTimer.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            visibilityTimer.Stop();
            visibilityTimer = null;
            panel_react.Visible = false;
        }

        private void lb_reaction_MouseEnter(object sender, EventArgs e)
        {
            visibilityTimer?.Stop();
            visibilityTimer = null;
            panel_react.Visible = true;
        }
        public event EventHandler RemoveBtn;
        bool enabled;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (enabled == true)
            {
                panel_option.Visible = true;
                enabled = false;
            }
            else
            {
                panel_option.Visible = false;
                enabled = true;
            }
            //RemoveBtn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Button_delete;
        private void label5_Click(object sender, EventArgs e)
        {
            Button_delete?.Invoke(this, EventArgs.Empty);
        }
        public void delete()
        {
            string tenfile = $"{Form1.address}users\\{lb_username.Text}\\post\\post.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] st = str.Split('\t');
                    if (lb_username.Text == st[0] && lb_date.Text == st[3] && video.Tag.ToString() == st[5])
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa bài viết?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            sr.Close();
                            Form1.delete($"{tenfile}", str);
                            MessageBox.Show("Xóa bài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            sr.Close();
                        }
                        break;
                    }
                }
            }
        }
        public event EventHandler Button_fix;
        private void label4_Click(object sender, EventArgs e)
        {
            Button_fix.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler button_hide;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button_hide.Invoke(this, EventArgs.Empty);
        }
        public void hide()
        {
            pictureBox2.Visible = true;
            pictureBox4.Visible = false;
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
