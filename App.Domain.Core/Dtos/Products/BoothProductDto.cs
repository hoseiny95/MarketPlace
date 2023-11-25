using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Orders;
using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Orders;
using App.Domain.Core.Entities.Products;
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

    public string Description { get; set; } 

    public bool IsAvailable { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<AuctionDto> Auctions { get; set; } = new List<AuctionDto>();

    public virtual Booth Both { get; set; }

    public virtual ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();

    public virtual ICollection<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>();

    public virtual ProductDto Product { get; set; }

    public virtual ICollection<ProductImageDto> ProductImages { get; set; } = new List<ProductImageDto>();


}
