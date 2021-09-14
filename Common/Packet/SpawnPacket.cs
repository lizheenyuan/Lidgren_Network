using Lidgren.Network;
using UnityEngine;

namespace Common.Packet
{
    public class SpawnPacket:PacketBase
    {
        public long Id;
        public Vector3 Pos;
        public override void Serialize(NetOutgoingMessage outgoingMessage)
        {
            
        }

        public override void Deserialize(NetIncomingMessage incomingMessage)
        {
        }
    }
}