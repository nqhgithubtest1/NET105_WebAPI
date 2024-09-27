namespace NET105_Bai5.Repositories
{
    public interface ICarRepo
    {
        List<Car> GetCars();
        Car GetCar(Guid id);
        Car CreateCar(Car car);
        Car UpdateCar(Car car);
        void DeleteCar(Guid id);
    }
}
