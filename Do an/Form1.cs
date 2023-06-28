using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Do_an
{
    public partial class Form1 : Form
    {
        DateTime date = DateTime.Now;
        public static string username_get;
        static string fileLocation()
        {
            string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
            string parentFolder = Directory.GetParent(projectFolder).FullName;
            string projectFolderPath = Directory.GetParent(parentFolder).FullName;
            string parent = Directory.GetParent(projectFolderPath).FullName;
            return parent;
        }  
        static string fileLocation2()
        {
            string parent2 = Directory.GetParent(fileLocation()).FullName;
            return parent2;
        }

        public static string address = $"{fileLocation()}\\";
        public static string path = $"{fileLocation2()}";
        

        public Form1(string username)
        {
            InitializeComponent();
            username_get = username;
            lb_username.Text = username;
        }
        private string _reaction;
        public string reaction
        {
            get { return _reaction; }
            set { _reaction = value; }
        }
        private void lb_dangxuat_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            Dispose(true);
            
            Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel_post.Visible = false; panel_home.Visible = true;  panel_profile.Visible = false;  panel_friend.Visible = false;
            btn_post.Tag = "Text";
            video.OpenStateChange += AxWindowsMediaPlayer1_OpenStateChange;
            cb_quyen.Text = "Công khai";
            video.uiMode = "none";
            video.Visible = false;
            pictureBox3.Visible = false;
            flowLayoutPanel4.Visible = false;

            picProfile2.Tag = "0";
            pic_background.Tag = "0";
            
            Readfile_prof();
            
            picProfile.Image = btn_user.Image;
            picProfile3.Image = btn_user.Image;
            Readfile_Profpost();
            Read_friend_request();
            Readfile_notif();

        }
        private void AxWindowsMediaPlayer1_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            if ((WMPLib.WMPOpenState)e.newState == WMPLib.WMPOpenState.wmposMediaOpen)
            {
                video.Ctlcontrols.pause();
            }
        }
        string[] friend;
        private void Readfile_friend()
        {
            string tenfile = $"{address}users\\{lb_username.Text}\\friend\\friend.txt";
            StreamReader r = new StreamReader(tenfile);
            string str;  int i = 0;
            while ((str = r.ReadLine()) != null)
            {
                friend[i] = str;
                i++;
            }
        }
        private void Readfile_post()
        {
            


            string tenfile = $"{address}users\\{lb_username.Text}\\post\\post.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] st = str.Split('\t');
                    if (st[1] == "image")
                    {
                        feeds_image dv = new feeds_image
                        {
                            username = st[0],
                            image = Image.FromFile($"{address}users\\{lb_username.Text}\\post\\{st[5]}"),
                            text = st[4],
                            date = st[3],
                            reaction = st[6],
                            tag = st[5],
                            User = btn_user.Image
                            
                        };

                        if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                        else { flowLayoutPanel2.Controls.Add(dv); }
                    }
                    else if (st[1] == "video")
                    {
                        feeds_video v = new feeds_video
                        {
                            username = st[0],
                            url = $"{address}users\\{lb_username.Text}\\post\\{st[5]}",
                            text = st[4],
                            date = st[3],
                            reaction = st[6],
                            tag = st[5],
                            User = btn_user.Image
                        };

                        if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                        else { flowLayoutPanel2.Controls.Add(v); }
                    }
                    else
                    {
                        feeds_text t = new feeds_text
                        {
                            username = st[0],
                            text = st[4],
                            date = st[3],
                            reaction = st[6],
                            User = btn_user.Image,
                            Tag = st[4]
                        };

                        if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                        else { flowLayoutPanel2.Controls.Add(t); }
                    }
                }
                sr.Close();
            }
        }
        private void Readfile_prof()
        {
            string profile = $"{address}users\\{lb_username.Text}\\profile.txt";
            string background = $"{address}users\\{lb_username.Text}\\background.txt";
            string image = "";string image2 = "";
            FileInfo f = new FileInfo(profile);
            post p = new post();
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(profile);
                image = sr.ReadLine();
                sr.Close();
            }
            f = new FileInfo(background);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(background);
                image2 = sr.ReadLine();
                sr.Close();
            }
            background bg = new background
            {
                Image = Image.FromFile(Path.Combine($"{address}users\\{lb_username.Text}\\post\\", image)),
                Image2 = Image.FromFile(Path.Combine($"{address}users\\{lb_username.Text}\\post\\", image2)),
                User = lb_username.Text,
            };
            p.Image = Image.FromFile(Path.Combine($"{address}users\\{lb_username.Text}\\post\\", image));
            btn_user.Image = bg.Image;
            if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
            else { flowLayoutPanel2.Controls.Add(bg); }
            
            flowLayoutPanel2.Controls.Add(p);
            bg.ButtonClicked += guna2CirclePictureBox_profile_Click;
            bg.ButtonClicked2 += pic_background_Click;
            p.ButtonClicked += button1_Click;
        }
        public void Read_friend_request()
        {
            string tenfile = "user.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    string p;
                    string[] st = str.Split('\t');
                    StreamReader r = new StreamReader($"{address}users\\{lb_username.Text}\\friend\\friend.txt");
                    string str2;
                    while((str2 = r.ReadLine())!=null)
                    {
                        if (st[0] != lb_username.Text && st[0] != str2)
                        {
                            StreamReader a = new StreamReader($"{address}users\\{st[0]}\\profile.txt");
                            p = a.ReadLine();
                            friend_find dv = new friend_find()
                            {
                                User = st[0],
                                profile = Image.FromFile($"{address}users\\{st[0]}\\post\\{p}"),
                            };
                            a.Close();
                            if (flowLayoutPanel3.Controls.Count < 0) { flowLayoutPanel3.Controls.Clear(); }
                            else { flowLayoutPanel3.Controls.Add(dv); }
                            dv.ButtonClicked += btn_clicked;
                            dv.ButtonClicked3 += btn_clicked3;
                        }
                    }    
                    
                }
                sr.Close();
            }
        }
        private void btn_clicked(object sender, EventArgs e)
        {
            friend_find friend_find = sender as friend_find;
            friend_find.open_item();
        }
        private void btn_clicked3(object sender, EventArgs e)
        {
            friend_find friend_find = sender as friend_find;
            friend_find.item2();
        }

        private void Readfile_Profpost()
        {
            string tenfile = $"{address}users\\{lb_username.Text}\\post\\post.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] st = str.Split('\t');
                    if (st[1] == "image")
                    {
                        feeds_image dv = new feeds_image
                        {
                            username = st[0],
                            image = Image.FromFile($"{address}users\\{lb_username.Text}\\post\\{st[5]}"),
                            text = st[4],
                            date = st[3],
                            reaction = st[6],
                            tag = st[5],
                            User = btn_user.Image
                        };

                        if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                        else { flowLayoutPanel2.Controls.Add(dv); }
                    }
                    else if (st[1] == "video")
                    {
                        feeds_video v = new feeds_video
                        {
                            username = st[0],
                            url = $"{address}users\\{lb_username.Text}\\post\\{st[5]}",
                            text = st[4],
                            date = st[3],
                            reaction = st[6],
                            tag = st[5],
                            User = btn_user.Image
                        };

                        if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                        else { flowLayoutPanel2.Controls.Add(v); }
                    }
                    else
                    {
                        feeds_text t = new feeds_text
                        {
                            username = st[0],
                            text = st[4],
                            date = st[3],
                            reaction = st[6],
                            User = btn_user.Image,
                            Tag = st[4]
                        };

                        if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                        else { flowLayoutPanel2.Controls.Add(t); }
                    }
                }
                sr.Close();
            }
        }

        private void Readfile_notif()
        {
            string tenfile = $"{address}users\\{lb_username.Text}\\notification\\notification.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
                string str;
                string image;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] st = str.Split('\t');
                    StreamReader a = new StreamReader($"{address}users\\{st[0]}\\profile.txt");
                    image = a.ReadLine();
                    a.Close();
                    notification nt = new notification
                    {
                        Description = $"{st[0]} {st[1]}",
                        profile = Image.FromFile($"{address}users\\{st[0]}\\post\\{image}")
                    };
                    if (flowLayoutPanel4.Controls.Count < 0) { flowLayoutPanel4.Controls.Clear(); }
                    else { flowLayoutPanel4.Controls.Add(nt); }
                }
                sr.Close();
            }
        }
        private void pic_appClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            panel_post.Visible = true;
        }

        private string word_search(string word_found)
        {
            string[] str = word_found.ToString().Trim().ToLower().Split('\t');
            return str[0];
        }
        private void replace(string txtfile, string item)
        {
            //Delete a chosen item in txt file and update
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(txtfile).Where(l => l != item);
            File.WriteAllLines(tempFile, linesToKeep);
            File.Delete(txtfile);
            File.Move(tempFile, txtfile);
            File.WriteAllLines(txtfile, File.ReadLines(txtfile).Where(l => l != item).ToList());
        }
        private void update_text(string s1, string s2, string file)
        {
            string content = File.ReadAllText(file);

            content = content.Replace(s1, s2);
            File.WriteAllText(file, content);
        }
        private void copyFile(string source, string destination)
        {
            string filename = Path.GetFileName(source);
            string destinationFilePath = Path.Combine(destination, filename);

            File.Copy(source, destinationFilePath, true);
        }
        #region pic profile
        private void guna2CirclePictureBox_profile_Click(object sender, EventArgs e)
        {
            picProfile2.Tag = "1";
            panel_post.Visible = true;
            btnPost_video.Visible = false;
        }
        private void pic_background_Click(object sender, EventArgs e)
        {
            pic_background.Tag = "1";
            panel_post.Visible= true;
            btnPost_video.Visible= false;
        }
        #endregion

        #region post bài
        //ImageList imagelist = new ImageList();
        //int i;
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            video.Visible = false;
            btn_post.Tag = "image";
            OpenFileDialog Ofile = new OpenFileDialog();
            Ofile.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (Ofile.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(Ofile.FileName);
                pictureBox3.Tag = Ofile.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            video.Visible = true;
            btn_post.Tag = "video";
            OpenFileDialog Ofile = new OpenFileDialog();
            Ofile.Filter = "Choose Video(*.mp3;*.mp4)|*.mp3;*.mp4";
            if (Ofile.ShowDialog() == DialogResult.OK)
            {
                video.URL = Ofile.FileName;
                video.Tag = Ofile.FileName;
                //Readfile();
            }
        }

        private void post_image()
        {
            string filepath = $"{address}users\\{lb_username.Text}";
            copyFile(pictureBox3.Tag.ToString(), $"{filepath}\\post");
            StreamWriter sw = new StreamWriter($"{address}users\\{lb_username.Text}\\post\\post.txt",true);
            if (richTextBox1.Text == null)
            {
                richTextBox1.Text = " ";
            }
            if(picProfile2.Tag.ToString() == "1")
            {
                background bg = new background();
                bg.Image = pictureBox3.Image;
                picProfile.Image = pictureBox3.Image; picProfile2.Image = pictureBox3.Image; picProfile3.Image = pictureBox3.Image;
                copyFile(pictureBox3.Tag.ToString(), $"{filepath}\\post");
                File.WriteAllText($"{filepath}\\profile.txt", Path.GetFileName(pictureBox3.Tag.ToString()));
            }   
            if(pic_background.Tag.ToString() == "1")
            {
                background bg = new background();
                bg.Image2 = pictureBox3.Image;
                pic_background.Image = pictureBox3.Image;
                copyFile(pictureBox3.Tag.ToString(), $"{filepath}\\post");
                File.WriteAllText($"{filepath}\\background.txt", Path.GetFileName(pictureBox3.Tag.ToString()));
            }    
            sw.WriteLine(lb_username.Text + '\t'
                        + btn_post.Tag.ToString() + '\t'
                        + cb_quyen.Text + '\t'
                        + $"{date.Day} thg {date.Month}, {date.Year}" + '\t'
                        + richTextBox1.Text + '\t'
                        + Path.GetFileName(pictureBox3.Tag.ToString()) + '\t'
                        + "Thích ");
            sw.Close();
        }

        private void post_video()
        {
            string filepath = $"{address}users\\{lb_username.Text}";
            copyFile(video.Tag.ToString(), $"{filepath}\\post");
            using (StreamWriter sw = new StreamWriter($"{address}users\\{lb_username.Text}\\post\\post.txt",true))
            {
                if (richTextBox1.Text == null)
                {
                    richTextBox1.Text = " ";
                }
                sw.WriteLine(lb_username.Text + '\t'
                            + btn_post.Tag.ToString() + '\t'
                            + cb_quyen.Text + '\t'
                            + $"{date.Day} thg {date.Month}, {date.Year}" + '\t'
                            + richTextBox1.Text + '\t'
                            + Path.GetFileName(video.Tag.ToString()) + '\t'
                            + "Thích ");
                sw.Close();
            }
         
        }
        private void post_text()
        {
            string filepath = $"{address}users\\{lb_username.Text}";
            using (StreamWriter sw = new StreamWriter($"{address}users\\{lb_username.Text}\\post\\post.txt",true))
            {
                if (richTextBox1.Text == null)
                {
                    richTextBox1.Text = " ";
                }
                sw.WriteLine(lb_username.Text + '\t'
                            + btn_post.Tag.ToString() + '\t'
                            + cb_quyen.Text + '\t'
                            + $"{date.Day} thg {date.Month}, {date.Year}" + '\t'
                            + richTextBox1.Text + '\t'
                            + "" + '\t'
                            + "Thích ");
                sw.Close();
            }
                
        }
        private void btn_post_Click(object sender, EventArgs e)
        {
            //i = 0;
            if (btn_post.Tag.ToString() == "image")
            {
                feeds_image dv = new feeds_image
                {
                    User = btn_user.Image,
                    username = lb_username.Text,
                    image = pictureBox3.Image,
                    text = richTextBox1.Text,
                    date = $"{date.Day} thg {date.Month}, {date.Year}",
                    tag = Path.GetFileName(pictureBox3.Tag.ToString())
                };
                post_image();

                if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                else { flowLayoutPanel2.Controls.Add(dv); }
                pic_background.Tag = "0";
                picProfile2.Tag = "0";
            }
            else if (btn_post.Tag.ToString() == "video")
            {
                feeds_video dv = new feeds_video
                {
                    User = btn_user.Image,
                    username = lb_username.Text,
                    text = richTextBox1.Text,
                    date = $"{date.Day} thg {date.Month}, {date.Year}",
                    url = video.Tag.ToString(),
                    tag = Path.GetFileName(video.Tag.ToString())

                };
                post_video();

                if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                else { flowLayoutPanel2.Controls.Add(dv); }
            }
            else if(btn_post.Tag.ToString() == "Text")
            {
                feeds_text dv = new feeds_text
                {
                    User = btn_user.Image,
                    username = lb_username.Text,
                    text = richTextBox1.Text,
                    date = $"{date.Day} thg {date.Month}, {date.Year}",
                    Tag = richTextBox1.Text
                };
                post_text();
                if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                else { flowLayoutPanel2.Controls.Add(dv); }
            }

        }
        #endregion
        private void btn_home_Click(object sender, EventArgs e)
        {           
            panel_home.Visible = true;
            panel_post.Visible = false;
            panel_profile.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_post.Visible = true;
            panel_home.Visible = false;
            panel_profile.Visible = false;
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            panel_profile.Visible = true;
            panel_post.Visible = false;
            panel_home.Visible = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }
        private void pic_back_Click(object sender, EventArgs e)
        {
            panel_post.Visible = false;
            picProfile2.Tag = "0";
            pic_background.Tag = "0";
            btn_post.Tag = "Text";
        }

        private void btn_friend_Click(object sender, EventArgs e)
        {
            flowLayoutPanel3.Controls.Clear();
            Read_friend_request();
            panel_friend.Visible = true;
        }

        private void link_xóa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            video.URL = null;   pictureBox3.Image = null;   btn_post.Tag = "Text";  video.Visible = false;  pictureBox3.Visible = false;
        }

        bool isEnable = true;
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (isEnable == true)
            {
                flowLayoutPanel4.Visible = true; isEnable = false;
            }
            else
            { flowLayoutPanel4.Visible = false;isEnable = true; }
            
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
