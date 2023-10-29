using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Users;

public partial class Wallet
{
    public int Id { get; set; }


    public double Balance { get; set; }

    public virtual AppUser? AppUser { get; set; }

    public virtual ICollection<WalletHistory> WalletHistories { get; set; } = new List<WalletHistory>();
}
