
using NET105_Bai5.Repositories;

namespace NET105_Bai5.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepo _carRepo;
        public CarService(ICarRepo carRepo)
        {
            _carRepo = carRepo;
        }
        public Car CreateCar(Car car)
        {
            return _carRepo.CreateCar(car);
        }

        public void DeleteCar(Guid id)
        {
            _carRepo.DeleteCar(id);
        }

        public Car GetCar(Guid id)
        {
            return _carRepo.GetCar(id);
        }

        public List<Car> GetCars()
        {
            return _carRepo.GetCars();
        }

        public Car UpdateCar(Car car)
        {
            return _carRepo.UpdateCar(car);
        }
    }
}
