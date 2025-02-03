using ExamIkki.DataAccess.Entities;

namespace ExamIkki.Repository;

public interface ICarRepository
{
    Guid AddCar(Car car);
    void DeleteCar(Guid carId);
    void UpdateCar(Car car);
    Car GetCarById(Guid carId);
    List<Car> GetAllCars();
    
}
