using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lidgren.Network;
using LidgrenTest;
using VRServerForm.Server.Tool;

namespace VRServerForm.SubForm
{
    public partial class WelcomeForm : Form
    {
        private MyServer _server;
        private TabControl _mainFormTC;
        private const string _strServerStart="开启服务";
        private const string _strServerStop="关闭服务";
        public WelcomeForm(MyServer server,TabControl tc)
        {
            InitializeComponent();
            _server = server;
            _mainFormTC = tc;
            _server.OnServerShutDown += () =>
            {
                btn_StartServer.Enabled = true;
            };
        }

       

        private void btn_StartServer_Click(object sender, EventArgs e)
        {
            if (_server.Server.Status == NetPeerStatus.NotRunning)
            {
                _server.StartServer();
                btn_StartServer.Text = _strServerStop;
            }
            else
            {
                btn_StartServer.Enabled = false;
                
                _server.StopServer("服务器主动关闭连接");
                btn_StartServer.Text = _strServerStart;
            }
           
        }

        private void btn_ManageUsr_Click(object sender, EventArgs e)
        {
            _mainFormTC.SelectTab(1);
        }

        private void btn_ClientCtrl_Click(object sender, EventArgs e)
        {
            _mainFormTC.SelectTab(2);
        }
    }
}
