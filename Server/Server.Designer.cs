namespace Server
{
    partial class Server
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
            this.lwClient = new System.Windows.Forms.ListView();
            this.lwMessageBox = new System.Windows.Forms.ListView();
            this.txtMessage = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btn_Send = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // lwClient
            // 
            this.lwClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lwClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lwClient.Font = new System.Drawing.Font("Arial", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lwClient.ForeColor = System.Drawing.SystemColors.Control;
            this.lwClient.HideSelection = false;
            this.lwClient.Location = new System.Drawing.Point(12, 98);
            this.lwClient.Name = "lwClient";
            this.lwClient.Size = new System.Drawing.Size(194, 331);
            this.lwClient.TabIndex = 13;
            this.lwClient.UseCompatibleStateImageBehavior = false;
            this.lwClient.View = System.Windows.Forms.View.List;
            // 
            // lwMessageBox
            // 
            this.lwMessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lwMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lwMessageBox.Font = new System.Drawing.Font("Arial", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lwMessageBox.ForeColor = System.Drawing.SystemColors.Control;
            this.lwMessageBox.HideSelection = false;
            this.lwMessageBox.Location = new System.Drawing.Point(212, 98);
            this.lwMessageBox.Name = "lwMessageBox";
            this.lwMessageBox.Size = new System.Drawing.Size(525, 331);
            this.lwMessageBox.TabIndex = 10;
            this.lwMessageBox.UseCompatibleStateImageBehavior = false;
            this.lwMessageBox.View = System.Windows.Forms.View.List;
            // 
            // txtMessage
            // 
            this.txtMessage.Depth = 0;
            this.txtMessage.Hint = "Tin nhắn";
            this.txtMessage.Location = new System.Drawing.Point(12, 446);
            this.txtMessage.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PasswordChar = '\0';
            this.txtMessage.SelectedText = "";
            this.txtMessage.SelectionLength = 0;
            this.txtMessage.SelectionStart = 0;
            this.txtMessage.Size = new System.Drawing.Size(627, 27);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.UseSystemPasswordChar = false;
            // 
            // btn_Send
            // 
            this.btn_Send.Depth = 0;
            this.btn_Send.Location = new System.Drawing.Point(647, 446);
            this.btn_Send.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Primary = true;
            this.btn_Send.Size = new System.Drawing.Size(90, 27);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "Gửi";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 72);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(144, 23);
            this.materialLabel1.TabIndex = 18;
            this.materialLabel1.Text = "Danh sách Client";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(208, 72);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(48, 23);
            this.materialLabel2.TabIndex = 18;
            this.materialLabel2.Text = "Chat";
            // 
            // Server
            // 
            this.AcceptButton = this.btn_Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 489);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lwClient);
            this.Controls.Add(this.lwMessageBox);
            this.Name = "Server";
            this.Text = "Ứng dụng Chat (Server)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lwClient;
        private System.Windows.Forms.ListView lwMessageBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMessage;
        private MaterialSkin.Controls.MaterialRaisedButton btn_Send;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}