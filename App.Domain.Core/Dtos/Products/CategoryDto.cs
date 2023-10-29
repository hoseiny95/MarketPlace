using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Products;

public class CategoryDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentId { get; set; }

  
}
