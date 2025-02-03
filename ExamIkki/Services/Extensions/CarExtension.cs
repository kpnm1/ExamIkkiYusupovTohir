using ExamIkki.Services.DTOs;
using System.Runtime.CompilerServices;

namespace ExamIkki.Services.Extensions;

public static class CarExtension
{
    public static double CarDtoMileageInMile(this CarDto carDto)
    {
        var carMileage = carDto.Mileage * 0.621371;
        return carMileage;
    }
    public static double CarsPriceSum(this List<CarDto> carDtos)
    {
        var carPriceSums = carDtos.Sum(x => x.Price);
        return carPriceSums;
    }
}
