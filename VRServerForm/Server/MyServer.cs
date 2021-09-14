using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Packet;
using DB;
using Lidgren.Network;

namespace LidgrenTest
{
    public delegate void ServerShutDownEvent();
    public class MyServer
    {
        #region public fun

        public NetServer Server;
        public ILog Log=>_log;
        #endregion

        #region private

        private ILog _log;
        private NetPeerConfiguration _configuration;
        private Thread _serverIdle;
        // private List<Usr> _usrs;
        private MyServerMsgHandler _handler;
        public ServerShutDownEvent OnServerShutDown;
        #endregion

        public void InitServer(string name, int port)
        {
            _handler = new MyServerMsgHandler(this);
            // _usrs = new List<Usr>();
            _log = new Log();
            _configuration = new NetPeerConfiguration(name);
            _configuration.MaximumConnections = 10;
            _configuration.Port = port;
            Server = new NetServer(_configuration);
            var db = DBManager.Instance;
        }

        public void StartServer()
        {
            Server.Start();
            _serverIdle = new Thread(ListenMsg);
            _serverIdle.Start();
            // RegistMsgHandle();
        }

        public async void StopServer(string stopmsg="")
        {
            // _serverIdle?.Abort();
            Server.Shutdown(stopmsg);
            var task =  new Task(() =>
            {
                while (Server.Status!= NetPeerStatus.NotRunning)
                {
                    Task.Delay(20);
                }
            });
            task.Start();
            await Task.WhenAll(new Task[] {task});
            OnServerShutDown?.Invoke();
        }

        void ListenMsg()
        {
            while (Server.Status == NetPeerStatus.Running || Server.Status == NetPeerStatus.Starting)
            {
                NetIncomingMessage inMsg;
                while ((inMsg = Server.ReadMessage()) != null)
                {
                    switch (inMsg.MessageType)
                    {
                        case NetIncomingMessageType.Error:
                            break;
                        case NetIncomingMessageType.StatusChanged:
                            HandleStatusChanged(inMsg);
                            
                            break;
                        case NetIncomingMessageType.UnconnectedData:
                            break;
                        case NetIncomingMessageType.ConnectionApproval:
                            break;
                        case NetIncomingMessageType.Data:
                            // ProcessMsg(inMsg);
                            PacketType ptdata = (PacketType)inMsg.PeekByte();
                            _handler.HandlePacket(ptdata, inMsg);
                            break;
                        case NetIncomingMessageType.Receipt:
                            break;
                        case NetIncomingMessageType.DiscoveryRequest:
                            break;
                        case NetIncomingMessageType.DiscoveryResponse:
                            break;
                        case NetIncomingMessageType.VerboseDebugMessage:
                            _log.Debug(inMsg.ReadString());
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

                    Server.Recycle(inMsg);
                }

                Thread.Sleep(1);
            }
        }

        private void ProcessMsg(NetIncomingMessage inMsg)
        {
            string chat = inMsg.ReadString();
            List<NetConnection> connections = Server.Connections;
            connections.Remove(inMsg.SenderConnection);
            if (connections.Count > 0)
            {
                SendToAll(chat,inMsg,connections);
            }
        }

      

        
        private void ProcessMsgData(NetIncomingMessage inMsg)
        {
            ushort msgtype = inMsg.PeekUInt16();
            
        }
        private void HandleStatusChanged(NetIncomingMessage inMsg)
        {
            NetConnectionStatus status = (NetConnectionStatus) inMsg.ReadByte();
            string reason = inMsg.ReadString();
           
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
                    _handler.HandlePacket(PacketType.LocalPlayer, inMsg);
                    break;
                case NetConnectionStatus.Disconnecting:
                    break;
                case NetConnectionStatus.Disconnected:
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void SendToAll(string s, NetIncomingMessage inMsg, List<NetConnection> connections)
        {
            var om = Server.CreateMessage();
            om.Write(NetUtility.ToHexString(inMsg.SenderConnection.RemoteUniqueIdentifier) + " said:" + s);
            if (connections != null)
            {
                Server.SendMessage(om, connections, NetDeliveryMethod.ReliableOrdered, 0);
            }
            else
            {
                Server.SendToAll(om,NetDeliveryMethod.ReliableOrdered);
            }
        }
    }
}