namespace Microservice.Domain.Entities;

public class Car : Entity
{
    public int    Year  { get; set; }
    public string Make  { get; set; }
    public string Model { get; set; }
    
    public Car(Guid id, int year, string make, string model)
        : base (id)
    {
        Year  = year;
        Make  = make;
        Model = model;
    }
}