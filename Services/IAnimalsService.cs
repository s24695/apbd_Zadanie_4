using APBDzad4.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBDzad4.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals();
    List<Animal> CreateAnimal(Animal animal);

    void DeleteAnimal(Animal animal);

}