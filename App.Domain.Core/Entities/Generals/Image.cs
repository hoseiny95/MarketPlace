using App.Domain.Core.Entities.Products;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Generals;

public partial class Image
{
    public int Id { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
