using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Products;

public partial class Booth
{
    public int Id { get; set; }

    public bool IsDeleted { get; set; }

    public string Name { get; set; } = null!;

    public int ImageId { get; set; }

    public DateTime CreatedAt { get; set; }

    public long Phone { get; set; }

    public string Description { get; set; } = null!;

    public bool IsSuprior { get; set; }

    public int CityId { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual ICollection<BoothProduct> BoothProducts { get; set; } = new List<BoothProduct>();

    public virtual City City { get; set; } = null!;

    public virtual Image Image { get; set; } = null!;

    public virtual Seller? Seller { get; set; }
}
