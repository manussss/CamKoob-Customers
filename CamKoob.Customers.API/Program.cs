var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/v1/customers", async (
    [FromServices] ICustomerRepository customerRepository,
    CreateCustomerDto dto
) =>
{
    var customer = new Customer(dto.CustomerName);
    var contract = new Contract(dto.Product, customer.Id);
    customer.SetContract(contract);

    await customerRepository.AddAsync(customer);

    return Results.NoContent();
})
.WithOpenApi();

app.MapGet("/api/v1/customers", async (
    [FromServices] ICustomerRepository customerRepository
) =>
{
    var customers = await customerRepository.GetAsync();

    if (customers is null || !customers.Any())
        return Results.NotFound();
    
    return Results.Ok(customers.Select(x => new GetCustomerDto
    {
        Id = x.Id,
        Name = x.Name,
        Contract = new GetContractDto
        {
            Id = x.Contract.Id,
            Product = x.Contract.Product
        }
    }));
})
.WithOpenApi();

app.MapGet("/api/v1/customers/{id}", async (
    [FromServices] ICustomerRepository customerRepository,
    Guid id) =>
{
    var customer = await customerRepository.GetByIdAsync(id);

    if (customer is null)
        return Results.NotFound();
    
    return Results.Ok(new GetCustomerDto
    {
        Id = customer.Id,
        Name = customer.Name,
        Contract = new GetContractDto
        {
            Id = customer.Contract.Id,
            Product = customer.Contract.Product
        }
    });
})
.WithOpenApi();

await app.RunAsync();