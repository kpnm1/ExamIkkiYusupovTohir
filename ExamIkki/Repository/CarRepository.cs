using ExamIkki.DataAccess.Entities;
using System.Text.Json;

namespace ExamIkki.Repository;

public class CarRepository : ICarRepository
{
    private List<Car> cars;
    private string directoryPath;
    private string filePath;
    public CarRepository()
    {
        cars = new List<Car>();
        filePath = Path.Combine("../../../Data", "Car.json");

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }

        cars = GetAllCars();
    }
    public Guid AddCar(Car car)
    {
        cars.Add(car);
        return car.Id;
    }

    public void DeleteCar(Guid carId)
    {
        var deleteCar = GetCarById(carId);
        cars.Remove(deleteCar);
        SaveChanges();
    }

    public List<Car> GetAllCars()
    {
        var carsJson = File.ReadAllText(filePath);
        var cars = JsonSerializer.Deserialize<List<Car>>(carsJson);
        return cars;
    }

    public Car GetCarById(Guid carId)
    {
        var car = GetAllCars().FirstOrDefault(x => x.Id == carId);
        return car;
    }

    public List<Car> GetAllCarsByBrand(string brand)
    {
        var carsByBrand = GetAllCars().Where(x => x.Brand == brand).ToList();
        return carsByBrand;
    }

    public void UpdateCar(Car car)
    {
        var updateCar = GetCarById(car.Id);
        var index = GetAllCars().IndexOf(car);
        cars[index] = car;
        SaveChanges();
    }

    public void SaveChanges()
    {
        var cars = GetAllCars();
        var json = JsonSerializer.Serialize(cars);
        File.WriteAllText(filePath, json);
    }

    public Car GetMostExpaensiveCar()
    {
        var mostExpensiveCar = GetAllCars().MaxBy(x => x.Price);
        return mostExpensiveCar;
    }

    public List<Car> GetCarsByYearRange(int startYear, int endYear)
    {
        var cars = GetAllCars().Where(x => x.Year >= startYear && x.Year <= endYear).ToList();
        return cars;
    }

    public Car GetLowestMileageCar()
    {
        var lowstMileageCar = GetAllCars().MinBy(x => x.Mileage);
        return lowstMileageCar;
    }

    public List<Car> SearchCarsByModel(string keyword)
    {
        var carByModel = GetAllCars().Where(x => x.Model.Contains(keyword)).ToList();
        return carByModel;
    }

    public List<Car> GetCarsWithinPriceRange(double minPrice, double maxPrice)
    {
        var cars = GetAllCars().Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToList();
        return cars;
    }

    public double GetAverageEngineCapacityByBrand(string brand)
    {
        var carsByBrand = GetAllCars().Where(x => x.Brand == brand).ToList();
        var carEngineCapacities = carsByBrand.Sum(x => x.EngineCapacity);
        var count = carsByBrand.Count();
        
        return carEngineCapacities / count;
    }

    public List<Car> GetCarsSortedByPrice()
    {
        var carsSortedByPrice = GetAllCars().OrderBy(x => x.Price).ToList();
        return carsSortedByPrice;
    }

    public List<Car> GetRecentCars(int years)
    {
        var recentCars = GetAllCars().Where(x => x.Year >= years).ToList();
        return recentCars;
    }
}
