using App.Domain.Core.Entities.Products;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Users;

public partial class Seller
{
    public int Id { get; set; }

    public int BoothId { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int UserId { get; set; }

    public int Medal { get; set; }

    public long Phone { get; set; }

    public virtual Booth? Booth { get; set; } 

    public virtual MedalStatus MedalNavigation { get; set; } = null!;

    public virtual AppUser User { get; set; } = null!;

}
