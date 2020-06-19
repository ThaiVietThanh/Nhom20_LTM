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
            this.serverClient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwMessageBox = new System.Windows.Forms.ListView();
            this.serverChat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtMessage = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btn_Send = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.serverClientStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_SendAll = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtTimKiem = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.rdSearchName = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdSearchIndex = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.lwClient.Location = new System.Drawing.Point(12, 118);
            this.lwClient.MultiSelect = false;
            this.lwClient.Name = "lwClient";
            this.lwClient.Size = new System.Drawing.Size(194, 331);
            this.lwClient.TabIndex = 13;
            this.lwClient.UseCompatibleStateImageBehavior = false;
            this.lwClient.View = System.Windows.Forms.View.Details;
            // 
            // serverClient
            // 
            this.serverClient.Text = "";
            this.serverClient.Width = 168;
            // 
            // lwMessageBox
            // 
            this.lwMessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lwMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lwMessageBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serverChat});
            this.lwMessageBox.Font = new System.Drawing.Font("Arial", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lwMessageBox.ForeColor = System.Drawing.SystemColors.Control;
            this.lwMessageBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lwMessageBox.HideSelection = false;
            this.lwMessageBox.Location = new System.Drawing.Point(212, 118);
            this.lwMessageBox.MultiSelect = false;
            this.lwMessageBox.Name = "lwMessageBox";
            this.lwMessageBox.Size = new System.Drawing.Size(525, 331);
            this.lwMessageBox.TabIndex = 10;
            this.lwMessageBox.UseCompatibleStateImageBehavior = false;
            this.lwMessageBox.View = System.Windows.Forms.View.Details;
            // 
            // serverChat
            // 
            this.serverChat.Text = "";
            this.serverChat.Width = 500;
            // 
            // txtMessage
            // 
            this.txtMessage.Depth = 0;
            this.txtMessage.Hint = "Tin nhắn";
            this.txtMessage.Location = new System.Drawing.Point(12, 510);
            this.txtMessage.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PasswordChar = '\0';
            this.txtMessage.SelectedText = "";
            this.txtMessage.SelectionLength = 0;
            this.txtMessage.SelectionStart = 0;
            this.txtMessage.Size = new System.Drawing.Size(515, 27);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.UseSystemPasswordChar = false;
            // 
            // btn_Send
            // 
            this.btn_Send.Depth = 0;
            this.btn_Send.Location = new System.Drawing.Point(533, 510);
            this.btn_Send.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Primary = true;
            this.btn_Send.Size = new System.Drawing.Size(90, 27);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "Gửi";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(208, 82);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(48, 23);
            this.materialLabel2.TabIndex = 18;
            this.materialLabel2.Text = "Chat";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverClientStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(758, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // serverClientStatus
            // 
            this.serverClientStatus.Font = new System.Drawing.Font("Arial", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverClientStatus.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.serverClientStatus.Name = "serverClientStatus";
            this.serverClientStatus.Size = new System.Drawing.Size(211, 16);
            this.serverClientStatus.Text = "Dang sách client đang kết nối: 0";
            // 
            // btn_SendAll
            // 
            this.btn_SendAll.Depth = 0;
            this.btn_SendAll.Location = new System.Drawing.Point(629, 510);
            this.btn_SendAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_SendAll.Name = "btn_SendAll";
            this.btn_SendAll.Primary = true;
            this.btn_SendAll.Size = new System.Drawing.Size(108, 27);
            this.btn_SendAll.TabIndex = 1;
            this.btn_SendAll.Text = "Gửi Tất Cả";
            this.btn_SendAll.UseVisualStyleBackColor = true;
            this.btn_SendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Depth = 0;
            this.txtTimKiem.Hint = "Tìm kiếm theo số thứ tự";
            this.txtTimKiem.Location = new System.Drawing.Point(12, 467);
            this.txtTimKiem.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.SelectionLength = 0;
            this.txtTimKiem.SelectionStart = 0;
            this.txtTimKiem.Size = new System.Drawing.Size(555, 27);
            this.txtTimKiem.TabIndex = 21;
            this.txtTimKiem.UseSystemPasswordChar = false;
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // rdSearchName
            // 
            this.rdSearchName.AutoSize = true;
            this.rdSearchName.Depth = 0;
            this.rdSearchName.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdSearchName.Location = new System.Drawing.Point(679, 463);
            this.rdSearchName.Margin = new System.Windows.Forms.Padding(0);
            this.rdSearchName.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdSearchName.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdSearchName.Name = "rdSearchName";
            this.rdSearchName.Ripple = true;
            this.rdSearchName.Size = new System.Drawing.Size(58, 30);
            this.rdSearchName.TabIndex = 22;
            this.rdSearchName.TabStop = true;
            this.rdSearchName.Text = "Tên";
            this.rdSearchName.UseVisualStyleBackColor = true;
            this.rdSearchName.CheckedChanged += new System.EventHandler(this.rdSearchName_CheckedChanged);
            // 
            // rdSearchIndex
            // 
            this.rdSearchIndex.AutoSize = true;
            this.rdSearchIndex.Checked = true;
            this.rdSearchIndex.Depth = 0;
            this.rdSearchIndex.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdSearchIndex.Location = new System.Drawing.Point(570, 463);
            this.rdSearchIndex.Margin = new System.Windows.Forms.Padding(0);
            this.rdSearchIndex.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdSearchIndex.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdSearchIndex.Name = "rdSearchIndex";
            this.rdSearchIndex.Ripple = true;
            this.rdSearchIndex.Size = new System.Drawing.Size(98, 30);
            this.rdSearchIndex.TabIndex = 22;
            this.rdSearchIndex.TabStop = true;
            this.rdSearchIndex.Text = "Số thứ tự";
            this.rdSearchIndex.UseVisualStyleBackColor = true;
            this.rdSearchIndex.CheckedChanged += new System.EventHandler(this.rdSearchIndex_CheckedChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 82);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(144, 23);
            this.materialLabel1.TabIndex = 18;
            this.materialLabel1.Text = "Danh sách Client";
            // 
            // Server
            // 
            this.AcceptButton = this.btn_Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 566);
            this.Controls.Add(this.rdSearchIndex);
            this.Controls.Add(this.rdSearchName);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.btn_SendAll);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lwClient);
            this.Controls.Add(this.lwMessageBox);
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ứng dụng Chat (Server)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lwClient;
        private System.Windows.Forms.ListView lwMessageBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMessage;
        private MaterialSkin.Controls.MaterialRaisedButton btn_Send;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ColumnHeader serverChat;
        private System.Windows.Forms.ColumnHeader serverClient;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel serverClientStatus;
        private MaterialSkin.Controls.MaterialRaisedButton btn_SendAll;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTimKiem;
        private MaterialSkin.Controls.MaterialRadioButton rdSearchName;
        private MaterialSkin.Controls.MaterialRadioButton rdSearchIndex;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}