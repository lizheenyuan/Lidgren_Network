using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp2.DB;
using DB;
using DB.Model;
using Lidgren.Network;
using LidgrenTest;
using VRServerForm.Manager;
using VRServerForm.Server.Tool;
using VRServerForm.SubForm;

namespace VRServerForm
{
    public partial class Form1 : Form
    {
        private MyServer _server;
        // private StudentManager _studentManager;

        public Form1()
        {
            InitializeComponent();
            // _studentManager = new StudentManager();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _server = new MyServer();
            _server.InitServer("chat", 14242);
            Application.Idle += new EventHandler(UpdateMyServer);


            var welcomeForm = new WelcomeForm(_server,Main_Tc);
            TabPage page = new TabPage();
            page.Name = "主页";
            page.Text = "欢迎使用";
            welcomeForm.FormBorderStyle = FormBorderStyle.None;
            welcomeForm.TopLevel = false;
            page.Controls.Add(welcomeForm);
            Main_Tc.TabPages.Add(page);
            Main_Tc.SelectedIndex = Main_Tc.TabPages.Count - 1;
            welcomeForm.Show();

            var subFormUsr = new SubForm_Usr();
            TabPage page1 = new TabPage();
            page1.Name = "用户管理";
            page1.Text = "用户管理";
            subFormUsr.FormBorderStyle = FormBorderStyle.None;
            subFormUsr.TopLevel = false;
            page1.Controls.Add(subFormUsr);
            Main_Tc.TabPages.Add(page1);
            // Main_Tc.SelectedIndex = Main_Tc.TabPages.Count - 1;
            subFormUsr.Show();
        }

        private void UpdateMyServer(object? sender, EventArgs e)
        {
            UpdateStatus();
            while (Util.AppStillIdle)
            {
            }
        }

        void UpdateStatus()
        {
            tssLabel_Server.Text = _server.Server.Socket == null
                ? "0.0.0.0(未连接)"
                : Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault(_ =>
                    _.AddressFamily == AddressFamily.InterNetwork
                ).ToString();
            tss_ServerPort.Text = _server.Server.Port.ToString();
            tss_Username.Text = OnLineUsrManager.Instance.GetOnlineUsrCount()>0 ?OnLineUsrManager.Instance.GetOnlineUsrs()[0].Name: "未登录";
            tss_ClientStatus.Text = _server.Server.Connections.Count > 0 ? "已连接" : "未连接";
            tss_ServerStatus.Text = _server.Server.Status == NetPeerStatus.Running ? "服务中" : "未服务";
        }
    }
}