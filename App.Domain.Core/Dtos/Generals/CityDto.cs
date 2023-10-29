using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Products;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Generals;

public  class CityDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProvinceId { get; set; }

    public virtual ICollection<AddressDto> Addresses { get; set; } = new List<AddressDto>();

    public virtual ICollection<BoothDto> Booths { get; set; } = new List<BoothDto>();

    public virtual ProvinceDto Province { get; set; } = null!;
}
