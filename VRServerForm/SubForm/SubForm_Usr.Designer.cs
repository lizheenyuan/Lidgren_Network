
namespace VRServerForm
{
    partial class SubForm_Usr
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.tb_Account = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_Psw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_UsrName = new System.Windows.Forms.TextBox();
            this.button_AddUsr = new System.Windows.Forms.Button();
            this.button_modify = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(535, 422);
            this.dataGridView1.TabIndex = 0;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.tb_Account);
            this.gb1.Controls.Add(this.label3);
            this.gb1.Controls.Add(this.button_Cancel);
            this.gb1.Controls.Add(this.button_OK);
            this.gb1.Controls.Add(this.textBox_Psw);
            this.gb1.Controls.Add(this.label2);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.textBox_UsrName);
            this.gb1.Location = new System.Drawing.Point(543, 27);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(229, 197);
            this.gb1.TabIndex = 1;
            this.gb1.TabStop = false;
            this.gb1.Text = "用户信息";
            // 
            // tb_Account
            // 
            this.tb_Account.Location = new System.Drawing.Point(72, 80);
            this.tb_Account.Name = "tb_Account";
            this.tb_Account.Size = new System.Drawing.Size(142, 23);
            this.tb_Account.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "账    号";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(139, 168);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(16, 168);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 3;
            this.button_OK.Text = "完成";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_Psw
            // 
            this.textBox_Psw.Location = new System.Drawing.Point(72, 125);
            this.textBox_Psw.Name = "textBox_Psw";
            this.textBox_Psw.Size = new System.Drawing.Size(142, 23);
            this.textBox_Psw.TabIndex = 2;
            this.textBox_Psw.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户姓名";
            // 
            // textBox_UsrName
            // 
            this.textBox_UsrName.Location = new System.Drawing.Point(72, 37);
            this.textBox_UsrName.Name = "textBox_UsrName";
            this.textBox_UsrName.Size = new System.Drawing.Size(142, 23);
            this.textBox_UsrName.TabIndex = 0;
            // 
            // button_AddUsr
            // 
            this.button_AddUsr.Location = new System.Drawing.Point(559, 314);
            this.button_AddUsr.Name = "button_AddUsr";
            this.button_AddUsr.Size = new System.Drawing.Size(75, 23);
            this.button_AddUsr.TabIndex = 5;
            this.button_AddUsr.Text = "添加";
            this.button_AddUsr.UseVisualStyleBackColor = true;
            this.button_AddUsr.Click += new System.EventHandler(this.button_AddUsr_Click);
            // 
            // button_modify
            // 
            this.button_modify.Location = new System.Drawing.Point(682, 314);
            this.button_modify.Name = "button_modify";
            this.button_modify.Size = new System.Drawing.Size(75, 23);
            this.button_modify.TabIndex = 6;
            this.button_modify.Text = "修改";
            this.button_modify.UseVisualStyleBackColor = true;
            this.button_modify.Click += new System.EventHandler(this.button_modify_Click);
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(559, 369);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(75, 23);
            this.button_remove.TabIndex = 7;
            this.button_remove.Text = "删除";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(682, 369);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 8;
            this.button_search.Text = "查询";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // SubForm_Usr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 461);
            this.ControlBox = false;
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.button_modify);
            this.Controls.Add(this.button_AddUsr);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubForm_Usr";
            this.ShowInTaskbar = false;
            this.Text = "SubForm_Usr";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SubForm_Usr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.TextBox textBox_Psw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_UsrName;
        private System.Windows.Forms.Button button_AddUsr;
        private System.Windows.Forms.Button button_modify;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox tb_Account;
        private System.Windows.Forms.Label label3;
    }
}