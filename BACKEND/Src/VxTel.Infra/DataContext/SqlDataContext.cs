using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace VxTel.Infra.DataContext
{
    public class SqlDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }
        public IConfiguration Configuration;
        public SqlDataContext(IConfiguration configuration)
        {
            Configuration = configuration;

            var connection = Configuration.GetConnectionString("DefaultConnection");
            Connection = new SqlConnection(connection);
            Connection.Open();   
        }

        public void Dispose()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }
    }
}
