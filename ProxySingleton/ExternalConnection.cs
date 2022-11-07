using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxySingleton
{
    internal class ExternalConnection
    {
        private List<Connection> _connections;

        public List<Connection> Connections { set { _connections = value;  } }

        public Connection getConnection(int n)
        {
            return _connections[n];
        }

        public List<Connection> getAllConnections()
        {
            return _connections;
        }

        public ExternalConnection()
        {
            _connections = new List<Connection>();
        }

        public ExternalConnection(int n)
        {
            _connections = new List<Connection>();
            GenerateConnections(n);
        }

        public void addConnection()
        {
            _connections.Add(new Connection());
        }

        public void GenerateConnections(int n)
        {
            for (int i = 0; i < n; i++)
                addConnection();
        }

        public void showConnections()
        {
            foreach (Connection connection in _connections)
                Console.WriteLine($"IP: '{connection.Ip}'\nType: '{connection.Type}'\nCountry: '{connection.Country}'\n");
        }

        public void removeConnectionClient(Connection _connection)
        {
            _connections.Remove(_connection);
        }
            
    }
}
