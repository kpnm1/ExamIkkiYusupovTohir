using ExamIkki.DataAccess.Entities;
using ExamIkki.Services.DTOs;

namespace ExamIkki.Services;

public interface ICarService
{
    Guid AddCar(CarDto carDto);
    void DeleteCar(Guid carId);
    void UpdateCar(CarDto carDto);
    CarDto GetCarById(Guid carId);
    List<CarDto> GetAllCars();
    List<CarDto> GetAllCarsByBrand(string brand);
    CarDto GetMostExpaensiveCar();
    List<CarDto> GetCarsByYearRange(int startYear, int endYear);
    CarDto GetLowestMileageCar();
    List<CarDto> SearchCarsByModel(string keyword);
    List<CarDto> GetCarsWithinPriceRange(double minPrice, double maxPrice);
    double GetAverageEngineCapacityByBrand(string brand);
    List<CarDto> GetCarsSortedByPrice();
    List<CarDto> GetRecentCars(int years);
}