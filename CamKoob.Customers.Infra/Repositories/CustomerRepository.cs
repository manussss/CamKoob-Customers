namespace CamKoob.Customers.Infra.Repositories;

public class CustomerRepository(CustomersContext context) : ICustomerRepository
{
    public async Task AddAsync(Customer customer)
    {
        await context.AddAsync(customer);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Customer>> GetAsync()
    {
        return await context
            .Customers
            .Include(c => c.Contract)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await context
            .Customers
            .Include(c => c.Contract)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}