using System;
using System.Threading;
using Common.Packet.S2C;
using Lidgren.Network;
using LidgrenTest;

namespace VRClient.Scripts.NetClient
{
    public class ClientBase
    {
        public long NetId { get; protected set; }
        public Usr ClientInfo { get; protected set; }
        public LoginResult LoginState { get; protected set; }

        public virtual void SetNetId(long id)
        {
            NetId = id;
        }

        public virtual void SetUsr(Usr u)
        {
            ClientInfo = u;
        }

        public virtual void SetLoginState(LoginResult r)
        {
            LoginState = r;
        }
    }
    public class MyClient: ClientBase
    {
        private NetPeerConfiguration _configuration;
        private Lidgren.Network.NetClient _client;
        private SynchronizationContext _context;
        private MyClientHandler _handler;
        private NetClientController _controller;
        public MyClientHandler Handler => _handler;
        public NetClientController Controller => _controller;

        public Lidgren.Network.NetClient Client => _client;

        public MyClient(SynchronizationContext context,string appid="chat")
        {
            _context = context;
            _configuration = new NetPeerConfiguration(appid);
            _configuration.AutoFlushSendQueue = false;
            _client = new Lidgren.Network.NetClient(_configuration);
            _handler = new MyClientHandler(this);
            _controller = new NetClientController(this);
        }

       

    }
}
