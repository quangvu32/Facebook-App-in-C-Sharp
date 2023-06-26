namespace Do_an
{
    partial class feeds_video
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(feeds_video));
            this.lb_reaction = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_react = new System.Windows.Forms.Panel();
            this.pic_angry = new System.Windows.Forms.PictureBox();
            this.pic_sad = new System.Windows.Forms.PictureBox();
            this.pic_wow = new System.Windows.Forms.PictureBox();
            this.pic_haha = new System.Windows.Forms.PictureBox();
            this.pic_care = new System.Windows.Forms.PictureBox();
            this.pic_love = new System.Windows.Forms.PictureBox();
            this.pic_like = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_end = new System.Windows.Forms.Label();
            this.pic_play = new System.Windows.Forms.PictureBox();
            this.lb_start = new System.Windows.Forms.Label();
            this.pic_replay = new System.Windows.Forms.PictureBox();
            this.pic_pause = new System.Windows.Forms.PictureBox();
            this.video = new AxWMPLib.AxWindowsMediaPlayer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pic_user = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.slider = new System.Windows.Forms.PictureBox();
            this.panel_react.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_angry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_wow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_haha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_care)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_love)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_like)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_replay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.video)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_reaction
            // 
            this.lb_reaction.AutoSize = true;
            this.lb_reaction.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_reaction.Location = new System.Drawing.Point(33, 436);
            this.lb_reaction.Name = "lb_reaction";
            this.lb_reaction.Size = new System.Drawing.Size(56, 21);
            this.lb_reaction.TabIndex = 9;
            this.lb_reaction.Text = "Thích ";
            this.lb_reaction.Click += new System.EventHandler(this.lb_reaction_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(163, 436);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Bình luận";
            // 
            // panel_react
            // 
            this.panel_react.Controls.Add(this.pic_angry);
            this.panel_react.Controls.Add(this.pic_sad);
            this.panel_react.Controls.Add(this.pic_wow);
            this.panel_react.Controls.Add(this.pic_haha);
            this.panel_react.Controls.Add(this.pic_care);
            this.panel_react.Controls.Add(this.pic_love);
            this.panel_react.Controls.Add(this.pic_like);
            this.panel_react.Location = new System.Drawing.Point(24, 387);
            this.panel_react.Name = "panel_react";
            this.panel_react.Size = new System.Drawing.Size(324, 43);
            this.panel_react.TabIndex = 20;
            this.panel_react.Leave += new System.EventHandler(this.panel_react_Leave);
            // 
            // pic_angry
            // 
            this.pic_angry.Image = global::Do_an.Properties.Resources.angry;
            this.pic_angry.Location = new System.Drawing.Point(281, 0);
            this.pic_angry.Margin = new System.Windows.Forms.Padding(2);
            this.pic_angry.Name = "pic_angry";
            this.pic_angry.Size = new System.Drawing.Size(38, 41);
            this.pic_angry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_angry.TabIndex = 20;
            this.pic_angry.TabStop = false;
            this.pic_angry.Click += new System.EventHandler(this.pic_angry_Click);
            // 
            // pic_sad
            // 
            this.pic_sad.Image = global::Do_an.Properties.Resources.sad;
            this.pic_sad.Location = new System.Drawing.Point(235, 0);
            this.pic_sad.Margin = new System.Windows.Forms.Padding(2);
            this.pic_sad.Name = "pic_sad";
            this.pic_sad.Size = new System.Drawing.Size(38, 41);
            this.pic_sad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_sad.TabIndex = 19;
            this.pic_sad.TabStop = false;
            this.pic_sad.Click += new System.EventHandler(this.pic_sad_Click);
            // 
            // pic_wow
            // 
            this.pic_wow.Image = global::Do_an.Properties.Resources.wow;
            this.pic_wow.Location = new System.Drawing.Point(189, 0);
            this.pic_wow.Margin = new System.Windows.Forms.Padding(2);
            this.pic_wow.Name = "pic_wow";
            this.pic_wow.Size = new System.Drawing.Size(38, 41);
            this.pic_wow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_wow.TabIndex = 18;
            this.pic_wow.TabStop = false;
            this.pic_wow.Click += new System.EventHandler(this.pic_wow_Click);
            // 
            // pic_haha
            // 
            this.pic_haha.Image = global::Do_an.Properties.Resources.haha;
            this.pic_haha.Location = new System.Drawing.Point(143, 0);
            this.pic_haha.Margin = new System.Windows.Forms.Padding(2);
            this.pic_haha.Name = "pic_haha";
            this.pic_haha.Size = new System.Drawing.Size(38, 41);
            this.pic_haha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_haha.TabIndex = 17;
            this.pic_haha.TabStop = false;
            this.pic_haha.Click += new System.EventHandler(this.pic_haha_Click);
            // 
            // pic_care
            // 
            this.pic_care.Image = global::Do_an.Properties.Resources.care;
            this.pic_care.Location = new System.Drawing.Point(97, 0);
            this.pic_care.Margin = new System.Windows.Forms.Padding(2);
            this.pic_care.Name = "pic_care";
            this.pic_care.Size = new System.Drawing.Size(38, 41);
            this.pic_care.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_care.TabIndex = 16;
            this.pic_care.TabStop = false;
            this.pic_care.Click += new System.EventHandler(this.pic_care_Click);
            // 
            // pic_love
            // 
            this.pic_love.Image = global::Do_an.Properties.Resources.love;
            this.pic_love.Location = new System.Drawing.Point(51, 0);
            this.pic_love.Margin = new System.Windows.Forms.Padding(2);
            this.pic_love.Name = "pic_love";
            this.pic_love.Size = new System.Drawing.Size(38, 41);
            this.pic_love.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_love.TabIndex = 15;
            this.pic_love.TabStop = false;
            this.pic_love.Click += new System.EventHandler(this.pic_love_Click);
            // 
            // pic_like
            // 
            this.pic_like.Image = global::Do_an.Properties.Resources.like;
            this.pic_like.Location = new System.Drawing.Point(5, 0);
            this.pic_like.Margin = new System.Windows.Forms.Padding(2);
            this.pic_like.Name = "pic_like";
            this.pic_like.Size = new System.Drawing.Size(38, 41);
            this.pic_like.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_like.TabIndex = 14;
            this.pic_like.TabStop = false;
            this.pic_like.Click += new System.EventHandler(this.pic_like_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "Chia sẻ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "label2";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(97, 15);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(61, 25);
            this.lb_username.TabIndex = 13;
            this.lb_username.Text = "label1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 69);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(388, 52);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.lb_end);
            this.panel1.Controls.Add(this.pic_play);
            this.panel1.Controls.Add(this.lb_start);
            this.panel1.Controls.Add(this.pic_replay);
            this.panel1.Controls.Add(this.pic_pause);
            this.panel1.Location = new System.Drawing.Point(0, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 38);
            this.panel1.TabIndex = 27;
            // 
            // lb_end
            // 
            this.lb_end.AutoSize = true;
            this.lb_end.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_end.ForeColor = System.Drawing.Color.White;
            this.lb_end.Location = new System.Drawing.Point(342, 8);
            this.lb_end.Name = "lb_end";
            this.lb_end.Size = new System.Drawing.Size(43, 17);
            this.lb_end.TabIndex = 31;
            this.lb_end.Text = "label5";
            // 
            // pic_play
            // 
            this.pic_play.BackColor = System.Drawing.Color.Transparent;
            this.pic_play.Image = global::Do_an.Properties.Resources.Play_Button_Png;
            this.pic_play.Location = new System.Drawing.Point(170, 3);
            this.pic_play.Name = "pic_play";
            this.pic_play.Size = new System.Drawing.Size(35, 35);
            this.pic_play.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_play.TabIndex = 25;
            this.pic_play.TabStop = false;
            this.pic_play.Click += new System.EventHandler(this.pic_play_Click);
            // 
            // lb_start
            // 
            this.lb_start.AutoSize = true;
            this.lb_start.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_start.ForeColor = System.Drawing.Color.White;
            this.lb_start.Location = new System.Drawing.Point(3, 8);
            this.lb_start.Name = "lb_start";
            this.lb_start.Size = new System.Drawing.Size(43, 17);
            this.lb_start.TabIndex = 30;
            this.lb_start.Text = "label4";
            // 
            // pic_replay
            // 
            this.pic_replay.BackColor = System.Drawing.Color.Transparent;
            this.pic_replay.Image = global::Do_an.Properties.Resources.pngaaa_com_1451153;
            this.pic_replay.Location = new System.Drawing.Point(170, 3);
            this.pic_replay.Name = "pic_replay";
            this.pic_replay.Size = new System.Drawing.Size(35, 35);
            this.pic_replay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_replay.TabIndex = 28;
            this.pic_replay.TabStop = false;
            this.pic_replay.Click += new System.EventHandler(this.pic_replay_Click);
            // 
            // pic_pause
            // 
            this.pic_pause.BackColor = System.Drawing.Color.Transparent;
            this.pic_pause.Image = global::Do_an.Properties.Resources.White_Pause_Button_Symbol_Png;
            this.pic_pause.Location = new System.Drawing.Point(170, 3);
            this.pic_pause.Name = "pic_pause";
            this.pic_pause.Size = new System.Drawing.Size(35, 35);
            this.pic_pause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_pause.TabIndex = 26;
            this.pic_pause.TabStop = false;
            this.pic_pause.Click += new System.EventHandler(this.pic_pause_Click);
            // 
            // video
            // 
            this.video.Enabled = true;
            this.video.Location = new System.Drawing.Point(0, 127);
            this.video.Name = "video";
            this.video.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("video.OcxState")));
            this.video.Size = new System.Drawing.Size(388, 245);
            this.video.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 436);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // pic_user
            // 
            this.pic_user.ImageRotate = 0F;
            this.pic_user.Location = new System.Drawing.Point(16, 15);
            this.pic_user.Name = "pic_user";
            this.pic_user.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pic_user.Size = new System.Drawing.Size(61, 51);
            this.pic_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_user.TabIndex = 22;
            this.pic_user.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Do_an.Properties.Resources.close1;
            this.pictureBox4.Location = new System.Drawing.Point(355, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(187, 36);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // slider
            // 
            this.slider.BackColor = System.Drawing.Color.Black;
            this.slider.Location = new System.Drawing.Point(0, 372);
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(388, 20);
            this.slider.TabIndex = 30;
            this.slider.TabStop = false;
            this.slider.Paint += new System.Windows.Forms.PaintEventHandler(this.slider_Paint);
            this.slider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.slider_MouseDown);
            this.slider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.slider_MouseMove);
            this.slider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slider_MouseUp);
            // 
            // feeds_video
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel_react);
            this.Controls.Add(this.slider);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pic_user);
            this.Controls.Add(this.video);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lb_reaction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_username);
            this.Name = "feeds_video";
            this.Size = new System.Drawing.Size(388, 465);
            this.Load += new System.EventHandler(this.feeds_video_Load);
            this.panel_react.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_angry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_wow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_haha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_care)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_love)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_like)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_replay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.video)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pic_angry;
        private System.Windows.Forms.PictureBox pic_sad;
        private System.Windows.Forms.PictureBox pic_wow;
        private System.Windows.Forms.Label lb_reaction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pic_haha;
        private System.Windows.Forms.PictureBox pic_care;
        private System.Windows.Forms.PictureBox pic_love;
        private System.Windows.Forms.PictureBox pic_like;
        private System.Windows.Forms.Panel panel_react;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_username;
        private AxWMPLib.AxWindowsMediaPlayer video;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_user;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pic_play;
        private System.Windows.Forms.PictureBox pic_pause;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic_replay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_end;
        private System.Windows.Forms.Label lb_start;
        private System.Windows.Forms.PictureBox slider;
    }
}
