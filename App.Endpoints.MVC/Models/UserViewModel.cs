using App.Domain.Core.Dtos.Orders;
using System.ComponentModel.DataAnnotations;

namespace App.Endpoints.MVC.Models;

public class UserViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string userName { get; set; }
    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Name { get; set; } = null!;
    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Lastname { get; set; } = null!;
    [Display(Name = "تلفن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public long phone { get; set; }
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    public string Email { get; set; }
  

}
