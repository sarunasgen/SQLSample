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
    public class CarsRepository : ICarsRepository
    {
        private readonly string _connectionString;
        public CarsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddCar(Car car)
        {
            const string sql = @"INSERT INTO dbo.cars
           (Make ,Model,LicensePlate, FirstRegistration)
            VALUES
           (@Make, @Model, @LicensePlate, @FirstRegistration)";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sql, car);
            }
        }

        public IEnumerable<Car> GetAllCars()
        {
            const string sql = @"SELECT * FROM cars";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Car>(sql);
                return result;
            }
        }

        public Car GetCarById(int id)
        {
            const string sql = @"SELECT * FROM cars WHERE CarId = @CarId";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.QueryFirstOrDefault<Car>(sql, new {CarId = id});
                return result;
            }
        }

        public Car GetCarByLicensePlate(string number)
        {
            const string sql = @"SELECT * FROM cars WHERE LicensePlate = @number";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.QueryFirstOrDefault<Car>(sql, new { number = number});
                return result;
            }
        }
    }


}
