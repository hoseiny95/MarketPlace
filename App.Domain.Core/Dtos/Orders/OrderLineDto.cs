using System;
using System.Collections.Generic;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Products;

namespace App.Domain.Core.Dtos.Orders;

public partial class OrderLineDto
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int Count { get; set; }

    public int BothProductId { get; set; }

    public double PriceSum { get; set; }

    public virtual BoothProductDto? BothProduct { get; set; }

    public virtual OrderDto? Order { get; set; }
}
