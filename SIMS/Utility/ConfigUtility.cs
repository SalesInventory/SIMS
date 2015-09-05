using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SIMS
{
    public class ConfigUtility
    {
        public static string IntializationVector
        {
            get { return ConfigurationManager.AppSettings["IntializationVector"].ToString(); }
        }
        public static string EncryptionKey
        {
            get { return ConfigurationManager.AppSettings["EncryptionKey"].ToString(); }
        }
        public static string BaseURL
        {
            get { return ConfigurationManager.AppSettings["BaseURL"].ToString(); }
        }
        public static string DomainName
        {
            get { return ConfigurationManager.AppSettings["DomainName"].ToString(); }
        }
    }
}