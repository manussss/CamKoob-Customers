namespace CamKoob.Customers.Domain.Entities;

public class Contract
{
    public Guid Id { get; set; }
    public EProduct Product { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
}