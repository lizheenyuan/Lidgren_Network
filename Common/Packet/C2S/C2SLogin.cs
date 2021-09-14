using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using LidgrenTest;

namespace Common.Packet.C2S
{
    public class C2SLogin:PacketBase
    {
        public Usr Player;

        public C2SLogin()
        {
            PT = PacketType.C2SLogin;
            Player = new Usr();
        }
        public override void Serialize(NetOutgoingMessage outgoingMessage)
        {
            base.Serialize(outgoingMessage);
            // Player.Serialize(outgoingMessage);
            outgoingMessage.Write(Player.Account);
            outgoingMessage.Write(Player.Psw);
        }

        public override void Deserialize(NetIncomingMessage incomingMessage)
        {
            base.Deserialize(incomingMessage);
            // Player.Deserialize(incomingMessage);
            Player.Account = incomingMessage.ReadString();
            Player.Psw = incomingMessage.ReadString();
            Player.NetId = incomingMessage.SenderConnection.RemoteUniqueIdentifier;
        }
    }
}
