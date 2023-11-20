using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Users;

public partial class AppUser : IdentityUser<int>
{
    public int? WalletId { get; set; }
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Customer? Customer { get; set; }

    public virtual Seller? Seller { get; set; }

    public virtual Wallet? Wallet { get; set; }
}
