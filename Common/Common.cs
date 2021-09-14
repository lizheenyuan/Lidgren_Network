using System;
using System.Runtime.InteropServices;
using Lidgren.Network;
namespace Common
{
    public class Common
    {

	}

    public enum MsgType:ushort
    {
        C2S_SyncPos = 1,
        S2C_SyncPos,
        C2S_CreatePlayer,
        S2C_CreatePlayer
    }
    public delegate void  PacketHandler(NetIncomingMessage im);
}