namespace APBDzad4.Models;

public class Visit
{
    public DateTime DateTime { get; set; }
    public int animalId { get; set; }
    public string description { get; set; }
    public double price { get; set; }
    
    public Visit(DateTime dateTime, int animalId, string description, double price)
    {
        DateTime = dateTime;
        this.animalId = animalId;
        this.description = description;
        this.price = price;
    }
}