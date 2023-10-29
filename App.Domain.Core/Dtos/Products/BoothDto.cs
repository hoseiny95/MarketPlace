using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Products;

public  class BoothDto
{
    public int Id { get; set; }

    public bool IsDeleted { get; set; }

    public string Name { get; set; } = null!;

    public int ImageId { get; set; }

    public DateTime CreatedAt { get; set; }

    public long Phone { get; set; }

    public string Description { get; set; } = null!;

    public bool IsSuprior { get; set; }

    public int CityId { get; set; }


}
