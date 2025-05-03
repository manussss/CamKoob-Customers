namespace CamKoob.Customers.Domain.Interfaces;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
    Task<IEnumerable<Customer>> GetAsync();
    Task<Customer?> GetByIdAsync(Guid id);
}