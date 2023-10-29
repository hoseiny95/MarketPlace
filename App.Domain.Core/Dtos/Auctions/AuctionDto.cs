using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Products;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Auctions;

public class AuctionDto
{
    public int Id { get; set; }

    public int BothProductId { get; set; }

    public double LastPrice { get; set; }

    public double MinPrice { get; set; }

    public int BothId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public bool IsSold { get; set; }

    public DateTime Starttime { get; set; }

    public DateTime Endtime { get; set; }

    public int WinnerId { get; set; }

    public virtual ICollection<BidDto> Bids { get; set; } = new List<BidDto>();

    public virtual BoothDto Both { get; set; } = null!;

    public virtual BoothProductDto BothProduct { get; set; } = null!;

    public virtual CustomerDto Winner { get; set; } = null!;
}
