namespace CamKoob.Customers.Domain.Entities;

public class Customer : Entity
{
    public string Name { get; private set; }
    public Contract Contract { get; private set; }

    protected Customer() { }

    public Customer(string name)
    {
        Name = name;
    }

    public void SetContract(Contract contract)
    {
        Contract = contract;
    }
}