namespace CamKoob.Customers.Domain.Entities;

public class Contract : Entity
{
    public EProduct Product { get; private set; }
    public Guid CustomerId { get; private set; }
    public Customer? Customer { get; private set; }

    protected Contract() { }

    public Contract(EProduct product, Guid customerId)
    {
        Product = product;
        CustomerId = customerId;
    }
}