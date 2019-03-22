using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UCARMS.Gateway
{
    public class BaseGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        private string _connString = WebConfigurationManager.ConnectionStrings["ProjectDbContext"].ConnectionString;

        public BaseGateway()
        {
            Connection = new SqlConnection(_connString);
        }
    }
}