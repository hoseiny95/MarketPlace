using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities.Generals;

public partial class Province
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
