namespace dotnet_api.Models;

public partial class UserTransaction
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime PaidDate { get; set; }

    public decimal PaidAmount { get; set; }
}
