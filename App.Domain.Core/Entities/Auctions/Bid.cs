using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Auctions;

public partial class Bid
{
    public int Id { get; set; }

    public double Price { get; set; }

    public int CustomerId { get; set; }

    public int AuctionId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual Auction Auction { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
