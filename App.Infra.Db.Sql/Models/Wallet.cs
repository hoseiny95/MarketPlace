using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class Wallet
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public double Balance { get; set; }

    public virtual ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();

    public virtual AppUser User { get; set; } = null!;

    public virtual ICollection<WalletHistory> WalletHistories { get; set; } = new List<WalletHistory>();
}
