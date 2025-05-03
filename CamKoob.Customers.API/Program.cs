var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/v1/customers", async () =>
{
    
})
.WithOpenApi();

app.MapGet("/api/v1/customers", async () =>
{
    
})
.WithOpenApi();

app.MapGet("/api/v1/customers/{id}", async (Guid id) =>
{
    
})
.WithOpenApi();

await app.RunAsync();