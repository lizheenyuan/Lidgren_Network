using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VRClient.Scripts.NetClient;

namespace TestClient
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MyClient _client = new MyClient(SynchronizationContext.Current);
            _client.Connect("127.0.0.1", 14242);
        }
    }
}
