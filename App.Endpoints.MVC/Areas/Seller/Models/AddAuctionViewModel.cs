namespace App.Endpoints.MVC.Areas.Seller.Models;

public class AddAuctionViewModel
{
    public int BoothProductId { get; set; }
    public int BoothId { get; set; }
    public double MinPrice { get; set; }
    public int Duration { get; set; }
}
