using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxySingleton
{
    internal class Connection
    {
        private string ip;
        private int duration;
        private string type;
        private string country_name;

        public Connection()
        {
            ip = Utility.GenerateConnection();
            duration = Utility.GenerateRandomDuration();
            type = "IPv4";
            country_name = Utility.GenerateCountry();
        }

        public string Ip { get { return ip; } }
        public string Type { get { return type; } }
        public string Country { get { return country_name; } }
        public int Duration { get { return duration; } set { duration = value; } }

    }
}
