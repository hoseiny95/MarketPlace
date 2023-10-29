using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Entities.Generals;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Users;

public class AddressDto
{
    public int Id { get; set; }

    public int ProvinceId { get; set; }

    public int CityId { get; set; }

    public string Description { get; set; } = null!;

    public int UserId { get; set; }

    public long PostalCode { get; set; }

    public virtual CityDto City { get; set; } = null!;

    public virtual ProvinceDto Province { get; set; } = null!;

    public virtual AppUserDto User { get; set; } = null!;
}
