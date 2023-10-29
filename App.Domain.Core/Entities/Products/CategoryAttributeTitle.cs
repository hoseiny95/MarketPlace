using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Products;

public partial class CategoryAttributeTitle
{
    public int Id { get; set; }

    public string AttributeTitle { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();
}
