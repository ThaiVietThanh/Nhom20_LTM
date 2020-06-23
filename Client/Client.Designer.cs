namespace Client
{
    partial class Client
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtMessage = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lwMessageBox = new System.Windows.Forms.ListView();
            this.clientChat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwClient = new System.Windows.Forms.ListView();
            this.serverClient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSendClient = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Depth = 0;
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(631, 378);
            this.btnSend.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSend.Name = "btnSend";
            this.btnSend.Primary = true;
            this.btnSend.Size = new System.Drawing.Size(94, 27);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Server";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Depth = 0;
            this.txtMessage.Enabled = false;
            this.txtMessage.Font = new System.Drawing.Font("Arial Narrow", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Hint = "Tin nhắn";
            this.txtMessage.Location = new System.Drawing.Point(12, 378);
            this.txtMessage.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PasswordChar = '\0';
            this.txtMessage.SelectedText = "";
            this.txtMessage.SelectionLength = 0;
            this.txtMessage.SelectionStart = 0;
            this.txtMessage.Size = new System.Drawing.Size(513, 27);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.UseSystemPasswordChar = false;
            // 
            // lwMessageBox
            // 
            this.lwMessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lwMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lwMessageBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clientChat});
            this.lwMessageBox.Font = new System.Drawing.Font("Arial", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lwMessageBox.ForeColor = System.Drawing.SystemColors.Control;
            this.lwMessageBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lwMessageBox.HideSelection = false;
            this.lwMessageBox.Location = new System.Drawing.Point(12, 80);
            this.lwMessageBox.Name = "lwMessageBox";
            this.lwMessageBox.Size = new System.Drawing.Size(604, 281);
            this.lwMessageBox.TabIndex = 16;
            this.lwMessageBox.UseCompatibleStateImageBehavior = false;
            this.lwMessageBox.View = System.Windows.Forms.View.Details;
            // 
            // clientChat
            // 
            this.clientChat.Text = "";
            this.clientChat.Width = 580;
            // 
            // lwClient
            // 
            this.lwClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lwClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lwClient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serverClient});
            this.lwClient.Font = new System.Drawing.Font("Arial", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lwClient.ForeColor = System.Drawing.SystemColors.Control;
            this.lwClient.FullRowSelect = true;
            this.lwClient.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lwClient.HideSelection = false;
            this.lwClient.Location = new System.Drawing.Point(622, 80);
            this.lwClient.MultiSelect = false;
            this.lwClient.Name = "lwClient";
            this.lwClient.Size = new System.Drawing.Size(103, 281);
            this.lwClient.TabIndex = 17;
            this.lwClient.UseCompatibleStateImageBehavior = false;
            this.lwClient.View = System.Windows.Forms.View.Details;
            this.lwClient.Click += new System.EventHandler(this.lwClient_Click);
            // 
            // serverClient
            // 
            this.serverClient.Text = "";
            this.serverClient.Width = 100;
            // 
            // btnSendClient
            // 
            this.btnSendClient.Depth = 0;
            this.btnSendClient.Enabled = false;
            this.btnSendClient.Location = new System.Drawing.Point(531, 378);
            this.btnSendClient.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSendClient.Name = "btnSendClient";
            this.btnSendClient.Primary = true;
            this.btnSendClient.Size = new System.Drawing.Size(94, 27);
            this.btnSendClient.TabIndex = 1;
            this.btnSendClient.Text = "Client";
            this.btnSendClient.UseVisualStyleBackColor = true;
            this.btnSendClient.Click += new System.EventHandler(this.btnSendClient_Click);
            // 
            // Client
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 417);
            this.Controls.Add(this.lwClient);
            this.Controls.Add(this.btnSendClient);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lwMessageBox);
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ứng dụng chat (Chưa đăng nhập)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnSend;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMessage;
        private System.Windows.Forms.ListView lwMessageBox;
        private System.Windows.Forms.ColumnHeader clientChat;
        private System.Windows.Forms.ListView lwClient;
        private System.Windows.Forms.ColumnHeader serverClient;
        private MaterialSkin.Controls.MaterialRaisedButton btnSendClient;
    }
}