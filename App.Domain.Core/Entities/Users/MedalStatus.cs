namespace App.Domain.Core.Entities.Users;

public partial class MedalStatus
{
    public int Id { get; set; }

    public string Title { get; set; }
    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
