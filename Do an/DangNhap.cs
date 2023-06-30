using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Do_an
{
    public partial class DangNhap : Form
    {
        DateTime date = DateTime.Now;
        string username = "";
        static string fileLocation()
        {
            string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
            string parentFolder = Directory.GetParent(projectFolder).FullName;
            string projectFolderPath = Directory.GetParent(parentFolder).FullName;
            string parent = Directory.GetParent(projectFolderPath).FullName;
            return parent;
        }
        
        public static string address = $"{fileLocation()}\\";
        
        public DangNhap()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            ActiveControl = pictureBox1;
            panel1.Visible = true;
            panel_DK.Visible = false;
            cb_day.Text = date.Day.ToString();
            cb_month.Text = $"Tháng {date.Month}";
            cb_year.Text = date.Year.ToString();

        }
        private string word_search(string word_found, char a)
        {
            string[] str = word_found.ToString().Trim().ToLower().Split(a);
            return str[1];
        }
        #region Tìm user qua database
        private void Readfile()
        {
            string tenfile = "user.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);

                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] st = str.Split('\t');
                    if (txt_email_DN.Text == st[1])
                    {
                        username = st[0];
                    }
                }
                sr.Close();
            }
        }
        private bool UserExists(string password)
        {
            //Kiểm email và password
            Readfile();
            string tenfile = $"{address}users\\{username}\\thongtin.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);

                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    if (password == str)
                    {          
                        return true;
                    }
                }
                sr.Close();
            }
            return false;
        }
        void writefile(string s, string file)
        {
            //Save dữ liệu vào file user.txt
            StreamWriter sw = new StreamWriter(file, true);
            sw.WriteLine(s);
            sw.Close();
        }
        #endregion

        #region Đăng nhập
        private void dangnhap()
        {
            string email = txt_email_DN.Text.Trim();
            string password = txt_mk_DN.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || email == "Email/Tên đăng nhập" || password == "Mật khẩu")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (UserExists(password))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 f1 = new Form1(username);
                f1.Show();
                Hide();

                //StreamReader r = new StreamReader()
            }
            else MessageBox.Show("Đăng nhập sai, vui lòng thử lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btn_DN_Click(object sender, EventArgs e)
        {
            dangnhap();
        }
        private void btn_DN_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dangnhap();
            }    
        }
        #endregion
        private void copyFile(string source, string destination)
        {
            string filename = Path.GetFileName(source);
            string destinationFilePath = Path.Combine(destination, filename);

            File.Copy(source, destinationFilePath, true);
        }
        #region Đăng ký
        private void btn_DK_Click(object sender, EventArgs e)
        {
            string ten = $"{txt_ho_DK.Text} {txt_ten_DK.Text}";
            string email = txt_email_DK.Text;
            string mk = txt_mk_DK.Text;
            string birth = $"{cb_day.Text}/{word_search(cb_month.Text, ' ')}/{cb_year.Text}";
            string sx = "";
            
            //Xét thông tin tài khoản đang tạo có trùng với tài khoản đã tạo không?

            if (ten != "" && ten != "Họ Tên" && email != "" && email != "Số di động hoặc email" && mk != "" && mk != "Mật khẩu mới" && check1.Checked != false || check2.Checked != false)
            {
                string tenfile = "user.txt";
                FileInfo f = new FileInfo(tenfile);
                if (f.Exists)
                {
                    StreamReader sr = new StreamReader(tenfile);

                    string a;
                    while ((a = sr.ReadLine()) != null)
                    {
                        string[] st = a.Split('\t');
                        if (ten == st[0])
                        {
                            MessageBox.Show("Đã có tài khoản sử dụng tên này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (email == st[1])
                        {
                            MessageBox.Show("Đã có tài khoản sử dụng email này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    sr.Close();
                }
                if (Int32.Parse(cb_year.Text) > 2018)
                {
                    MessageBox.Show("Vui lòng nhập đúng năm sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (check1.Checked) { sx = check1.Text; } if(check2.Checked) { sx = check2.Text; }
                
                string s = ten + '\t' + txt_email_DK.Text ;
                writefile(s, "user.txt");

                MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel_DK.Visible = false;
                Directory.CreateDirectory(address + "users\\" + ten);
                StreamWriter w = new StreamWriter(address + "users\\" + ten + "\\thongtin.txt");
                w.WriteLine(ten);   w.WriteLine(email); w.WriteLine(mk);    w.WriteLine(birth); w.WriteLine(sx);
                w.Close();
                StreamReader r = new StreamReader(address + "users"  + "\\dangki.txt");
                string str = r.ReadToEnd();
                r.Close();
                w = new StreamWriter(address + "users" + "\\dangki.txt");
                if (str!= "")
                {
                    w.WriteLine(str);
                }    
                w.Write(ten + "\n");
                w.WriteLine(email + "\t" + mk);
               
                w.Close();
                w = new StreamWriter(address + "users\\" + ten + "\\profile.txt");
                w.WriteLine("profile.jpg");
                w.Close();
                w = new StreamWriter(address + "users\\" + ten + "\\background.txt");
                w.WriteLine("gray.png");
                w.Close();
                Directory.CreateDirectory($"{address}users\\{ten}\\post");
                w = new StreamWriter($"{address}users\\{ten}\\post\\post.txt");
                w.Close();
                Directory.CreateDirectory($"{address}users\\{ten}\\chat");
                w = new StreamWriter($"{address}users\\{ten}\\chat\\chat.txt");
                w.Close();
                Directory.CreateDirectory($"{address}users\\{ten}\\friend");
                w = new StreamWriter($"{address}users\\{ten}\\friend\\friend.txt");
                w.Close();
                w = new StreamWriter($"{address}users\\{ten}\\friend\\sent_request.txt");
                w.Close();
                Directory.CreateDirectory($"{address}users\\{ten}\\notification");
                w = new StreamWriter($"{address}users\\{ten}\\notification\\notification.txt");
                w.Close();

                copyFile("profile.jpg", $"{address}users\\{ten}\\post\\");
                copyFile("gray.png", $"{address}users\\{ten}\\post\\");

                //Readfile(ten, email, mk, birth, sx, "profile.jpg", "gray.png");
            }
            else MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region placeholder
        private void placeholder(TextBox tb, string s1, string s2, Color color)
        {
            if (tb.Text == s1)
            {
                tb.Text = s2;
                tb.ForeColor = color;
            }
        }
        private void txt_email_DN_Enter(object sender, EventArgs e)
        {
            placeholder(txt_email_DN, "Email hoặc số điện thoại", "", Color.Black);
        }

        private void txt_email_DN_Leave(object sender, EventArgs e)
        {
            placeholder(txt_email_DN, "", "Email hoặc số điện thoại", Color.Gray);
        }

        private void txt_mk_DN_Enter(object sender, EventArgs e)
        {
            placeholder(txt_mk_DN, "Mật khẩu", "", Color.Black);
        }

        private void txt_mk_DN_Leave(object sender, EventArgs e)
        {
            placeholder(txt_mk_DN, "", "Mật khẩu", Color.Gray);
        }
        private void txt_ho_DK_Enter(object sender, EventArgs e)
        {
            placeholder(txt_ho_DK, "Họ", "", Color.Black);
        }

        private void txt_ho_DK_Leave(object sender, EventArgs e)
        {
            placeholder(txt_ho_DK, "", "Họ", Color.Gray);
        }

        private void txt_ten_DK_Enter(object sender, EventArgs e)
        {
            placeholder(txt_ten_DK, "Tên", "", Color.Black);
        }

        private void txt_ten_DK_Leave(object sender, EventArgs e)
        {
            placeholder(txt_ten_DK, "", "Tên", Color.Gray);
        }

        private void txt_email_DK_Enter(object sender, EventArgs e)
        {
            placeholder(txt_email_DK, "Số di động hoặc email", "", Color.Black);
        }

        private void txt_email_DK_Leave(object sender, EventArgs e)
        {
            placeholder(txt_email_DK, "", "Số di động hoặc email", Color.Gray);
        }

        private void txt_mk_DK_Enter(object sender, EventArgs e)
        {
            placeholder(txt_mk_DK, "Mật khẩu mới", "", Color.Black);
        }

        private void txt_mk_DK_Leave(object sender, EventArgs e)
        {
            placeholder(txt_mk_DK, "", "Mật khẩu mới", Color.Gray);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel_DK.Visible = false;
        }

        private void btn_taoTK_Click(object sender, EventArgs e)
        {
            panel_DK.Visible = true;
        }
        #endregion

        private void radioButton1_Click(object sender, EventArgs e)
        {
            check1.Checked = true;
            check2.Checked = false;
        }
        private void radioButton4_Click(object sender, EventArgs e)
        {
            check1.Checked = false;
            check2.Checked = true;
        }

        bool enabled = true;
        private void pic_eyeClose_Click(object sender, EventArgs e)
        {
            if(txt_mk_DN.Text != "Mật khẩu")
            {
                if (enabled == true)
                {
                    pic_eyeClose.Image = Image.FromFile($"{Form1.path}\\icon\\8541830_eye_slash_icon.png");
                    txt_mk_DN.PasswordChar = '*';
                    enabled = false;
                }
                else
                {
                    pic_eyeClose.Image = Image.FromFile($"{Form1.path}\\icon\\8541829_eye_vision_view_icon.png");
                    txt_mk_DN.PasswordChar = '\0';
                    enabled = true;
                }
            }       
        }

        private void lb_forgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pass_forgot f = new pass_forgot();
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
