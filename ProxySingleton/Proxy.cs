using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxySingleton
{
    internal class Proxy
    {
        private string Ip;

        private Dictionary<string, Connection> ServerIp;
        private static Proxy instance;

        private Proxy()
        {
            ServerIp = new Dictionary<string, Connection>();
            Ip = "111.111.111.111";

            for (int i = 0; i < Utility.numbOfServer; i++)
                ServerIp[Utility.GenerateConnection(10, 254)] = null;
        }

        public static Proxy GetInstance()
        {
            if(instance == null)
                instance = new Proxy();

            return instance;
        }

        public string CheckConnection(string _externalConnection)
        {
            foreach (var server in ServerIp)
                if (server.Value == null)
                    return server.Key;

            return null;
        }

        public bool TryConnection(Connection _externalConnection)
        {
            string _emptyServer = CheckConnection(_externalConnection.Ip);
            if (_emptyServer != null && ServerIp[_emptyServer] == null && _externalConnection.Country != Utility.bannedCountry)
            {
                ServerIp[_emptyServer] = _externalConnection;
                return true;
            }
            return false;
        }

        public void showServers()
        {
            Console.Clear();

            foreach (var server in ServerIp)
            {
                Console.WriteLine($"- Server IP: '{server.Key}'");
                if (server.Value != null)
                    Console.WriteLine($"-Client IP: '{server.Value.Ip}'\nType: '{server.Value.Type}'\nCountry: '{server.Value.Country}'\nDuration: '{server.Value.Duration} ms'\n");
            }    
        }

        public void RemoveConnection(string _ip)
        {
            string server = CheckConnection(_ip);
            if (server != null)
                ServerIp[server] = null;
        }

        public void UpdateConnection(string _ip, int _ms)
        {
            string server = CheckConnection(_ip);
            if (server != null && ServerIp[server] != null)
                ServerIp[server].Duration += _ms;
        }

    }
}
