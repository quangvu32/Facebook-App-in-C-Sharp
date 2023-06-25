using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Do_an
{
    public partial class Form1 : Form
    {
        static string fileLocation()
        {
            string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
            string parentFolder = Directory.GetParent(projectFolder).FullName;
            string projectFolderPath = Directory.GetParent(parentFolder).FullName;
            string parent = Directory.GetParent(projectFolderPath).FullName;
            return parent;
        }
        DateTime date = DateTime.Now;
        string address = $"{fileLocation()}\\";

        public Form1(string username)
        {
            InitializeComponent();
            lb_username.Text = username;
            //StreamReader r = new StreamReader();
        }
        private string _reaction;
        public string reaction
        {
            get { return _reaction; }
            set { _reaction = value; }
        }
        private void lb_dangxuat_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //populate_item(flowLayoutPanel1);
            //populate_item(flowLayoutPanel1);
            //populate_item(flowLayoutPanel1);
            panel_post.Visible = false;
            panel_home.Visible = true;
            panel_profile.Visible = false;
            panel_friend.Visible = false;
            
            cb_quyen.Text = "Bạn bè";
            video.uiMode = "none";
            picProfile2.Tag = "0";
            pic_background.Tag = "0";
            Readfile_profile("profile.txt", picProfile2);
            Readfile_profile("background.txt", pic_background);
            Readfile_post();

        }

        private void Readfile_profile(string a, PictureBox p)
        {
            string tenfile = address + "users\\" + lb_username.Text + $"\\{a}";
            string image = "";
           FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
               image = sr.ReadLine();
                sr.Close();    
            }
            p.Image = Image.FromFile(Path.Combine($"{address}users\\{lb_username.Text}\\post\\", image));
            if (p == picProfile2)
            {
                picProfile.Image = p.Image; picProfile3.Image = p.Image;
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
                            User = picProfile2.Image
                        };

                        if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                        else { flowLayoutPanel2.Controls.Add(dv); }
                    }
                    if (st[1] == "video")
                    {
                        feeds_video dv = new feeds_video
                        {
                            username = st[0],
                            url = $"{address}users\\{lb_username.Text}\\post\\{st[5]}",
                            text = st[4],
                            date = st[3],
                            reaction = st[6],
                            tag = st[5],
                            User = picProfile2.Image
                        };

                        if (flowLayoutPanel2.Controls.Count < 0) { flowLayoutPanel2.Controls.Clear(); }
                        else { flowLayoutPanel2.Controls.Add(dv); }
                    }
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
                //imagelist.ImageSize = new Size(100, 100);
                //imagelist.ColorDepth = ColorDepth.Depth32Bit;  
                pictureBox3.Image = Image.FromFile(Ofile.FileName);
                pictureBox3.Tag = Ofile.FileName;
                //imagelist.Images.Add(new Bitmap(Image.FromFile(Ofile.FileName)));
                //listView1.Items.Add("", i);
                //i++;
                //Readfile();
            }
            //listView1.LargeImageList = imagelist;
            //listView1.View = View.LargeIcon;
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
            StreamWriter sw = new StreamWriter($"{address}users\\{lb_username.Text}\\post\\post.txt", true);
            if (richTextBox1.Text == null)
            {
                richTextBox1.Text = " ";
            }
            if(picProfile2.Tag.ToString() == "1")
            {
                picProfile.Image = pictureBox3.Image; picProfile2.Image = pictureBox3.Image; picProfile3.Image = pictureBox3.Image;
                copyFile(pictureBox3.Tag.ToString(), $"{filepath}\\post");
                File.WriteAllText($"{filepath}\\profile.txt", Path.GetFileName(pictureBox3.Tag.ToString()));
            }   
            if(pic_background.Tag.ToString() == "1")
            {
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
            StreamWriter sw = new StreamWriter($"{address}users\\{lb_username.Text}\\post\\post.txt", true);
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

        private void btn_post_Click(object sender, EventArgs e)
        {
            //i = 0;
            if (btn_post.Tag.ToString() == "image")
            {
                feeds_image dv = new feeds_image
                {
                    User = picProfile2.Image,
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
            if (btn_post.Tag.ToString() == "video")
            {
                feeds_video dv = new feeds_video
                {
                    User = picProfile2.Image,
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
        }

        private void btn_friend_Click(object sender, EventArgs e)
        {
            panel_friend.Visible = true;
        }
    }
}
