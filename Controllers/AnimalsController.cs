using APBDzad4.Models;
using APBDzad4.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APBDzad4.Controllers;


[Route("api/animals")]
[ApiController]

public class AnimalsController : ControllerBase
{
    private IAnimalsService _animalsService;
    
    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _animalsService.GetAnimals();
        return Ok(animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animals = _animalsService.GetAnimals();
        var animal = animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animal == null)
        {
            NotFound($"Animal with id: {id} wasn't found");
        }
        
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var newAnimals = _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created, newAnimals);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var _animals = _animalsService.GetAnimals();
        var animalToEdit = _animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animalToEdit == null)
        {
            NotFound($"Animal with id: {id} wasn't found");
        }

        _animalsService.DeleteAnimal(animalToEdit);
        _animalsService.CreateAnimal(animal);
        
        var updatedAnimals = _animalsService.GetAnimals();

        return Ok(updatedAnimals);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var _animals = _animalsService.GetAnimals();
        var animalToDelete = _animals.FirstOrDefault(a => a.IdAnimal == id);

        if (animalToDelete == null)
        {
            NotFound($"Animal with id: {id} wasn't found");
        }
        
        _animalsService.DeleteAnimal(animalToDelete);
        var updatedAnimals = _animalsService.GetAnimals();

        return Ok(updatedAnimals);
    }
    
    //========================================== visits section
    
    // return all planned visits for all animals
    [HttpGet("/api/visits")] 
    public IActionResult GetVisits()
    {
        var visits = _animalsService.GetVisits();
        return Ok(visits);
    }

    [HttpGet("/api/visits {id:int}")]
    public IActionResult GetAnimalVisits(int id)
    {
        var animals = _animalsService.GetVisits();
        var animalVisits = animals.Where(v => v.animalId == id);
        return Ok(animalVisits);
    }

    [HttpPost("/api/visits")]
    public IActionResult CreateVisit(Visit visit)
    {
        var newVisit = _animalsService.CreateVisit(visit);
        return StatusCode(StatusCodes.Status201Created, newVisit);
    }
    
}