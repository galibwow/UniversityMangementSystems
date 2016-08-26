using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagementSystem.DAL
{
    public class CommonGateway
    {
        public string ConnectionString= WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;


        
        
    }
}