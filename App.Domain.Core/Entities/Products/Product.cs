using System;
using System.Collections.Generic;
using App.Domain.Core.Entities.Products;

namespace App.Domain.Core.Entities.Products;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public double? BasePrice { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<BoothProduct> BoothProducts { get; set; } = new List<BoothProduct>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();
}
