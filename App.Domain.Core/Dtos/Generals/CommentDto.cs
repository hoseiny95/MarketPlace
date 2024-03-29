﻿using App.Domain.Core.Dtos.Orders;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Orders;
using App.Domain.Core.Entities.Products;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Generals;

public  class CommentDto
{
    public int Id { get; set; }

    public string Descriotion { get; set; } = null!;

    public int CustomerId { get; set; }
    public  string CustomerName { get; set; }
    public  string BoothProductName { get; set; }
    public  string BoothName { get; set; }

    public int BoothProductId { get; set; }

    public bool IsConfirm { get; set; }

    public int OrderId { get; set; }

    public DateTime CreateAt { get; set; }
    public bool IsRefuse { get; set; }

    public virtual BoothProduct BoothProduct { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
