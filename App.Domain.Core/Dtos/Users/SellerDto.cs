using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Products;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Users;

public class SellerDto
{
    public int Id { get; set; }

    public int BoothId { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int UserId { get; set; }

    public int Medal { get; set; }

    public long Phone { get; set; }

    public virtual BoothDto Booth { get; set; } = null!;

    public virtual MedalStatusDto MedalNavigation { get; set; } = null!;

    public virtual AppUserDto User { get; set; } = null!;

}
