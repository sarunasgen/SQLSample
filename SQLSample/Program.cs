using SQLSample.Contracts;
using SQLSample.Models;
using SQLSample.Repository;
using System;

namespace SQLSample
{
    public class Program
    {
        public static void Main()
        {
            //                                                          Pas jus turetu buti localhost, ne localhost\\MSSQLSERVER01
            ICarsRepository carsRepository = new CarsRepository("Server=localhost\\MSSQLSERVER01;Database=automobiliudb;Trusted_Connection=True;TrustServerCertificate=true;");
            /* Automobiliu pridejimas
            Car newCar = new Car
            {
                Make = "Audi",
                Model = "A8",
                FirstRegistration = DateTime.Parse("1998-01-01"),
                LicensePlate = "SKN009"
            };
            carsRepository.AddCar(newCar);
            */

            foreach(Car c in carsRepository.GetAllCars())
            {
                Console.WriteLine($"{c.Make} {c.Model} {c.LicensePlate} {c.FirstRegistration.ToString("yyyy-MM")}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Car By Id: ");
            var id = int.Parse(Console.ReadLine());
            var carById = carsRepository.GetCarById(id);
            if(carById == null)
            {
                Console.WriteLine($"Car By Id {id} was not found");
                return;
            }
            Console.WriteLine($"{carById.Make} {carById.Model} {carById.LicensePlate} {carById.FirstRegistration.ToString("yyyy-MM")}");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Car By License Plate: ");
            var licensePlate = Console.ReadLine();
            var carBylicensePlate = carsRepository.GetCarByLicensePlate(licensePlate);
            if (carBylicensePlate == null)
            {
                Console.WriteLine($"Car By License Plate {id} was not found");
                return;
            }
            Console.WriteLine($"{carBylicensePlate.Make} {carBylicensePlate.Model} {carBylicensePlate.LicensePlate} {carBylicensePlate.FirstRegistration.ToString("yyyy-MM")}");
        }
    }
}