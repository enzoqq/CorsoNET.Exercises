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

        public Dictionary<string, Connection> ServerConnections { get { return ServerIp; } }

        private Proxy()
        {
            ServerIp = new Dictionary<string, Connection>();
            Ip = "111.111.111.111";

            for (int i = 0; i < Utility.numbOfServer; i++)
                ServerIp[Utility.GenerateConnection(10, 254)] = null;
        }

        public static Proxy GetInstance()
        {
            if (instance == null)
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

        public string TryConnection(Connection _externalConnection)
        {
            string _emptyServer = CheckConnection(_externalConnection.Ip);
            if (_emptyServer != null && ServerIp[_emptyServer] == null && _externalConnection.Country != Utility.bannedCountry)
            {
                ServerIp[_emptyServer] = _externalConnection;
                return _externalConnection.Ip;
            }
            return null;
        }

        public void showServers()
        {
            Console.Clear();

            foreach (var server in ServerIp)
            {
                Console.WriteLine($"- Server IP: '{server.Key}'");
                if (server.Value != null && server.Value.Duration > 0)
                    Console.WriteLine($"- Client IP: '{server.Value.Ip}'\nType: '{server.Value.Type}'\nCountry: '{server.Value.Country}'\nDuration: '{server.Value.Duration} ms'\n");
            }
        }

        public void RemoveConnection(string _ip)
        {
            string ipExist = checkClientConnection(_ip);
            if (ipExist != null)
                ServerIp[ipExist] = null;
        }

        public void UpdateConnection(string _ip, int _ms)
        {
            string ipExist = checkClientConnection(_ip);

            if (ipExist != null)
                ServerIp[ipExist].Duration -= _ms;
        }

        public string checkClientConnection(string _ip)
        {
            foreach (var server in ServerIp)
                if (server.Value != null && server.Value.Ip == _ip)
                    return server.Key;
                
            
            return null;
        }

        public void UpdateAllServersTime()
        {

            for (int i = 0; i < ServerIp.Count; i++)
                if (ServerIp.ElementAt(i).Value != null && ServerIp.ElementAt(i).Value.Duration > 0)
                    ServerIp.ElementAt(i).Value.Duration -= 1000;
                else ServerIp[ServerIp.ElementAt(i).Key] = null;
        }
    }
}
