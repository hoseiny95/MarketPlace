using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string Descriotion { get; set; } = null!;

    public int CustomerId { get; set; }

    public int BoothProductId { get; set; }

    public bool IsConfirm { get; set; }

    public int OrderId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual BoothProduct BoothProduct { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
