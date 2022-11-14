using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace ProxySingleton
{
    public static class LogManager
    {
        internal static void WriteAllServerLog(Dictionary<string, Connection> servers, string pathname, string filename, string ProjectName)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var server in servers)
                if(server.Value != null)
                    stringBuilder.AppendLine(String.Format($"[Execution] {DateTime.Now} DEBUG [{ProjectName}] '{server.Value.Ip}' '{server.Key}' '{server.Value.Country}'"));

            File.AppendAllText(Path.Combine(pathname, filename), stringBuilder.ToString());
        }
    }
}
