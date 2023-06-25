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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Do_an
{
    public partial class chat : UserControl
    {
        private string accountUsername;
        private string chatFilePath;
        public chat(string username)
        {
            InitializeComponent();
            accountUsername = username;
            chatFilePath = $"chat_{accountUsername}.txt"; // Path to the account-specific chat text file
        }

        private void chat_Load(object sender, EventArgs e)
        {
            // Read chat messages from the account-specific text file and populate the chat history in the UI
            if (File.Exists(chatFilePath))
            {
                string[] messages = File.ReadAllLines(chatFilePath);
                listMessage.Items.AddRange(messages);
            }
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

        private void messager_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
