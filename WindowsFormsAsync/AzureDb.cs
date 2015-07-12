using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAsync
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
    public class AzureDb
    {
        private static string azureDbConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["azureDb"].ConnectionString;
        public AzureDb()
        {
        }

        public static string GetCustomerNameById(int id)
        {
            using (var conn = new SqlConnection(azureDbConnectionString))
            {
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = string.Format("select FirstName from SalesLT.Customer where CustomerID = '{0}'", id);
                var namn = (string)comm.ExecuteScalar();
                return namn;
            }

        }

        public static async Task<Customer> GetCustomerByIdAsync(int customerID)
        {
            using (SqlConnection connection = new SqlConnection(azureDbConnectionString))
            {
                await connection.OpenAsync();
                string commandString = string.Format("select FirstName, LastName from SalesLT.Customer where CustomerID = '{0}'", customerID);
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.CommandText = commandString;
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            Customer customer = GetCustomerFromReader(reader, customerID);
                            return customer;
                        }
                        else
                        {
                            return new Customer { FirstName = string.Format("[{0}]", customerID), LastName = string.Format("[{0}]", customerID) };
                        }
                    }
                }
            }
        }

        private static Customer GetCustomerFromReader(SqlDataReader reader, int customerID)
        {
            Customer customer = new Customer();
            customer.CustomerID = customerID;
            customer.FirstName = reader.GetFieldValue<string>(0);
            customer.LastName = reader.GetFieldValue<string>(1);
            return customer;
        }


    }
}
