using ExamIkki.DataAccess.Entities;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExamIkki.Repository;

public class CarRepository : ICarRepository
{
    private List<Car> cars;
    private readonly string filePath;
    public CarRepository()
    {
        cars = new List<Car>();
        filePath = "../../../DataAccess/Data/Cars.json";

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
}
