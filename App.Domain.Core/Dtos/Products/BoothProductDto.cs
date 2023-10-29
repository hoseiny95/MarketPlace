using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Orders;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Products;

public class BoothProductDto
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int BothId { get; set; }

    public double Price { get; set; }

    public bool IsBid { get; set; }

    public int Quantity { get; set; }

    public bool IsConfirm { get; set; }

    public string Description { get; set; } = null!;

    public bool IsAvailable { get; set; }


}
