namespace APBDzad4.Models;

public class Animal
{
     public int IdAnimal { get; set; }
     public string Name { get; set; }
     public string Category { get; set; }
     public double Weight { get; set; }
     public string Colour { get; set; }

     public Animal(int idAnimal, string name, string category, double weight, string colour)
     {
          this.IdAnimal = idAnimal;
          this.Name = name;
          this.Category = category;
          this.Weight = weight;
          this.Colour = colour;
     }
}