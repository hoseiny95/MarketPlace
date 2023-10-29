using System;
using System.Collections.Generic;

namespace App.Infra.Db.Sql.Models;

public partial class MedalStatus
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
}
