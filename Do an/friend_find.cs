using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Do_an
{
    public partial class friend_find : UserControl
    {
        public event EventHandler ButtonClicked;
        public event EventHandler ButtonClicked2;
        public event EventHandler ButtonClicked3;
        DateTime date = DateTime.Now;
        public friend_find()
        {
            InitializeComponent();
        }
        private void friend_find_Load(object sender, EventArgs e)
        {
            Readfile_sent();
        }
        private string _user;
        private Image _profile;

        public string User
        {
            get { return _user; }
            set { _user = value; label1.Text = value; }
        }
        public Image profile
        {
            get { return _profile; }
            set { _profile = value; pic_profile.Image = value; }
        }

        private void pic_profile_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonClicked2?.Invoke(this, EventArgs.Empty);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.Font = new Font("Segoe UI", 18, FontStyle.Underline);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Font = new Font("Segoe UI", 18, FontStyle.Regular);
        }
        public void open_item()
        {
            string tenfile = Form1.address;
            panel1.Visible = false;panel2.Visible = true;panel3.Visible = false;
            StreamWriter sw = new StreamWriter($"{tenfile}users\\{Form1.username_get}\\friend\\sent_request.txt", true);
            sw.WriteLine(label1.Text + "\t" + "sent");
            sw.Close();
            sw = new StreamWriter($"{tenfile}users\\{label1.Text}\\friend\\sent_request.txt", true);
            sw.WriteLine(Form1.username_get + "\t" + "request");
            sw.Close();
            sw = new StreamWriter($"{tenfile}users\\{label1.Text}\\notification\\notification.txt", true);
            sw.WriteLine(Form1.username_get + "\t" + "đã gửi lời mời kết bạn" + "\t" + $"{date.Day} thg {date.Month}, {date.Year}");
            sw.Close();

        }

        private void Readfile_sent()
        {
            string tenfile = $"{Form1.address}users\\{Form1.username_get}\\friend\\sent_request.txt";
            FileInfo f = new FileInfo(tenfile);
            panel1.Visible = true;
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(tenfile);
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] st = str.Split('\t');
                    if (label1.Text == st[0])
                    {
                        if (st[1] == "sent")
                        {
                            panel1.Visible = false; panel3.Visible = false;
                            panel2.Visible = true; break;
                        }
                        else if (st[1] == "request")
                        {
                            panel1.Visible = false; panel2.Visible = false;
                            panel3.Visible = true;  break;
                        }
                        else panel1.Visible = true; 
                        panel3.Visible = false; panel2.Visible = false;
                        break;
                    }
                }
                sr.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonClicked3?.Invoke(this, EventArgs.Empty);
        }
        private void delete(string txtfile, string item)
        {
            //Delete a chosen item in txt file and update
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(txtfile).Where(l => l != item);
            File.WriteAllLines(tempFile, linesToKeep);
            File.Delete(txtfile);
            File.Move(tempFile, txtfile);
            File.WriteAllLines(txtfile, File.ReadLines(txtfile).Where(l => l != item).ToList());
        }
        public void item2()
        {
            string tenfile = Form1.address;

            panel1.Visible = false; panel3.Visible = true;
            StreamWriter sw = new StreamWriter($"{tenfile}users\\{Form1.username_get}\\friend\\friend.txt", true);
            sw.WriteLine(label1.Text);
            sw.Close();
            sw = new StreamWriter($"{tenfile}users\\{label1.Text}\\friend\\friend.txt", true);
            sw.WriteLine(Form1.username_get);
            sw.Close();
            sw = new StreamWriter($"{tenfile}users\\{label1.Text}\\notification\\notification.txt", true);
            sw.WriteLine(Form1.username_get + "\t" + "đã chấp nhận lời mời kết bạn" + "\t" + $"{date.Day} thg {date.Month}, {date.Year}");
            sw.Close();
            delete($"{tenfile}users\\{Form1.username_get}\\friend\\sent_request.txt", label1.Text + "\t" + "request");
            delete($"{tenfile}users\\{label1.Text}\\friend\\sent_request.txt", Form1.username_get + "\t" + "sent");
            label2.Text = "Đã kết bạn";
            panel3.Visible = false; panel2.Visible = true;
        }
        public event EventHandler ButtonClicked_delete2;
        private void button4_Click(object sender, EventArgs e)
        {
            ButtonClicked_delete2?.Invoke(this, EventArgs.Empty);
        }
        public void delete_request()
        {
            panel3.Visible = false; panel2.Visible = false;
            string tenfile = Form1.address;
            delete($"{tenfile}users\\{Form1.username_get}\\friend\\sent_request.txt", label1.Text + "\t" + "request");
            delete($"{tenfile}users\\{label1.Text}\\friend\\sent_request.txt", Form1.username_get + "\t" + "sent");
            delete($"{tenfile}users\\{Form1.username_get}\\notification\\notification.txt", label1.Text + "\t" + "đã gửi lời mời kết bạn" + "\t" + $"{date.Day} thg {date.Month}, {date.Year}");
            panel1.Visible = true;
        }
        public event EventHandler ButtonClicked_delete;
        private void button3_Click(object sender, EventArgs e)
        {
            ButtonClicked_delete?.Invoke(this, EventArgs.Empty);
        }

        public void delete_sent()
        {
            panel3.Visible=false; panel2.Visible=false;
            string tenfile = Form1.address;
            delete($"{tenfile}users\\{Form1.username_get}\\friend\\sent_request.txt", label1.Text + "\t" + "sent");
            delete($"{tenfile}users\\{label1.Text}\\friend\\sent_request.txt", Form1.username_get + "\t" + "request");
            delete($"{tenfile}users\\{label1.Text}\\notification\\notification.txt", Form1.username_get + "\t" + "đã gửi lời mời kết bạn" + "\t" + $"{date.Day} thg {date.Month}, {date.Year}");
            panel1.Visible = true;
        }
    }
}
