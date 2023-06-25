using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Do_an.NewFolder1
{
    public partial class messager : Form
    {
        private string accountUsername;
        private string chatFilePath;

        public messager(string username)
        {
            InitializeComponent();
            accountUsername = username;
            chatFilePath = $"chat_{accountUsername}.txt"; // Path to the account-specific chat text file
        }

        private void messager_Load(object sender, EventArgs e)
        {
            // Read chat messages from the account-specific text file and populate the chat history in the UI
            if (File.Exists(chatFilePath))
            {
                string[] messages = File.ReadAllLines(chatFilePath);
                listMessage.Items.AddRange(messages);
            }
        }

        private void messager_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            string message = listMessage.Text;

            // Save the message to the account-specific text file
            using (StreamWriter writer = File.AppendText(chatFilePath))
            {
                writer.WriteLine(message);
            }

            // Update the chat history in the UI
            listMessage.Items.Add(message);

            // Clear the input textbox
            MessagetextBox.Clear();
        }
    }
}
