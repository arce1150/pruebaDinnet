using System;
using System.Configuration;
namespace Dinnet.Proxy
{
    public  class Settings
    {
        public static string conexion
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            }
        }
    }
}
