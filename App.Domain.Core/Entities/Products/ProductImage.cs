
using App.Domain.Core.Entities.Generals;

namespace App.Domain.Core.Entities.Products;

public partial class ProductImage
{
    public int Id { get; set; }

    public int ImageId { get; set; }

    public int BoothProductId { get; set; }

    public virtual BoothProduct BoothProduct { get; set; } = null!;

    public virtual Image Image { get; set; } = null!;
}
