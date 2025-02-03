using ExamIkki.DataAccess.Entities;
using ExamIkki.Repository;
using ExamIkki.Services.DTOs;

namespace ExamIkki.Services;

public class CarService : ICarService
{
    private readonly ICarRepository carRepository;
    public CarService()
    {
        carRepository = new CarRepository();
    }
    public Guid AddCar(CarDto carDto)
    {

        carRepository.AddCar(ConvertToCar(carDto));
        return carDto.Id;
    }

    public void DeleteCar(Guid carId)
    {
        carRepository.DeleteCar(carId);
    }

    public List<CarDto> GetAllCars()
    {
        var cars = carRepository.GetAllCars().Select(x => ConvertToCarDto(x)).ToList();
        return cars;
    }

    public List<CarDto> GetAllCarsByBrand(string brand)
    {
        return carRepository.GetAllCarsByBrand(brand).Select(x => ConvertToCarDto(x)).ToList();
    }

    public double GetAverageEngineCapacityByBrand(string brand)
    {
        return carRepository.GetAverageEngineCapacityByBrand(brand);
    }

    public CarDto GetCarById(Guid carId)
    {
        var res = carRepository.GetCarById(carId);
        return ConvertToCarDto(res);
    }

    public List<CarDto> GetCarsByYearRange(int startYear, int endYear)
    {
        return carRepository.GetCarsByYearRange(startYear, endYear).Select(x => ConvertToCarDto(x)).ToList();
    }

    public List<CarDto> GetCarsSortedByPrice()
    {
        return carRepository.GetCarsSortedByPrice().Select(x => ConvertToCarDto(x)).ToList();
    }

    public List<CarDto> GetCarsWithinPriceRange(double minPrice, double maxPrice)
    {
        return carRepository.GetCarsWithinPriceRange(minPrice, maxPrice).Select(x => ConvertToCarDto(x)).ToList();
    }

    public CarDto GetLowestMileageCar()
    {
        return ConvertToCarDto(carRepository.GetLowestMileageCar());
    }

    public CarDto GetMostExpaensiveCar()
    {
        return ConvertToCarDto(carRepository.GetMostExpaensiveCar());
    }

    public List<CarDto> GetRecentCars(int years)
    {
        return carRepository.GetRecentCars(years).Select(x => ConvertToCarDto(x)).ToList();
    }

    public List<CarDto> SearchCarsByModel(string keyword)
    {
        return carRepository.SearchCarsByModel(keyword).Select(x => ConvertToCarDto(x)).ToList();
    }

    public void UpdateCar(CarDto carDto)
    {
        carRepository.UpdateCar(ConvertToCar(carDto));
    }

    private Car ConvertToCar(CarDto carDto)
    {
        return new Car
        {
            Brand = carDto.Brand,
            Color = carDto.Color,
            Model = carDto.Model,
            Year = carDto.Year,
            EngineCapacity = carDto.EngineCapacity,
            Price = carDto.Price,
            Mileage = carDto.Mileage,
            Id = carDto.Id,
        };
    }

    private CarDto ConvertToCarDto(Car car)
    {
        return new CarDto
        {
            Brand = car.Brand,
            Color = car.Color,
            Model = car.Model,
            Year = car.Year,
            EngineCapacity = car.EngineCapacity,
            Price = car.Price,
            Mileage = car.Mileage,
            Id = car.Id,
        };
    }
}
