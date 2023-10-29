using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class OrderLine
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? Count { get; set; }

    public int? BothProductId { get; set; }

    public double? PriceSum { get; set; }

    public virtual BothProduct? BothProduct { get; set; }

    public virtual Order? Order { get; set; }
}
