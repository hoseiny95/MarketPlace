using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Orders;

public class OrderAppService : IOrderAppService
{
    private readonly IOrderService _orderService;
    private readonly IWalletHistoryService _walletHistoryService;
    private readonly IWalletService _walletService;
    private readonly ISellerService _sellerService;
   

    public OrderAppService(IOrderService orderService, IWalletHistoryService walletHistoryService,
        IWalletService walletService, ISellerService sellerService, IConfiguration configuration)
    {
        _orderService = orderService;
        _walletHistoryService = walletHistoryService;
        _walletService = walletService;
        _sellerService = sellerService;
        
    }

    public async Task UpdateSellersWallet(int orderId, CancellationToken cancellationToken)
    {
        var order = await _orderService.GetById(orderId, cancellationToken);
        foreach (var item in order.OrderLines)
        {
            var walletId = await _walletService.GetByBoothproductId(item.BothProductId, cancellationToken);
            var seller = await _sellerService.GetByBoothProductId(item.BothProductId, cancellationToken);
            var medal = seller.Medal;
            var walletHistory = new List<WalletHistoryDto>()
            {
                new WalletHistoryDto()
                {
                    Amount = item.PriceSum,
                    CreateAt = DateTime.Now,
                    IsCredit = true,
                    WalletId =  walletId,
                    IsSellerFees = false,
                    Description = "فروش کالا"
                },
                new WalletHistoryDto()
                {
                    Amount = (double)(item.PriceSum *seller.MedalNavigation.FeePercentage*(1/100)) ,
                    CreateAt = DateTime.Now,
                    IsCredit = false,
                    WalletId =  walletId,
                    IsSellerFees = true,
                    Description = "کارمزد"
                }
            };
            await _walletHistoryService.AddRange(walletHistory, cancellationToken);
            var result = await _walletHistoryService.GetbySellrId(seller.Id, cancellationToken);
            var AllSells = result.Sum(x => x.Amount);
            switch (AllSells)
            {
                case >= 1230090:
                    seller.Medal = 3;
                    break;

                case > 1230000:
                    seller.Medal = 2;
                    break;
            };
            if (seller.Medal != medal)
                await _sellerService.Update(seller, cancellationToken);
        }
        
    }
}
