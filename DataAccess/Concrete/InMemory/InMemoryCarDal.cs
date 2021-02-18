using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>();

            for (int i = 1; i <= 50; i++)
            {
                var car = new Car()
                {
                    BrandId = 1,
                    ColorId = 1,
                    DailyPrice = 50,
                    Description = $"{i} numaralı araba açıklaması",
                    Id = i,
                    ModelYear = DateTime.Now.Year
                };
                _cars.Add(car);


            };
        }



        public void Add(Car car)
        {
            _cars.Add(car);

        }

        public void Delete(Car car)
        {
            Car carWillDelete = _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(carWillDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            Car carWillGet = _cars.SingleOrDefault(x => x.Id == id);
            return carWillGet;
        }

        public void Update(Car car)
        {
            Car carWillUpdate = _cars.SingleOrDefault(x => x.Id == car.Id);
            carWillUpdate.ModelYear = car.ModelYear;
            carWillUpdate.Description = car.Description;
            carWillUpdate.DailyPrice = car.DailyPrice;
            carWillUpdate.ColorId = car.ColorId;
            carWillUpdate.BrandId = car.BrandId;
            
        }
    }
}
