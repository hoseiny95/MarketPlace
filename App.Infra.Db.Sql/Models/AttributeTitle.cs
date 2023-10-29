using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class AttributeTitle
{
    public int Id { get; set; }

    public string AttributeTitle1 { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();

    public virtual Category Category { get; set; } = null!;
}
