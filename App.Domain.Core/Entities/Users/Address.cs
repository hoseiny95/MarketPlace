using App.Domain.Core.Entities.Generals;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Users;

public partial class Address
{
    public int Id { get; set; }

    public int ProvinceId { get; set; }

    public int CityId { get; set; }

    public string Description { get; set; } = null!;

    public int UserId { get; set; }

    public long PostalCode { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Province Province { get; set; } = null!;

    public virtual AppUser User { get; set; } = null!;
}
