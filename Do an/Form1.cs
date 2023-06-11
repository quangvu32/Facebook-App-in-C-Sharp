using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;

namespace Do_an
{
    public partial class Form1 : Form
    {
        Socket sck;
        EndPoint epLocal, epRemote;
        public Form1()
        {
            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            ServerIPtextBox.Text = GetLocalIP();
            ClientIPtextBox.Text = GetLocalIP();
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userControl11.image = Image.FromFile("E:\\LapTrinh\\PROJECT\\c#\\Do an\\icon\\3844470_home_house_icon.png");
            userControl12.image = Image.FromFile("E:\\LapTrinh\\PROJECT\\c#\\Do an\\icon\\115736_display_screen_video_monitor_icon.png");

            
        }

        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }    
            }
            return "127.0.0.1";
        }
            
        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);
                if(size > 0)
                {
                    byte[] recievedData = new byte[1464];
                    recievedData = (byte[])aResult.AsyncState;
                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    string receivedMessage = eEncoding.GetString(recievedData);

                    listMessage.Items.Add("Friend: " + receivedMessage);
                }
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);


            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            
            }
        }
        private void Startbutton_Click(object sender, EventArgs e)
        {
            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(ServerIPtextBox.Text), Convert.ToInt32(ServerPorttextBox.Text));
                sck.Bind(epLocal);

                epRemote = new IPEndPoint(IPAddress.Parse(ClientIPtextBox.Text), Convert.ToInt32(ClientPorttextBox.Text));
                sck.Connect(epRemote);

                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

                Startbutton.Text = "Connected";
                Startbutton.Enabled = false;
                Sendbutton.Enabled = true;
                MessagetextBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Connectbutton_Click(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            try
            {
                ASCIIEncoding enc = new ASCIIEncoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(MessagetextBox.Text);

                sck.Send(msg);

                listMessage.Items.Add("You:" + MessagetextBox.Text);
                MessagetextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
