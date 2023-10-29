using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProvinceId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual Province Province { get; set; } = null!;
}
