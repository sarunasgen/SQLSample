using SQLSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLSample.Contracts
{
    public interface ICarsRepository
    {
        void AddCar(Car car);
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        Car GetCarByLicensePlate(string number);

    }
}
