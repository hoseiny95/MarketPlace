using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Auctions;

public partial class BidDto
{
    public int Id { get; set; }

    public double Price { get; set; }

    public int CustomerId { get; set; }

    public int AuctionId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual AuctionDto Auction { get; set; } = null!;

    public virtual CustomerDto Customer { get; set; } = null!;
}
