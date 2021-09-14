using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DB;
using DB.Model;

namespace VRServerForm
{
    public enum UserOpType
    {
        AddUsr,
        RmUsr,
        SearchUsr,
        ModifyUsr,
        Null
    }
    public partial class SubForm_Usr : Form
    {
        private UserOpType _opType;
        private IList<User> users;
        private User _activeUser;
        public SubForm_Usr()
        {
            InitializeComponent();
            users = DBManager.Instance.GetAllUser();
            dataGridView1.DataSource = users;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                if (i == 0)//id
                {
                    dataGridView1.Columns[i].HeaderText = "用户ID";
                }
                if (i == 1)//name
                {
                    dataGridView1.Columns[i].HeaderText = "用户名称";
                }
                if (i == 2)//name
                {
                    dataGridView1.Columns[i].Visible = false;
                }
                if (i == 3)//account
                {
                    dataGridView1.Columns[i].HeaderText = "用户账号";
                }
                if (i == 4)//op
                {
                    dataGridView1.Columns[i].HeaderText = "操作记录";
                }

            }

            gb1.Enabled = false;
            _opType = UserOpType.Null;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView1.ReadOnly = true;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            _activeUser = users[dataGridView1.SelectedRows[0].Index];
           FillTextBox(_activeUser);
        }

        private void SubForm_Usr_Load(object sender, EventArgs e)
        {
           
        }

      
        private void FillTextBox(User u=null)
        {
            // gb1.Enabled = true;
            if (u==null)
            {
                textBox_UsrName.Text = "";
                textBox_Psw.Text = "";
                tb_Account.Text = "";
            }
            else
            {
                textBox_UsrName.Text = u.UsrName;
                textBox_Psw.Text = u.Psw;
                tb_Account.Text = u.Account;
            }
        }

        void RefreshDataGrid()
        {
            users = DBManager.Instance.GetAllUser();
            dataGridView1.DataSource = users;
            dataGridView1.Refresh();
            _activeUser = null;
            FillTextBox();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            // tb_Account.Enabled = true;
            gb1.Enabled = false;
            string uname = textBox_UsrName.Text;
            string psw = textBox_Psw.Text;
            string account = tb_Account.Text;
            if (!string.IsNullOrEmpty(uname) && !string.IsNullOrEmpty(psw) && !string.IsNullOrEmpty(account))
            {
                switch (_opType)
                {
                    case UserOpType.AddUsr:
                        User u = DBManager.Instance.AddUser(new User() { UsrName = uname, Psw = psw, Account = account });
                        if (u != null)
                        {
                            MessageBox.Show($"添加 {uname} 成功", "提示", MessageBoxButtons.OK);
                            RefreshDataGrid();
                        }
                        else
                        {
                            MessageBox.Show($"添加 {uname} 失败！(用户名已存在)", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case UserOpType.RmUsr:

                        break;
                    case UserOpType.SearchUsr:
                        break;
                    case UserOpType.ModifyUsr:
                        DoModifyUsr(uname, psw, account);
                        break;
                    case UserOpType.Null:
                        break;
                }
            }
            else
            {
                MessageBox.Show($"信息填写错误！（以上三项内容不可为空）", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            _opType = UserOpType.Null;
        }

        private void DoModifyUsr(string uname, string psw, string account)
        {
            _activeUser.UsrName = uname;
            _activeUser.Psw = psw;
            tb_Account.Enabled = true;
            var user = DBManager.Instance.ModifyUsr(_activeUser);
            if (user!=null)//更新成功
            {
                MessageBox.Show($"更新 {uname} 成功", "提示", MessageBoxButtons.OK);
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show($"更新 {uname} 失败！(用户名不错误)", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private void button_Cancel_Click(object sender, EventArgs e)
        {
            _opType = UserOpType.Null;
            gb1.Enabled = false;
            FillTextBox();
        }
        private void button_remove_Click(object sender, EventArgs e)
        {
            // _activeUser = users[dataGridView1.SelectedRows[0].Index];
            if (_activeUser == null)
            {
                //提示空
                return;
            }
            _opType = UserOpType.RmUsr;
            var result = MessageBox.Show($"是否删除用户{_activeUser.UsrName}？", "请确认",  MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DBManager.Instance.RemoveUser(_activeUser);
                _activeUser = null;
                RefreshDataGrid();
                _opType = UserOpType.Null;
            }
        }

        private void button_modify_Click(object sender, EventArgs e)
        {
            SetTBState(true, true, false);
            _opType = UserOpType.ModifyUsr;
            gb1.Enabled = true;

        }
        private void button_AddUsr_Click(object sender, EventArgs e)
        {
            SetTBState(true, true, true);
            _opType = UserOpType.AddUsr;
            FillTextBox();
            gb1.Enabled = true;
        }
       
        private void button_search_Click(object sender, EventArgs e)
        {
            SetTBState(false, false, true);
            _opType = UserOpType.SearchUsr;
            FillTextBox();
            gb1.Enabled = true;
        }
        private void SetTBState(bool tbUname, bool tbPsw, bool tbAccount)
        {
            tb_Account.Enabled = tbAccount;
            textBox_UsrName.Enabled = tbUname;
            textBox_Psw.Enabled = tbPsw;
        }

    }
}
