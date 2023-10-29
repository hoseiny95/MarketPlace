using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Orders;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Users;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int UserId { get; set; }

    public int ImageId { get; set; }

    public long? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Image Image { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual AppUser User { get; set; } = null!;
}
