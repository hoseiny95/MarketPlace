using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class Auction
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

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual Booth Both { get; set; } = null!;

    public virtual BoothProduct BothProduct { get; set; } = null!;

    public virtual Customer Winner { get; set; } = null!;
}
