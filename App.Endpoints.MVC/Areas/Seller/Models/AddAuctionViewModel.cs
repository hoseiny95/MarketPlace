using System.ComponentModel.DataAnnotations;

namespace App.Endpoints.MVC.Areas.Seller.Models;

public class AddAuctionViewModel
{
    public int BoothProductId { get; set; }
    public int BoothId { get; set; }
    [Display(Name = "قیمت پایه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
  
    public double MinPrice { get; set; }
    [Display(Name = "مدت مزایده ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    
    public int Duration { get; set; }
}
