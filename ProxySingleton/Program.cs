using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxySingleton
{
    internal class Program
    {
        static string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static string filename = "Proxy Log.txt";
        static string projectName = "Proxy";
        static void Main(string[] args)
        {
            ExternalConnection externalConnection = new ExternalConnection(Utility.numbOfClient);

            while (true)
            {
                externalConnection.Connections = Utility.TryAllConnections(externalConnection.getAllConnections());
                LogManager.WriteAllServerLog(Proxy.GetInstance().ServerConnections, directoryPath, filename, projectName);
                Utility.CheckTimePackages(externalConnection.getAllConnections());
            }
        }
    }



    static class Utility
    {
        // Defined to Generate Servers
        public static int numbOfServer = 2;

        // Defined to Generate Clients
        public static int numbOfClient = 3;

        public static int minClientRangeIP = 100;
        public static int maxClientRangeIP = 254;

        public static int minDurationsSeconds = 5;
        public static int maxDurationsSeconds = 10;

        public static string bannedCountry = "Russia";

        public static string[] Countries = { "Italy", "Germany", "France", "China", "Iran", "Russia" };

        public static Random _random = new Random();
        public static string GenerateConnection(int MinRangeIP, int MaxRangeIP)
        {
            return _random.Next(MinRangeIP, MaxRangeIP) + "." + _random.Next(MinRangeIP, MaxRangeIP) + "." + _random.Next(MinRangeIP, MaxRangeIP) + "." + _random.Next(MinRangeIP, MaxRangeIP);
        }
        public static string GenerateConnection()
        {
            return _random.Next(minClientRangeIP, maxClientRangeIP) + "." + _random.Next(minClientRangeIP, maxClientRangeIP) + "." + _random.Next(minClientRangeIP, maxClientRangeIP) + "." + _random.Next(minClientRangeIP, maxClientRangeIP);
        }

        public static List<Connection> TryAllConnections(List<Connection> externalConnection)
        {
            string newIp = null;
            for (int i = 0; i < externalConnection.Count; i++)
            {
                newIp = Proxy.GetInstance().TryConnection(externalConnection[i]);

                if (newIp != null)
                    for (int j = 0; j < externalConnection.Count; j++)
                        if (externalConnection[j].Ip == newIp)
                            externalConnection.RemoveAt(j);
            }

            return externalConnection;
        }

        public static int GenerateRandomDuration()
        {
            return _random.Next(minDurationsSeconds, maxDurationsSeconds)*1000;
        }

        public static string GenerateCountry()
        {
            return Countries[_random.Next(0, Countries.Length)];
        }

        public static void CheckTimePackages(List<Connection> externalConnection)
        {
            Proxy.GetInstance().UpdateAllServersTime();

            for (int i = 0; i < externalConnection.Count; i++)
                if (externalConnection[i].Duration <= 0)
                    externalConnection.RemoveAt(i);

            Proxy.GetInstance().showServers();
            Thread.Sleep(1000);
        }
    }
}
