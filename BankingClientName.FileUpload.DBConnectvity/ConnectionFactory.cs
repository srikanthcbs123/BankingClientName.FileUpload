using BankingClientName.FileUpload.BusinessEntities.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace BankingClientName.FileUpload.DBConnectvity
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _config;
        public ConnectionFactory(IConfiguration config)
        {
            _config = config;
        }
        //Getting the sqlconnectionstring here.
        public SqlConnection GetHotelManagementSqlConnection()
        {
            SqlConnection con = new SqlConnection(Convert.ToString(_config.GetSection("ConnectionStrings:hotelmanagementSqlConnectionString").Value));
            return con;
        }

  // synatx://objectname:"{//your properties}
  //"ConnectionStrings": {
  //  //"key":"value"
  //  "hotelmanagementSqlConnectionString": "Server=DESKTOP-P2V677R;Database=hotelmanagement;integrated security=yes;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
  //},



    }
}
