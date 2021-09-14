using Lidgren.Network;

namespace Common.Packet
{
    public enum PacketType
    {
        LocalPlayer,
        C2SLogin,
        S2CLogin,
        S2CDisconnected
    }
    interface IPacket
    {
        void Serialize(NetOutgoingMessage outgoingMessage);
        void Deserialize(NetIncomingMessage incomingMessage);
    }
    public class PacketBase:IPacket
    {
        public PacketType PT;

        public virtual void Serialize(NetOutgoingMessage outgoingMessage)
        {
            outgoingMessage.Write((byte)PT);
        }

        public virtual void Deserialize(NetIncomingMessage incomingMessage)
        {
            PacketType pt = (PacketType)incomingMessage.ReadByte();
        }
    }
}