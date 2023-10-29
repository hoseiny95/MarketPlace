using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Users;

public partial class WalletDto
{
    public int Id { get; set; }


    public double Balance { get; set; }

    public virtual AppUserDto? AppUser { get; set; }

    public virtual ICollection<WalletHistoryDto> WalletHistories { get; set; } = new List<WalletHistoryDto>();
}
