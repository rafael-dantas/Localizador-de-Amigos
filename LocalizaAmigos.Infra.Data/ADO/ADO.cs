using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace LocalizaAmigos.Infra.Data.ADO
{
    public class ADO
    {
        public static SqlConnection GetConnection()
        {           
            string connectionString = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                            .Build().GetSection("ConnectionStrings").GetSection("DbConnection").Value;
            return new SqlConnection(connectionString);
        }

        public static SqlCommand GetCommand(string sql,SqlConnection conn)
        {
            return new SqlCommand(sql, conn);
        }

    }
}
