using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Users;

public partial class WalletHistory
{
    public int Id { get; set; }

    public bool IsDebit { get; set; }

    public double Amount { get; set; }

    public DateTime CreateAt { get; set; }

    public bool IsCredit { get; set; }

    public int WalletId { get; set; }

    public string Description { get; set; } = null!;

    public bool IsSellerFees { get; set; }

    public virtual Wallet Wallet { get; set; } = null!;
}
