using App.Domain.Core.Dtos.Products;

namespace App.Endpoints.MVC.Areas.Seller.Models;

public class CreateBothProductViewModel
{
    public int categoryId { get; set; }
    public int subcategoryId { get; set; }
    public int subcategory2Id { get; set; }
    public int BoothId { get; set; }
    public List<ProductDto> products { get; set; }

}
