using System;
using System.Collections.Generic;
using Common;
using Common.Packet;
using Common.Packet.S2C;
using Lidgren.Network;
using UnityEngine;

namespace VRClient.Scripts.NetClient
{
    
    public class MyClientHandler
    {
        private Dictionary<PacketType, PacketHandler> _packetHandlers;
        private MyClient _client;
        public MyClientHandler(MyClient client)
        {
            _client = client;
            _packetHandlers = new Dictionary<PacketType, PacketHandler>();
            RigistPacketHandler();
        }

       

        public void HandleStatusChanged(NetIncomingMessage im)
        {
            NetConnectionStatus status = (NetConnectionStatus) im.ReadByte();
            switch (status)
            {
                case NetConnectionStatus.None:
                    break;
                case NetConnectionStatus.InitiatedConnect:
                    break;
                case NetConnectionStatus.ReceivedInitiation:
                    break;
                case NetConnectionStatus.RespondedAwaitingApproval:
                    break;
                case NetConnectionStatus.RespondedConnect:
                    break;
                case NetConnectionStatus.Connected:
                    Debug.Log($"Connected:"+im.ReadString());
                    // HandleDataRec(im);
                    break;
                case NetConnectionStatus.Disconnecting:
                    break;
                case NetConnectionStatus.Disconnected:
                    Debug.Log($"Disconnected:"+im.ReadString());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void HandleDataRec(NetIncomingMessage im)
        {
            PacketType pt = (PacketType) im.PeekByte();
            _packetHandlers[pt]?.Invoke(im);
        }
        private void RigistPacketHandler()
        {
            _packetHandlers.Add(PacketType.LocalPlayer,OnLocalPlayer);
            _packetHandlers.Add(PacketType.S2CLogin,OnS2CLogin);
        }

        private void OnS2CLogin(NetIncomingMessage im)
        {
            S2CLogin logininfo = new S2CLogin();
            logininfo.Deserialize(im);
            Debug.Log(logininfo.Result);
        }

        private void OnLocalPlayer(NetIncomingMessage im)
        {
            var packet = new LocalPlayerPacket();
            packet.Deserialize(im);
            _client.SetNetId(packet.Nid);
            Debug.Log($"LocalPlayerNetID:{NetUtility.ToHexString(packet.Nid)}");
            // GlobalData.CurUsr = packet.OneUsr;
            // Debug.Log(packet.OneUsr.Name);
        }
    }
}