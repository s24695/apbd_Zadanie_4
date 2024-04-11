using APBDzad4.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBDzad4.Services;

public class AnimalsService : IAnimalsService
{
    public List<Animal> _animals;

    public AnimalsService()
    {
      _animals = new()
          {
              new Animal(1, "Mruczek", "kot", 20.00, "Black"),
              new Animal(2, "Łatek", "pies", 12.00, "Biało-brązowy"),
              new Animal(3, "Atylla", "chomik", 0.70, "Brązowy")
          };  
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        return _animals;
    }

    public List<Animal> CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return _animals;
    }

    public void DeleteAnimal(Animal animal)
    {
        _animals.Remove(animal);
    }
}