using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class AppUser
{
    public int Id { get; set; }

    public int? WalletId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Wallet? Wallet { get; set; }

    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}
