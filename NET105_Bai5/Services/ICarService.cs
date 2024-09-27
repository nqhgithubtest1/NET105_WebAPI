namespace NET105_Bai5.Services
{
    public interface ICarService
    {
        List<Car> GetCars();
        Car GetCar(Guid id);
        Car CreateCar(Car car);
        Car UpdateCar(Car car);
        void DeleteCar(Guid id);
    }
}
