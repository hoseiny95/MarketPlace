using App.Domain.Core.Dtos.Orders;

namespace App.Endpoints.MVC.Models;

public class UserViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string userName { get; set; }
    public string Name { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public long phone { get; set; }

    public string Email { get; set; }
  

}
