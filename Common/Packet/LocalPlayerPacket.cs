using Lidgren.Network;
using LidgrenTest;

namespace Common.Packet
{
    public class LocalPlayerPacket:PacketBase
    {
        public long Nid;

        public LocalPlayerPacket()
        {
            PT = PacketType.LocalPlayer;
        }
        public override void Serialize(NetOutgoingMessage outgoingMessage)
        {
            base.Serialize(outgoingMessage);
            outgoingMessage.Write(Nid);
        }

        public override void Deserialize(NetIncomingMessage incomingMessage)
        {
            base.Deserialize(incomingMessage);
            Nid = incomingMessage.ReadInt64();
        }
    }
}