using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public double? BasePrice { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();

    public virtual ICollection<BothProduct> BothProducts { get; set; } = new List<BothProduct>();

    public virtual Category Category { get; set; } = null!;
}
