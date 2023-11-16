using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Products;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Generals;

public  class ImageDto
{
    public int Id { get; set; }

    public string ImagePath { get; set; } = string.Empty;

    public virtual ICollection<BoothDto> Booths { get; set; } = new List<BoothDto>();

    public virtual ICollection<CustomerDto> Customers { get; set; } = new List<CustomerDto>();

    public virtual ICollection<ProductImageDto> ProductImages { get; set; } = new List<ProductImageDto>();
}
