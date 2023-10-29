using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Orders;

public partial class OrderDto
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public double PriceSum { get; set; }

    public int Count { get; set; }

    public bool IsBid { get; set; }

    public int OrderStatusId { get; set; }

    public virtual ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();

    public virtual CustomerDto Customer { get; set; } = null!;

    public virtual ICollection<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>();

    public virtual OrderStatusDto OrderStatus { get; set; } = null!;
}
