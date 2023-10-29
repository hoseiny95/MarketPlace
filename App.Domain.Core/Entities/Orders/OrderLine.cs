using System;
using System.Collections.Generic;
using App.Domain.Core.Entities.Products;

namespace App.Domain.Core.Entities.Orders;

public partial class OrderLine
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? Count { get; set; }

    public int? BothProductId { get; set; }

    public double? PriceSum { get; set; }

    public virtual BoothProduct? BothProduct { get; set; }

    public virtual Order? Order { get; set; }
}
