using System;
using System.Collections.Generic;

namespace  App.Domain.Core.Dtos.Products;

public class ProductAttributeValueDto
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int AttributeId { get; set; }

    public string AttributeTitle { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;

    public virtual CategoryAttributeTitleDto Attribute { get; set; } = null!;

}
