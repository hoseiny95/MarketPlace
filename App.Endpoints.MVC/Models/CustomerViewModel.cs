using App.Domain.Core.Dtos.Orders;

namespace App.Endpoints.MVC.Models;

public class CustomerViewModel
{
    public int Id { get; set; }
    public string userName { get; set; }
    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string ImagePath { get; set; }

    public long? Phone { get; set; }

    public string? Email { get; set; }
  

}
