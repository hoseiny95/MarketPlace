using App.Domain.Core.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.Entities.Users;

public partial class Seller
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }

    public int? BoothId { get; set; }

    public string? Name { get; set; } 

    public string? Lastname { get; set; } 

    public int UserId { get; set; }

    public int? Medal { get; set; }

    public long? Phone { get; set; }

    public virtual Booth? Booth { get; set; } 

    public virtual MedalStatus? MedalNavigation { get; set; } = null!;

    public virtual AppUser User { get; set; } = null!;

}
