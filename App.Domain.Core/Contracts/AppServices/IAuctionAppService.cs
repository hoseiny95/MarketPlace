using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices;

public interface IAuctionAppService
{
    Task<int> StartAuction(int boothId, double minPrice, int duration, int BoothProdectId, CancellationToken cancellationToken);
    Task EndAuction(int auctionId, CancellationToken cancellationToken);
    Task<double> GetLastPrice(int auctionId, CancellationToken cancellationToken);
    Task CreateBid(string username, int auctionId, double price, CancellationToken cancellationToken);
}
