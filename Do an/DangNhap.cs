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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Do_an
{
    public partial class DangNhap : Form
    {
        DataTable dt = new DataTable();
        DateTime date = DateTime.Now;
        string username = "";

        string address = "E:\\LapTrinh\\PROJECT\\c#\\Do an\\Do an\\";
        public DangNhap()
        {
            InitializeComponent();
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
        /*void Readfile()
        {
            dt = new DataTable();
            dt.Columns.Add("Name", typeof(string)); ;
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("Birth", typeof(string));
            dt.Columns.Add("Sex", typeof(string));
            dt.Columns.Add("Profile", typeof(string));
            dt.Columns.Add("Background", typeof(string));
            string tenfile = "user.txt";
            FileInfo f = new FileInfo(tenfile);
      
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
                
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] st = str.Split('\t');
                    dt.Rows.Add(st[0], st[1], st[2], st[3], st[4], st[5], st[6]);
                }
                
                sr.Close();
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[1].HeaderText = "email";
            dataGridView1.Columns[2].HeaderText = "password";
            dataGridView1.Columns[3].HeaderText = "Birth";
            dataGridView1.Columns[4].HeaderText = "Sex";
            dataGridView1.Columns[5].HeaderText = "Profile";
            dataGridView1.Columns[6].HeaderText = "Background";
        }*/
        private bool UserExists(string email, string password)
        {
            //Kiểm email và password
            string tenfile = "user.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);

                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] st = str.Split('\t');
                    if (email == st[1] && password == st[2])
                    {          
                        username = st[0];
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
            else if (UserExists(email, password))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 f1 = new Form1(username);
                f1.Show();
                Close();
                

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
                
                string s = ten + '\t' + txt_email_DK.Text + '\t' + txt_mk_DK.Text + '\t' + birth + '\t' + sx +'\t' + "profile.jpg" + '\t' + "gray.png" ;
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
                w = new StreamWriter($"{address}users\\{ten}\\post\\chat.txt");
                w.Close();

                //Readfile(ten, email, mk, birth, sx, "profile.jpg", "gray.png");
                dataGridView1.Update();
                dataGridView1.Refresh();
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

        private void eye(PictureBox pic1, PictureBox pic2, TextBox txt, char a)
        {
            pic1.Visible = false;
            pic2.Visible = true;
            if (txt.Text != "Mật khẩu")
            { txt.PasswordChar = a; }

        }
        private void pic_eyeClose_Click(object sender, EventArgs e)
        {
            eye(pic_eyeClose, pic_eyeOpen, txt_mk_DN, '\0');
        }

        private void pic_eyeOpen_Click(object sender, EventArgs e)
        {
            eye(pic_eyeOpen, pic_eyeClose, txt_mk_DN, '*');
        }

        private void lb_forgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pass_forgot f = new pass_forgot();
            f.Show();
        }
    }
}
