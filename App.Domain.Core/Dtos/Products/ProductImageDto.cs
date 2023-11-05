
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Products;

namespace App.Domain.Core.Dtos.Products;

public class ProductImageDto
{
    public int Id { get; set; }

    public int ImageId { get; set; }

    public int BoothProductId { get; set; }

    public virtual BoothProductDto BoothProduct { get; set; } = null!;

    public virtual ImageDto Image { get; set; } = null!;
}
