﻿using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Orders;

public partial class OrderStatus
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
