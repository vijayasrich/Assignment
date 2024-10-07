using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exception
{
    public class SqlException:IOException
    {
        public SqlException(string? message) : base(message)
        {
        }

        public void ExecuteQuery(string query)
        {
            try
            {
                // Simulate database offline scenario
                throw new SqlException("Database connection failed.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                // Retry or switch to backup DB
            }
        }
    }
}
