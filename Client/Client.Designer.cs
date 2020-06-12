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
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Depth = 0;
            this.btnSend.Location = new System.Drawing.Point(526, 381);
            this.btnSend.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSend.Name = "btnSend";
            this.btnSend.Primary = true;
            this.btnSend.Size = new System.Drawing.Size(90, 27);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Depth = 0;
            this.txtMessage.Font = new System.Drawing.Font("Arial Narrow", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Hint = "Tin nhắn";
            this.txtMessage.Location = new System.Drawing.Point(12, 381);
            this.txtMessage.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PasswordChar = '\0';
            this.txtMessage.SelectedText = "";
            this.txtMessage.SelectionLength = 0;
            this.txtMessage.SelectionStart = 0;
            this.txtMessage.Size = new System.Drawing.Size(508, 27);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.UseSystemPasswordChar = false;
            // 
            // lwMessageBox
            // 
            this.lwMessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lwMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lwMessageBox.Font = new System.Drawing.Font("Arial", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lwMessageBox.ForeColor = System.Drawing.SystemColors.Control;
            this.lwMessageBox.HideSelection = false;
            this.lwMessageBox.Location = new System.Drawing.Point(12, 80);
            this.lwMessageBox.Name = "lwMessageBox";
            this.lwMessageBox.Size = new System.Drawing.Size(604, 281);
            this.lwMessageBox.TabIndex = 16;
            this.lwMessageBox.UseCompatibleStateImageBehavior = false;
            this.lwMessageBox.View = System.Windows.Forms.View.List;
            // 
            // Client
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 426);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lwMessageBox);
            this.Name = "Client";
            this.Text = "Ứng dụng Chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnSend;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMessage;
        private System.Windows.Forms.ListView lwMessageBox;
    }
}