using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class ProductAttributeValue
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int AttributeId { get; set; }

    public string AttributeTitle { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;

    public virtual CategoryAttributeTitle Attribute { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
