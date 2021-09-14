
namespace VRServerForm.SubForm
{
    partial class WelcomeForm
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
            this.btn_StartServer = new System.Windows.Forms.Button();
            this.btn_ManageUsr = new System.Windows.Forms.Button();
            this.btn_ClientCtrl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_StartServer
            // 
            this.btn_StartServer.Location = new System.Drawing.Point(74, 246);
            this.btn_StartServer.Name = "btn_StartServer";
            this.btn_StartServer.Size = new System.Drawing.Size(149, 40);
            this.btn_StartServer.TabIndex = 0;
            this.btn_StartServer.Text = "开启服务";
            this.btn_StartServer.UseVisualStyleBackColor = true;
            this.btn_StartServer.Click += new System.EventHandler(this.btn_StartServer_Click);
            // 
            // btn_ManageUsr
            // 
            this.btn_ManageUsr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_ManageUsr.Location = new System.Drawing.Point(298, 246);
            this.btn_ManageUsr.Name = "btn_ManageUsr";
            this.btn_ManageUsr.Size = new System.Drawing.Size(149, 40);
            this.btn_ManageUsr.TabIndex = 1;
            this.btn_ManageUsr.Text = "学生信息管理";
            this.btn_ManageUsr.UseVisualStyleBackColor = true;
            this.btn_ManageUsr.Click += new System.EventHandler(this.btn_ManageUsr_Click);
            // 
            // btn_ClientCtrl
            // 
            this.btn_ClientCtrl.Location = new System.Drawing.Point(544, 246);
            this.btn_ClientCtrl.Name = "btn_ClientCtrl";
            this.btn_ClientCtrl.Size = new System.Drawing.Size(149, 40);
            this.btn_ClientCtrl.TabIndex = 2;
            this.btn_ClientCtrl.Text = "客户端控制";
            this.btn_ClientCtrl.UseVisualStyleBackColor = true;
            this.btn_ClientCtrl.Click += new System.EventHandler(this.btn_ClientCtrl_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 481);
            this.Controls.Add(this.btn_ClientCtrl);
            this.Controls.Add(this.btn_ManageUsr);
            this.Controls.Add(this.btn_StartServer);
            this.Name = "WelcomeForm";
            this.Text = "WelcomeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_StartServer;
        private System.Windows.Forms.Button btn_ManageUsr;
        private System.Windows.Forms.Button btn_ClientCtrl;
    }
}