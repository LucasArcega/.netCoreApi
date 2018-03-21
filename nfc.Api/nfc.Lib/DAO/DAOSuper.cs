using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;
namespace App.Rep.DAO
{
    public abstract class DAOSuper
    {

        protected IConfiguration configuration;

        public DAOSuper(IConfiguration configuration){
            this.configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(this.configuration.GetConnectionString());
            }
        }
    }
}
