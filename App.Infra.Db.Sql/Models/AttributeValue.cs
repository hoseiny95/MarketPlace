using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class AttributeValue
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int AttributeId { get; set; }

    public string AttributeTitle { get; set; } = null!;

    public string AttributeValue1 { get; set; } = null!;

    public virtual AttributeTitle Attribute { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
