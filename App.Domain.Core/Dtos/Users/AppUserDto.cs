﻿using System;
using System.Collections.Generic;

namespace App.Domain.Core.Dtos.Users;

public class AppUserDto
{
    public int Id { get; set; }

    public int? WalletId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public bool IsSeller { get; set; }
    public bool RememberMe { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<AddressDto> Addresses { get; set; } = new List<AddressDto>();

    public virtual CustomerDto? Customer { get; set; }

    public virtual SellerDto? Seller { get; set; }

    public virtual WalletDto? Wallet { get; set; }
}
