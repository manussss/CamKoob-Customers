namespace CamKoob.Customers.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Contract Contract { get; set; }
}