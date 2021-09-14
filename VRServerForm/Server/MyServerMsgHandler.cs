using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Packet;
using Common.Packet.C2S;
using Common.Packet.S2C;
using DB;
using Lidgren.Network;

namespace LidgrenTest
{
    public class MyServerMsgHandler
    {
        private Dictionary<PacketType, PacketHandler> _packetHandlers;
        private MyServer _server;

        public MyServerMsgHandler(MyServer server)
        {
            _server = server;
            _packetHandlers = new Dictionary<PacketType, PacketHandler>();
            Rigist();
        }

        void Rigist()
        {
            _packetHandlers.Add(PacketType.LocalPlayer, OnLocalPlayer);
            _packetHandlers.Add(PacketType.C2SLogin, OnPlayerLogin);
        }

        private void OnPlayerLogin(NetIncomingMessage im)
        {
            C2SLogin clientLogin = new C2SLogin();
            clientLogin.Deserialize(im);
            S2CLogin s2CLogin = new S2CLogin();
            s2CLogin.ClientUsr.Account = clientLogin.Player.Account;
            s2CLogin.ClientUsr.NetId = clientLogin.Player.NetId;
            if (!string.IsNullOrEmpty(clientLogin.Player.Account))
            {
                var usr = DBManager.Instance.GetUserByAccount(clientLogin.Player.Account);
                if (usr!=null)
                {
                    if (usr.Psw == clientLogin.Player.Psw)
                    {
                        s2CLogin.Result = LoginResult.OK;
                        s2CLogin.ClientUsr.Uid = usr.Id;
                        s2CLogin.ClientUsr.Name = usr.UsrName;
                        var om = _server.Server.CreateMessage();
                        s2CLogin.Serialize(om);
                        _server.Server.SendToAll(om, NetDeliveryMethod.ReliableOrdered);//发给所有人，根据netid判断是否为自己
                        OnLineUsrManager.Instance.AddUsr(s2CLogin.ClientUsr);
                        return;
                    }
                    else
                    {
                        s2CLogin.Result = LoginResult.PswError;
                    }
                }
                else
                {
                    s2CLogin.Result = LoginResult.NoUsr;
                }
            }
            else
            {
                s2CLogin.Result = LoginResult.NoUsr;
            }
            var om_error = _server.Server.CreateMessage();
            s2CLogin.Serialize(om_error);
            _server.Server.SendMessage(om_error, im.SenderConnection, NetDeliveryMethod.ReliableOrdered);
        }

        private void OnLocalPlayer(NetIncomingMessage im)
        {
            LocalPlayerPacket packet = new LocalPlayerPacket();
            long id = im.SenderConnection.RemoteUniqueIdentifier;
            string name = NetUtility.ToHexString(id);
            if (im.SenderConnection.RemoteHailMessage != null)
            {
                name = im.SenderConnection.RemoteHailMessage.ReadString();
            }

            packet.Nid = id;
            // packet.OneUsr = new Usr() {NetId = id};
            // OnLineUsrManager.Instance.AddUsr(packet.OneUsr);
            //todo此处应该判断逻辑
            NetOutgoingMessage om = _server.Server.CreateMessage();
            packet.Serialize(om);
            _server.Server.SendMessage(om, im.SenderConnection, NetDeliveryMethod.ReliableOrdered);
            // _server.Log.Info(packet.OneUsr.Name + ":Connected");
        }

        public void HandlePacket(PacketType pt, NetIncomingMessage im)
        {
            _packetHandlers[pt]?.Invoke(im);
        }

        public virtual void HandleDisconnected(NetIncomingMessage im)
        {
            // OnLineUsrManager.Instance.RmUsr(im.SenderConnection.RemoteUniqueIdentifier);
            if (_server.Server.Connections.Count > 0)
            {
                
            }
        }
    }
}