using Dapper;
using Microsoft.Data.SqlClient;
using SQLSample.Contracts;
using SQLSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SQLSample.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;
        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddCustomer(Customer customer)
        {
            string[] nameValues = customer.FullName.Split(' ');
            string cFirstName = nameValues[0];
            string cLastName = nameValues[1];
            const string sql = "INSERT INTO customers (FirsName ,LastName) VALUES (@FirstName, @LastName)";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sql, new { FirstName = cFirstName, LastName = cLastName});
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            const string sql = @"SELECT Id AS CustomerId, CONCAT(FirsName,' ',LastName) AS FullName FROM customers";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Customer>(sql);
                return result;
            }
        }
    }
}
