using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentId { get; set; }

    public virtual ICollection<CategoryAttributeTitle> CategoryAttributeTitles { get; set; } = new List<CategoryAttributeTitle>();

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
