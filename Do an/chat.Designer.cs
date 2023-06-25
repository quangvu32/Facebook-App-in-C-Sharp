namespace Do_an
{
    partial class chat
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listMessage = new System.Windows.Forms.ListBox();
            this.Sendbutton = new System.Windows.Forms.Button();
            this.MessagetextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listMessage
            // 
            this.listMessage.FormattingEnabled = true;
            this.listMessage.Location = new System.Drawing.Point(17, 25);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(529, 459);
            this.listMessage.TabIndex = 22;
            // 
            // Sendbutton
            // 
            this.Sendbutton.Location = new System.Drawing.Point(417, 490);
            this.Sendbutton.Name = "Sendbutton";
            this.Sendbutton.Size = new System.Drawing.Size(104, 50);
            this.Sendbutton.TabIndex = 21;
            this.Sendbutton.Text = "send";
            this.Sendbutton.UseVisualStyleBackColor = true;
            this.Sendbutton.Click += new System.EventHandler(this.Sendbutton_Click);
            // 
            // MessagetextBox
            // 
            this.MessagetextBox.Location = new System.Drawing.Point(17, 490);
            this.MessagetextBox.Multiline = true;
            this.MessagetextBox.Name = "MessagetextBox";
            this.MessagetextBox.Size = new System.Drawing.Size(348, 50);
            this.MessagetextBox.TabIndex = 20;
            // 
            // chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listMessage);
            this.Controls.Add(this.Sendbutton);
            this.Controls.Add(this.MessagetextBox);
            this.Name = "chat";
            this.Size = new System.Drawing.Size(576, 589);
            this.Load += new System.EventHandler(this.chat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listMessage;
        private System.Windows.Forms.Button Sendbutton;
        private System.Windows.Forms.TextBox MessagetextBox;
    }
}
