﻿using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Orders;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public double PriceSum { get; set; }

    public int Count { get; set; }

    public bool IsBid { get; set; }

    public int OrderStatusId { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual OrderStatus OrderStatus { get; set; } = null!;
}
