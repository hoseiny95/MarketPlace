namespace App.Endpoints.MVC.Areas.Seller.Models
{
    public class AddProductViewModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public string imagepath { get; set; }
        public bool IsBid { get; set; }
        public int quantity { get; set; }
        public int ImageId { get; set; }
    }
}
