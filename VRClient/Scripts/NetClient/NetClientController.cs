using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Packet.C2S;
using Lidgren.Network;
using LidgrenTest;
using UnityEngine;

namespace VRClient.Scripts.NetClient
{
    public class NetClientController
    {
        private MyClient _client;

        public NetClientController(MyClient client)
        {
            _client = client;
        }
        public NetConnection Connect(string ip, int port)
        {

            _client.Client.Start();
            NetOutgoingMessage hail = _client.Client.CreateMessage("client");
            NetConnection nc = _client.Client.Connect(ip, port, hail);
            _client.Client.RegisterReceivedCallback(new SendOrPostCallback(GotMessage));
            return nc;
        }

        private void GotMessage(object peer)
        {
            NetIncomingMessage im;
            while ((im = _client.Client.ReadMessage()) != null)
            {
                switch (im.MessageType)
                {
                    case NetIncomingMessageType.Error:
                        break;
                    case NetIncomingMessageType.StatusChanged:
                        _client.Handler.HandleStatusChanged(im);
                        break;
                    case NetIncomingMessageType.UnconnectedData:
                        break;
                    case NetIncomingMessageType.ConnectionApproval:
                        break;
                    case NetIncomingMessageType.Data:
                        _client.Handler.HandleDataRec(im);
                        break;
                    case NetIncomingMessageType.Receipt:
                        break;
                    case NetIncomingMessageType.DiscoveryRequest:
                        break;
                    case NetIncomingMessageType.DiscoveryResponse:
                        break;
                    case NetIncomingMessageType.VerboseDebugMessage:
                        break;
                    case NetIncomingMessageType.DebugMessage:
                        break;
                    case NetIncomingMessageType.WarningMessage:
                        break;
                    case NetIncomingMessageType.ErrorMessage:
                        break;
                    case NetIncomingMessageType.NatIntroductionSuccess:
                        break;
                    case NetIncomingMessageType.ConnectionLatencyUpdated:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                _client.Client.Recycle(im);
            }
        }
        public void Shutdown()
        {
            _client.Client.Disconnect("Requested by user");
            // s_client.Shutdown("Requested by user");
        }

        public void LoginServer(string account,string psw)
        {
            C2SLogin login = new C2SLogin();
            login.Player.Account = account;
            login.Player.Psw = psw;
            login.Player.NetId = _client.NetId;
            var om = _client.Client.CreateMessage();
            login.Serialize(om);
            Debug.Log($"send server:{login.Player.Account}");
            _client.Client.SendMessage(om, NetDeliveryMethod.ReliableOrdered);
            _client.Client.FlushSendQueue();
        }
    }
}
