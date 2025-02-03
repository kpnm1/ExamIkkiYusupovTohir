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
        if (carDto == null)
            throw new ArgumentNullException(nameof(carDto));

        carDto.Id = Guid.NewGuid();
        carRepository.AddCar(ConvertToCar(carDto));
        return carDto.Id;
    }

    public void DeleteCar(Guid carId)
    {
        carRepository.DeleteCar(carId);
    }

    public void UpdateCar(CarDto carDto)
    {
        var car = ConvertToCar(carDto);
        carRepository.UpdateCar(car);
    }

    public CarDto GetCarById(Guid carId)
    {
        var car = carRepository.GetCarById(carId);
        return ConvertToCarDto(car);
    }

    public List<CarDto> GetAllCars()
    {
        var cars = carRepository.GetAllCars();
        return cars.Select(ConvertToCarDto).ToList();
    }

    public List<CarDto> GetAllCarsByBrand(string brand)
    {
        var res = carRepository.GetAllCars().Where(x => x.Brand == brand).ToList();
        return res.Select(ConvertToCarDto).ToList();
    }

    public CarDto GetMostExpaensiveCar()
    {
        var res = carRepository.GetAllCars().OrderByDescending(x => x.Price).FirstOrDefault();
        return ConvertToCarDto(res);
    }

    public List<CarDto> GetCarsByYearRange(int startYear, int endYear)
    {
        var cars = carRepository.GetAllCars().Where(c => c.Year >= startYear && c.Year <= endYear).ToList();
        return cars.Select(ConvertToCarDto).ToList();
    }

    public CarDto GetLowestMileageCar()
    {
        var res = carRepository.GetAllCars().OrderBy(c => c.Mileage).FirstOrDefault();
        return ConvertToCarDto(res);
    }

    public List<CarDto> SearchCarsByModel(string keyword)
    {
        var res = carRepository.GetAllCars().Where(c => c.Model.Contains(keyword)).ToList();
        return res.Select(ConvertToCarDto).ToList();
    }

    public List<CarDto> GetCarsWithinPriceRange(double minPrice, double maxPrice)
    {
        var res = carRepository.GetAllCars().Where(c => c.Price >= minPrice && c.Price <= maxPrice).ToList();
        return res.Select(ConvertToCarDto).ToList();
    }

    public double GetAverageEngineCapacityByBrand(string brand)
    {
        var brandCars = carRepository.GetAllCars().Where(c => c.Brand.Equals(brand));
        return brandCars.Any() ? brandCars.Average(c => c.EngineCapacity) : 0;
    }

    public List<CarDto> GetCarsSortedByPrice()
    {
        var res = carRepository.GetAllCars().OrderBy(c => c.Price).ToList();
        return res.Select(ConvertToCarDto).ToList();
    }

    public List<CarDto> GetRecentCars(int years)
    {
        int currentYear = DateTime.Now.Year;
        var res = carRepository.GetAllCars().Where(c => c.Year >= (currentYear - years)).ToList();
        return res.Select(ConvertToCarDto).ToList();
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
