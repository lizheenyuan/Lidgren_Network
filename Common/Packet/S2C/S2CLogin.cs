

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using LidgrenTest;

namespace Common.Packet.S2C
{
    public enum LoginResult
    {
        OK,
        NoUsr,
        PswError,
        Other
    }
    public class S2CLogin:PacketBase
    {
        public Usr ClientUsr;

        public LoginResult Result;

        public S2CLogin()
        {
            PT = PacketType.S2CLogin;
            ClientUsr = new Usr();
            Result = LoginResult.Other;
        }
        public override void Serialize(NetOutgoingMessage outgoingMessage)
        {
            base.Serialize(outgoingMessage);
            outgoingMessage.Write((byte)Result);
            if (Result == LoginResult.OK)
            {
                outgoingMessage.Write(ClientUsr.Account);
                outgoingMessage.Write(ClientUsr.Uid);
                outgoingMessage.Write(ClientUsr.NetId);
                outgoingMessage.Write(ClientUsr.Name);
            }
            else
            {
                outgoingMessage.Write(ClientUsr.Account);
                outgoingMessage.Write(ClientUsr.NetId);
            }
            
        }

        public override void Deserialize(NetIncomingMessage incomingMessage)
        {
            base.Deserialize(incomingMessage);
            Result = (LoginResult)incomingMessage.ReadByte();
            if (Result == LoginResult.OK)
            {
                ClientUsr.Account = incomingMessage.ReadString();
                ClientUsr.Uid = incomingMessage.ReadInt32();
                ClientUsr.NetId = incomingMessage.ReadInt64();
                ClientUsr.Name = incomingMessage.ReadString();
            }
            else
            {
                ClientUsr.Account = incomingMessage.ReadString();
                ClientUsr.NetId = incomingMessage.ReadInt64();
            }
        }
    }
}
