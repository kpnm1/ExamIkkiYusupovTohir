using ExamIkki.DataAccess.Entities;

namespace ExamIkki.Repository;

public interface ICarRepository
{
    Guid AddCar(Car car);
    void DeleteCar(Guid carId);
    void UpdateCar(Car car);
    Car GetCarById(Guid carId);
    List<Car> GetAllCars();
    List<Car> GetAllCarsByBrand(string brand);
    Car GetMostExpaensiveCar();
    List<Car> GetCarsByYearRange(int startYear, int endYear);
    Car GetLowestMileageCar();
    List<Car> SearchCarsByModel(string keyword);
    List<Car> GetCarsWithinPriceRange(double minPrice, double maxPrice);
    double GetAverageEngineCapacityByBrand(string brand);
    List<Car> GetCarsSortedByPrice();
    List<Car> GetRecentCars(int years);
}
