using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class Seller
{
    public int Id { get; set; }

    public int BoothId { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int UserId { get; set; }

    public int Medal { get; set; }

    public int WalletId { get; set; }

    public long Phone { get; set; }
}
