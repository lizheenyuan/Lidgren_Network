using Lidgren.Network;

namespace LidgrenTest
{
    public class Usr
    {
        public long NetId ;
        public int Uid;
        public string Account;
        public string Name;
        public string Psw;

        public virtual void Serialize(NetOutgoingMessage outgoingMessage)
        {
            outgoingMessage.Write(NetId);
            outgoingMessage.Write(Uid);
            outgoingMessage.Write(Name);
            outgoingMessage.Write(Psw);
        }

        public virtual void Deserialize(NetIncomingMessage incomingMessage)
        {
            NetId = incomingMessage.ReadInt64();
            Uid = incomingMessage.ReadInt32();
            Name = incomingMessage.ReadString();
            Psw = incomingMessage.ReadString();
        }
    }
}