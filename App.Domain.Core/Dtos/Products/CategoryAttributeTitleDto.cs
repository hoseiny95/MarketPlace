using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Products;

public partial class CategoryAttributeTitleDto
{
    public int Id { get; set; }

    public string AttributeTitle { get; set; } = null!;

    public int CategoryId { get; set; }


}
