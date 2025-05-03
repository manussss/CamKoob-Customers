namespace CamKoob.Customers.IoC;

public static class DatabaseInjection
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CustomersContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("CustomersConnection")));
    }
}