using System.Configuration;

namespace RetailARQuickHelp.DataAccess
{
    public class ConnectionString
    {
        public static string DbConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            }
        }
    }
}
