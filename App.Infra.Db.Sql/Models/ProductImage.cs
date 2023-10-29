using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public int ImageId { get; set; }

    public int BoothProductId { get; set; }

    public virtual BothProduct BoothProduct { get; set; } = null!;

    public virtual Image Image { get; set; } = null!;
}
