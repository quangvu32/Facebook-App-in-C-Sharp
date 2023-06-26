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
using System.Net.Mail;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Do_an
{
    public partial class pass_forgot : Form
    {
        string user;
        public pass_forgot()
        {
            InitializeComponent();
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }
        private void pass_forgot_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;
        }
        private void btn_huy_Click(object sender, EventArgs e)
        {
            Close(); Dispose(true);
        }

        private void btn_tiep_Click(object sender, EventArgs e)
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
                    if (txt_email.Text == st[1])
                    {
                        user = st[0];
                        if (txt_email.Text[0] == '0')
                        {
                            label3.Text = "Gửi qua số điện thoại"; label6.Text = st[1]; label6.Tag = "sdt";
                            panel1.Visible = false; panel2.Visible = true;
                            return;
                        }
                        else
                        {
                            label3.Text = "Gửi qua mail"; label6.Text = st[1]; label6.Tag = "mail";
                            panel1.Visible = false; panel2.Visible = true;
                            return;
                        }
                    }
                }
                pic_user.Image = Image.FromFile($"{Form1.address}users//{user}//profile.txt");
                label9.Text = user;
                
                sr.Close();
                if (txt_email.Text == "Email hoặc số điện thoại")
                {
                    MessageBox.Show("Vui lòng nhập Email hoặc số điện thoại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
                else MessageBox.Show("Tài khoản không tồn tại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
        }

        private void btn_huy2_Click(object sender, EventArgs e)
        {
            txt_email.Text = "Email hoặc số điện thoại";
            panel1.Visible = true;panel2.Visible = false;
            placeholder(txt_email, "", "Email hoặc số điện thoại", Color.Gray);
        }
        private void placeholder(TextBox tb, string s1, string s2, Color color)
        {
            if (tb.Text == s1)
            {
                tb.Text = s2;
                tb.ForeColor = color;
            }
        }
        private void txt_email_Enter(object sender, EventArgs e)
        {
            placeholder(txt_email, "Email hoặc số điện thoại", "", Color.Black);
        }

        private void txt_email_Leave(object sender, EventArgs e)
        {
            placeholder(txt_email, "", "Email hoặc số điện thoại", Color.Gray);
        }

        int randomNumber = 0;
        private void mail()
        {
            Random random = new Random();

            randomNumber = random.Next(100000, 999999);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(txt_email.Text);
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(mail.From.Address, "yfranxnsnohoqakk");
            smtp.Host = "smtp.gmail.com";

            //recipient
            mail.To.Add(new MailAddress(txt_email.Text));
            mail.IsBodyHtml = true;
            mail.Subject = "Gửi mã xác nhận";
            mail.Body = $"Mã xác nhận: {randomNumber}";

            smtp.Send(mail);
            MessageBox.Show("Gửi Email thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void phone()
        {
            Random random = new Random();

            randomNumber = random.Next(100000, 999999);
        }
        private void btn_tiep2_Click(object sender, EventArgs e)
        {
            if(label6.Tag.ToString() == "mail") { mail(); }
            panel2.Visible = false; panel3.Visible = true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            placeholder(txt_code, "Nhập mã", "", Color.Black);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            placeholder(txt_code, "", "Nhập mã", Color.Gray);
        }

        private void ReadFile()
        {
            string tenfile = $"{DangNhap.address}users\\{user}\\thongtin.txt";
            FileInfo f = new FileInfo(tenfile);
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
                string str;
                string s1 = "";
                string s2 = "";
                while ((str = sr.ReadLine()) != null)
                {
                    if (str == txt_email.Text)
                    {
                        str = sr.ReadLine();
                        s1 = str;
                        s2 = txt_newPass.Text;
                        break;
                    }
                }
                sr.Close();
                string fileContent = File.ReadAllText(tenfile);
                string update = fileContent.Replace(s1, s2);
                File.WriteAllText(tenfile, update);
                        
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(txt_code.Text == randomNumber.ToString() )
            {
                MessageBox.Show("Nhập mã thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel3.Visible = false; panel4.Visible = true;
            }    
            else MessageBox.Show("Nhập mã thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txt_newPass_Enter(object sender, EventArgs e)
        {
            placeholder(txt_newPass, "Mật khẩu mới", "", Color.Black);
        }

        private void txt_newPass_Leave(object sender, EventArgs e)
        {
            placeholder(txt_newPass, "", "Mật khẩu mới", Color.Gray);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReadFile();
            MessageBox.Show("Mật khẩu mới được tạo thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();
            Close(); Dispose(true);
        }
    }
}
