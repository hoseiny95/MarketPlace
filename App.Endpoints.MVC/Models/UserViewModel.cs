using App.Domain.Core.Dtos.Orders;
using System.ComponentModel.DataAnnotations;

namespace App.Endpoints.MVC.Models;

public class UserViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
 
    public string? userName { get; set; }
    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Name { get; set; } = null!;
    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Lastname { get; set; } = null!;
    [Display(Name = "تلفن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public long phone { get; set; }
   
    public string? Email { get; set; }
  

}
