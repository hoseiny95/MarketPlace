using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class Image
{
    public int Id { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
