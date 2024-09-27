
using NET105_Bai5.Context;

namespace NET105_Bai5.Repositories
{
    public class CarRepo : ICarRepo
    {
        private readonly MyDbContext _context;
        public CarRepo(MyDbContext context)
        {
            _context = context;
        }

        //List<Car> cars = new List<Car>()
        //{
        //    new Car()
        //    {
        //        Id = Guid.Parse("8a81d731-3f43-42fe-b042-65502de0c33c"),
        //        Brand = "Audi",
        //        Name = "Audi A1",
        //        DoorNums = 4,
        //        Type = "Sedan"
        //    }
        //};

        //List<Car> cars;

        public Car CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car;
        }

        public void DeleteCar(Guid id)
        {
            var carDelete = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (carDelete != null)
            {
                _context.Cars.Remove(carDelete);
                _context.SaveChanges();
            }
        }

        public Car GetCar(Guid id)
        {
            return _context.Cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetCars()
        {
            return _context.Cars.ToList();
        }

        public Car UpdateCar(Car car)
        {
            var carUpdate = _context.Cars.FirstOrDefault(c => c.Id == car.Id);
            carUpdate.Id = car.Id;
            carUpdate.Brand = car.Brand;
            carUpdate.Name = car.Name;
            carUpdate.DoorNums = car.DoorNums;
            carUpdate.Type = car.Type;
            _context.SaveChanges();
            return carUpdate;
        }
    }
}
