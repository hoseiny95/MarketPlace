using App.Domain.Core.Entities.Products;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Products;

public class CategoryDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentId { get; set; }
    public virtual ICollection<CategoryAttributeTitleDto> CategoryAttributeTitles { get; set; } = new List<CategoryAttributeTitleDto>();

    public virtual ICollection<CategoryDto> InverseParent { get; set; } = new List<CategoryDto>();

    public virtual CategoryDto? Parent { get; set; }

    public virtual ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();

}
