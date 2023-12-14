using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Products;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Products;

public  class BoothDto
{
    public int Id { get; set; }

    public bool IsDeleted { get; set; }

    public string? Name { get; set; } = null!;

    public int? ImageId { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? Phone { get; set; }

    public string? Description { get; set; } = null!;

    public bool IsSuprior { get; set; }

    public int? CityId { get; set; }

    public virtual ICollection<AuctionDto>? Auctions { get; set; } = new List<AuctionDto>();

    public virtual ICollection<BoothProductDto>? BoothProducts { get; set; } = new List<BoothProductDto>();

    public virtual City? City { get; set; } = null!;

    public virtual Image? Image { get; set; } = null!;

    public virtual SellerDto? Seller { get; set; }
}
