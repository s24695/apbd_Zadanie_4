using APBDzad4.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APBDzad4.Services;

public class AnimalsService : IAnimalsService
{
    public List<Animal> _animals;
    public List<Visit> _Visits;

    public AnimalsService()
    {
        _animals = new()
          {
              new Animal(1, "Mruczek", "kot", 20.00, "Black"),
              new Animal(2, "Łatek", "pies", 12.00, "Biało-brązowy"),
              new Animal(3, "Atylla", "chomik", 0.70, "Brązowy")
          };

        _Visits = new()
        {
            new Visit(DateTime.Parse("2024/04/14"), 0, "trauma", 300),
            new Visit(DateTime.Parse("2024/05/12"), 2, "ADHD curation", 250),
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

    public IEnumerable<Visit> GetVisits()
    {
        return _Visits;
    }

    public IEnumerable<Visit> GetAnimalVisits(Animal animal)
    {
        var visits = _Visits.Where(a => a.animalId == animal.IdAnimal);
        return visits;
    }

    public List<Visit> CreateVisit(Visit visit)
    {
        _Visits.Add(visit);
        return _Visits;
    }
}