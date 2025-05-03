namespace CamKoob.Customers.Infra.Data;

public class CustomersContext: DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    public CustomersContext(DbContextOptions<CustomersContext> options) : base(options)
    {
    }
}