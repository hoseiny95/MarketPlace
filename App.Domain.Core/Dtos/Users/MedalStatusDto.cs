namespace App.Domain.Core.Dtos.Users;

public class MedalStatusDto
{
    public int Id { get; set; }

    public string Title { get; set; }
    public int? FeePercentage { get; set; }
    public virtual ICollection<SellerDto> Sellers { get; set; } = new List<SellerDto>();
}
