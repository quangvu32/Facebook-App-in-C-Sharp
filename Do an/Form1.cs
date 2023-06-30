using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Channels;
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
            panel_post.Visible = false; panel_home.Visible = true; panel_profile.Visible = false; panel_friend.Visible = false; panel5.Visible = false;
            username_get = username;
            lb_username.Text = username;

            picProfile2.Tag = "0";
            pic_background.Tag = "0";
            btn_post.Tag = "Text";
            video.OpenStateChange += AxWindowsMediaPlayer1_OpenStateChange;
            cb_quyen.Text = "Công khai";
            video.uiMode = "none";
            video.Visible = false;
            pictureBox3.Visible = false;
            flowLayoutPanel4.Visible = false;
            flowLayoutPanel5.Visible = false;
            flowLayoutPanel6.Visible = false;

            guna2GradientButton2.FillColor = Color.Silver;
            //guna2GradientButton1.FillColor = Color.WhiteSmoke;

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
        private void lb_dangxuat_MouseEnter(object sender, EventArgs e)
        {

        }

        private void lb_dangxuat_MouseLeave(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel4.Controls.Clear();
            flowLayoutPanel5.Controls.Clear();

            Readfile_prof();         
            Readfile_Profpost();
            Read_friend_request();
            Readfile_notif();
            
            post p = new post();
            p.Image = read_profile(lb_username.Text);
            p.ButtonClicked += button1_Click;
            flowLayoutPanel1.Controls.Add(p);
            Readfile_post();
            picProfile.Image = btn_user.Image;
            picProfile3.Image = btn_user.Image;
        }
        private void AxWindowsMediaPlayer1_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            if ((WMPLib.WMPOpenState)e.newState == WMPLib.WMPOpenState.wmposMediaOpen)
            {
                video.Ctlcontrols.pause();
            }
        }
        List<int> listNumbers = new List<int>();//Create a list of random questions (no repeatable)
        private void random(int posts)
        {
            listNumbers = new List<int>();
            Random rnd = new Random();
            int number;
            for (int i = 0; i < posts; i++)
            {
                do
                {
                    number = rnd.Next(0, 4);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }
        }
        List<string> friends = new List<string>();
        private void friend_count()
        {
            friends = new List<string>();
            string tenfile_friend = $"{address}users\\{lb_username.Text}\\friend\\friend.txt";
            StreamReader r = new StreamReader(tenfile_friend);
            string friend_name;
            while ((friend_name = r.ReadLine()) != null)
            {
                friend fr = new friend();
                fr.User = friend_name;
                fr.profile = read_profile(friend_name);
                friends.Add(friend_name);
                if (flowLayoutPanel5.Controls.Count < 0) { flowLayoutPanel5.Controls.Clear(); }
                else { flowLayoutPanel5.Controls.Add(fr); }
            }
            r.Close();
        }
        private Image cong_khai(string a)
        {
            if(a == "Bạn bè")
            {
                return Image.FromFile(Path.Combine($"{path}\\icon\\", "friend.png"));
            }  
            if(a == "Công khai")
            {
                return Image.FromFile(Path.Combine($"{path}\\icon\\", "world.png")); 
            }    
            return Image.FromFile(Path.Combine($"{path}\\icon\\", "lock.png"));
        }
        
        private void get_posts()
        {
            File.WriteAllText($"{address}users\\{lb_username.Text}\\post\\post_all.txt", string.Empty);
            random(4);
            List<string> posts = new List<string>();
            string tenfile_friend = $"{address}users\\{lb_username.Text}\\friend\\friend.txt";
            StreamReader r = new StreamReader(tenfile_friend);
            string friend_name;
            if (friends.Count > 0)
            {
                while ((friend_name = r.ReadLine()) != null)
                {
                    string tenfile = $"{address}users\\{friend_name}\\post\\post.txt";
                    StreamReader sr = new StreamReader(tenfile);
                    string str;
                    while ((str = sr.ReadLine()) != null)
                    {
                        posts.Add(str);
                    }
                    if (posts.Count < 0) { break; }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            StreamWriter sw = new StreamWriter($"{address}users\\{lb_username.Text}\\post\\post_all.txt", true);
                            sw.WriteLine(posts[listNumbers[i]]);
                            sw.Close();
                        }
                    }

                    posts.Clear();
                }
            }
            r.Close();
        }
        private Image read_profile(string name)
        {
            string profile = $"{address}users\\{name}\\profile.txt";
            string image;
            StreamReader r = new StreamReader(profile);
            image = r.ReadLine();
            r.Close();
            Image a = Image.FromFile($"{address}users\\{name}\\post\\{image}");
            return a;
        }
        private void Readfile_post()
        {
            //get_posts();
            string tenfile = $"{address}users\\{lb_username.Text}\\post\\post_all.txt";
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
                            image = Image.FromFile($"{address}users\\{st[0]}\\post\\{st[5]}"),
                            text = st[4],
                            date = st[3],
                            reaction = st[6],
                            tag = st[5],
                            User = read_profile(st[0]),
                            trangthai = cong_khai(st[2]),
                            
                        };
                        if (flowLayoutPanel1.Controls.Count < 0) { flowLayoutPanel1.Controls.Clear(); }
                        else { flowLayoutPanel1.Controls.Add(dv); }
                    }
                    else if (st[1] == "video")
                    {
                        feeds_video v = new feeds_video
                        {
                            username = st[0],
                            url = $"{address}users\\{st[0]}\\post\\{st[5]}",
                            text = st[4],
                            date = st[3],
                            reaction = st[6],
                            tag = st[5],
                            User = read_profile(st[0]),
                            trangthai = cong_khai(st[2]),
                        };
                        if (flowLayoutPanel1.Controls.Count < 0) { flowLayoutPanel1.Controls.Clear(); }
                        else { flowLayoutPanel1.Controls.Add(v); }
                    }
                    else
                    {
                        feeds_text t = new feeds_text
                        {
                            username = st[0],
                            text = st[4],
                            date = st[3],
                            reaction = st[6],
                            User = read_profile(st[0]),
                            Tag = st[4],
                            trangthai = cong_khai(st[2]),
                        };
                        if (flowLayoutPanel1.Controls.Count < 0) { flowLayoutPanel1.Controls.Clear(); }
                        else { flowLayoutPanel1.Controls.Add(t); }
                    }
                }
                sr.Close();
            }

        }
        private void Readfile_prof()
        {
            string profile = $"{address}users\\{lb_username.Text}\\profile.txt";
            string background = $"{address}users\\{lb_username.Text}\\background.txt";
            string image = ""; string image2 = "";
            FileInfo f = new FileInfo(profile);

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

            btn_user.Image = bg.Image;
            if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
            else { flowLayoutPanel2.Controls.Add(bg); }
            post p = new post();
            p.Image = Image.FromFile(Path.Combine($"{address}users\\{lb_username.Text}\\post\\", image));
            flowLayoutPanel2.Controls.Add(p);
            bg.ButtonClicked += guna2CirclePictureBox_profile_Click;
            bg.ButtonClicked2 += pic_background_Click;
            p.ButtonClicked += button1_Click;
        }
    
        List<string> users = new List<string>();
        private void Read_friend_request()
        {
            users = new List<string>();
            string tenfile = "user.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
                string str;
                StreamReader r = new StreamReader($"{address}users\\{lb_username.Text}\\friend\\friend.txt");
                string str1;
                str1 = r.ReadToEnd();
                r.Close();

                if (str1 == string.Empty)
                {
                    while ((str = sr.ReadLine()) != null)
                    {
                        string p;
                        string[] st = str.Split('\t');

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
                        dv.ButtonClicked_delete += btnDelete_clicked;
                        dv.ButtonClicked_delete2 += btnDelete2_clicked;
                        //r.Close();
                    }
                    sr.Close();
                }
                else
                {
                    while ((str = sr.ReadLine()) != null)
                    {
                        
                        string[] st = str.Split('\t');
                        //r = new StreamReader($"{address}users\\{lb_username.Text}\\friend\\friend.txt");
                        users.Add(st[0]);           
                        //r.Close();
                    }
                    sr.Close();
                    friend_count();
                    friends.Add(lb_username.Text);
                    //friends.Add("Nguyễn Minh Thi");
                    List<string> list = users.Except(friends).ToList();
                    foreach(string user in list)
                    {
                        string p;
                        StreamReader a = new StreamReader($"{address}users\\{user}\\profile.txt");
                        p = a.ReadLine();
                        friend_find dv = new friend_find()
                        {
                            User = user,
                            profile = Image.FromFile($"{address}users\\{user}\\post\\{p}"),
                        };
                        a.Close();
                        if (flowLayoutPanel3.Controls.Count < 0) { flowLayoutPanel3.Controls.Clear(); }
                        else { flowLayoutPanel3.Controls.Add(dv); }
                        dv.ButtonClicked += btn_clicked;
                        dv.ButtonClicked3 += btn_clicked3;
                        dv.ButtonClicked_delete += btnDelete_clicked;
                        dv.ButtonClicked_delete2 += btnDelete2_clicked;
                    }    
                   
                }
                
                
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
        private void btnDelete_clicked(object sender, EventArgs e)
        {
            friend_find friend_find = sender as friend_find;
            friend_find.delete_sent();
        }
        private void btnDelete2_clicked(object sender, EventArgs e)
        {
            friend_find friend_find = sender as friend_find;
            friend_find.delete_request();
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
                            User = btn_user.Image,
                            trangthai = cong_khai(st[2])
                        };
                        dv.Button_delete += btnImage_delete;

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
                            User = btn_user.Image,
                            trangthai = cong_khai(st[2])
                        };
                        v.Button_delete += btnVideo_delete;
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
                            Tag = st[4],
                            trangthai = cong_khai(st[2])
                        };
                        t.button_delete += btnText_delete;
                        if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                        else { flowLayoutPanel2.Controls.Add(t); }
                    }
                }
                sr.Close();
            }
        }
        private void btnImage_delete(object sender, EventArgs e)
        {
            feeds_image click = sender as feeds_image;
            click.delete();flowLayoutPanel2.Controls.Clear();
            Readfile_Profpost();
        }
        private void btnText_delete(object sender, EventArgs e)
        {
            feeds_text click = sender as feeds_text;
            click.delete(); flowLayoutPanel2.Controls.Clear();
            Readfile_Profpost();
        }
        private void btnVideo_delete(object sender, EventArgs e)
        {
            feeds_video click = sender as feeds_video;
            click.delete(); flowLayoutPanel2.Controls.Clear();
            Readfile_Profpost();
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
                        profile = Image.FromFile($"{address}users\\{st[0]}\\post\\{image}"),
                        date = st[2]
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
        public static void delete(string txtfile, string item)
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
            if (picProfile2.Tag.ToString() == "0" && pic_background.Tag.ToString() == "0")
            {
                if (cb_quyen.Text == "Công khai" || cb_quyen.Text == "Bạn bè")
                {
                    sw = new StreamWriter($"{address}users\\{label1.Text}\\notification\\notification.txt", true);
                    sw.WriteLine(lb_username.Text + "\t" + "đã đăng ảnh vào" + "\t" + $"{date.Day} thg {date.Month}, {date.Year}");                    
                }
            }
            else
            {
                if (picProfile2.Tag.ToString() == "1" && (cb_quyen.Text == "Công khai" || cb_quyen.Text == "Bạn bè"))
                {
                    sw = new StreamWriter($"{address}users\\{label1.Text}\\notification\\notification.txt", true);
                    sw.WriteLine(lb_username.Text + "\t" + "đã cập nhật ảnh đại diện vào" + "\t" + $"{date.Day} thg {date.Month}, {date.Year}");
                }
                if (pic_background.Tag.ToString() == "1" && (cb_quyen.Text == "Công khai" || cb_quyen.Text == "Bạn bè"))
                {
                    sw = new StreamWriter($"{address}users\\{label1.Text}\\notification\\notification.txt", true);
                    sw.WriteLine(lb_username.Text + "\t" + "đã cập nhật ảnh bìa vào" + "\t" + $"{date.Day} thg {date.Month}, {date.Year}");
                }
            }    
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

                StreamWriter w = new StreamWriter($"{address}users\\{label1.Text}\\notification\\notification.txt", true);
                w.WriteLine(lb_username.Text + "\t" + "đã đăng video vào" + "\t" + $"{date.Day} thg {date.Month}, {date.Year}");
                w.Close();
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
                StreamWriter w = new StreamWriter($"{address}users\\{label1.Text}\\notification\\notification.txt", true);
                w.WriteLine(lb_username.Text + "\t" + "đã đăng dòng caption vào" + "\t" + $"{date.Day} thg {date.Month}, {date.Year}");
                w.Close();
            }
                
        }
        private void btn_post_Click(object sender, EventArgs e)
        {
            video.URL = null;   pictureBox3.Image = null;   btn_post.Tag = "Text";  video.Visible = false;  pictureBox3.Visible = false;
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
            panel_friend.Visible = false;
            flowLayoutPanel6.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_post.BringToFront();
            panel_post.Visible = true;
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            panel_profile.Visible = true;
            panel_post.Visible = false;
            panel_home.Visible = false;
            panel_friend.Visible = false;
            flowLayoutPanel6.Visible = false;
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
            panel_home.Visible=false;
            panel_post.Visible=false;
            panel_profile.Visible=false;
            panel_friend.Visible = true;
            flowLayoutPanel6.Visible = true;
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
                flowLayoutPanel4.Visible = true; flowLayoutPanel4.BringToFront(); isEnable = false;
            }
            else
            { flowLayoutPanel4.Visible = false;isEnable = true; }
            
            
        }

        bool enabled = true;
        private void pic_option_Click(object sender, EventArgs e)
        {
            if(enabled == true){panel5.Visible = true;enabled = false;}    
            else { panel5.Visible = false; enabled = true; }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            guna2GradientButton1.FillColor = Color.Silver;
            guna2GradientButton2.FillColor = Color.WhiteSmoke;
            flowLayoutPanel3.Visible = false;
            flowLayoutPanel5.Visible = true;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            guna2GradientButton2.FillColor = Color.Silver;
            guna2GradientButton1.FillColor = Color.WhiteSmoke;
            flowLayoutPanel3.Visible = true;
            flowLayoutPanel5.Visible = false;
        }
        private void Item_Click(object sender, EventArgs e)
        {
            flowLayoutPanel6.Controls.Clear();
            friend clickedUserControl = sender as friend;
            if (clickedUserControl != null)
            {
                string profile = $"{address}users\\{clickedUserControl.User}\\profile.txt";
                string background = $"{address}users\\{clickedUserControl.User}\\background.txt";
                string image = ""; string image2 = "";
                FileInfo f = new FileInfo(profile);

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
                    Image = Image.FromFile(Path.Combine($"{address}users\\{clickedUserControl.User}\\post\\", image)),
                    Image2 = Image.FromFile(Path.Combine($"{address}users\\{clickedUserControl.User}\\post\\", image2)),
                    User = clickedUserControl.User,
                };
                if (flowLayoutPanel6.Controls.Count < 0) { flowLayoutPanel6.Controls.Clear(); }
                else { flowLayoutPanel6.Controls.Add(bg); }
            }
        }
        private void flowLayoutPanel5_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Click += new EventHandler(Item_Click);
        }

        private void flowLayoutPanel3_ControlAdded(object sender, ControlEventArgs e)
        {
            //e.Control.Click += new EventHandler(Item_Click);
        }
    }
}
