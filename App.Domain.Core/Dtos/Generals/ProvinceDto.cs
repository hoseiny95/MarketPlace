using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Generals;

public class ProvinceDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AddressDto> Addresses { get; set; } = new List<AddressDto>();

    public virtual ICollection<CityDto> Cities { get; set; } = new List<CityDto>();
}
