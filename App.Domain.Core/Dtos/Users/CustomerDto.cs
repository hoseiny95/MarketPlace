using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Orders;
using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Orders;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Users;

public class CustomerDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int UserId { get; set; }

    public int ImageId { get; set; }

    public long? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<AuctionDto> Auctions { get; set; } = new List<AuctionDto>();

    public virtual ICollection<BidDto> Bids { get; set; } = new List<BidDto>();

    public virtual ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();

    public virtual ImageDto Image { get; set; } = null!;

    public virtual ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();

    public virtual AppUserDto User { get; set; } = null!;
}
