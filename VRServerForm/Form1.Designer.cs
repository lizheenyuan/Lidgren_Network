
namespace VRServerForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Main_Tc = new System.Windows.Forms.TabControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ServerIPText = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabel_Server = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_ServerPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_Username = new System.Windows.Forms.ToolStripStatusLabel();
            this.客户端连接状态 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_ClientStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.服务端状态 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_ServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_Tc
            // 
            this.Main_Tc.Location = new System.Drawing.Point(1, 3);
            this.Main_Tc.Name = "Main_Tc";
            this.Main_Tc.SelectedIndex = 0;
            this.Main_Tc.Size = new System.Drawing.Size(780, 520);
            this.Main_Tc.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerIPText,
            this.tssLabel_Server,
            this.tss_ServerPort,
            this.toolStripStatusLabel1,
            this.tss_Username,
            this.客户端连接状态,
            this.tss_ClientStatus,
            this.服务端状态,
            this.tss_ServerStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ServerIPText
            // 
            this.ServerIPText.Name = "ServerIPText";
            this.ServerIPText.Size = new System.Drawing.Size(151, 21);
            this.ServerIPText.Text = "当前服务器IP地址和端口：";
            // 
            // tssLabel_Server
            // 
            this.tssLabel_Server.AutoSize = false;
            this.tssLabel_Server.Name = "tssLabel_Server";
            this.tssLabel_Server.Size = new System.Drawing.Size(100, 21);
            this.tssLabel_Server.Text = "192.192.192.192";
            this.tssLabel_Server.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tss_ServerPort
            // 
            this.tss_ServerPort.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tss_ServerPort.Name = "tss_ServerPort";
            this.tss_ServerPort.Size = new System.Drawing.Size(47, 21);
            this.tss_ServerPort.Text = "13532";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 21);
            this.toolStripStatusLabel1.Text = "当前用户：";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tss_Username
            // 
            this.tss_Username.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tss_Username.Name = "tss_Username";
            this.tss_Username.Size = new System.Drawing.Size(69, 21);
            this.tss_Username.Text = "username";
            // 
            // 客户端连接状态
            // 
            this.客户端连接状态.Name = "客户端连接状态";
            this.客户端连接状态.Size = new System.Drawing.Size(95, 21);
            this.客户端连接状态.Text = "客户端连接状态:";
            this.客户端连接状态.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tss_ClientStatus
            // 
            this.tss_ClientStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tss_ClientStatus.Name = "tss_ClientStatus";
            this.tss_ClientStatus.Size = new System.Drawing.Size(77, 21);
            this.tss_ClientStatus.Text = "连接/未连接";
            // 
            // 服务端状态
            // 
            this.服务端状态.Name = "服务端状态";
            this.服务端状态.Size = new System.Drawing.Size(71, 21);
            this.服务端状态.Text = "服务端状态:";
            // 
            // tss_ServerStatus
            // 
            this.tss_ServerStatus.Name = "tss_ServerStatus";
            this.tss_ServerStatus.Size = new System.Drawing.Size(73, 21);
            this.tss_ServerStatus.Text = "连接/未连接";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Main_Tc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Main_Tc;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ServerIPText;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel_Server;
        private System.Windows.Forms.ToolStripStatusLabel tss_ServerPort;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tss_Username;
        private System.Windows.Forms.ToolStripStatusLabel 客户端连接状态;
        private System.Windows.Forms.ToolStripStatusLabel tss_ClientStatus;
        private System.Windows.Forms.ToolStripStatusLabel 服务端状态;
        private System.Windows.Forms.ToolStripStatusLabel tss_ServerStatus;
    }
}

