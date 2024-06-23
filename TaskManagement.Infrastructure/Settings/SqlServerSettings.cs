using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.Settings
{
    public class SqlServerSettings
    {
        //public string SqlServer { get; private set; } = string.Empty;
        public string ServerName { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;

        public string GetConnectionString(string connectionString)
        {
            return string.Format(connectionString, ServerName, DatabaseName);
        }
    }
}
