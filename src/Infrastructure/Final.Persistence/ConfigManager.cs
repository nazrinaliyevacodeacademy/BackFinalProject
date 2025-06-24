using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using NLog.Internal;

namespace Final.Persistence 
{

    public static class ConfigManager
    {
        public static ConfigurationManager Config
        {
            get
            {
                ConfigurationManager cnfg = new();
                cnfg.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "Presentation","Final.API"));
                cnfg.AddJsonFile("appsettings.json");
                return cnfg;

            }
        }
        public static string ConnectionStr
        {
        get
        {
                return Config.GetConnectionString("DefaultItem");
         }
        }
    }
   
}

