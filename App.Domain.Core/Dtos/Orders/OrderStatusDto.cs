using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Orders;
public partial class OrderStatusDto
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();
}
