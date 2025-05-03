namespace CamKoob.Customers.Application.DTOs;

public class GetCustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public GetContractDto Contract { get; set; }
}