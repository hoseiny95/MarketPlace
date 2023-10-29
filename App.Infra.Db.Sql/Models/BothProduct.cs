using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class BothProduct
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

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual Both Both { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
