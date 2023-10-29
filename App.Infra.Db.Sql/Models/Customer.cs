using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int UserId { get; set; }

    public int ImageId { get; set; }

    public int WallwtId { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
