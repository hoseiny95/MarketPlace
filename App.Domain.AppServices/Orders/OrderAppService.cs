using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Orders;
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
    private readonly IAppUserService _userService;
    private readonly ICustomerService _customerService;
    private readonly IBoothProductService _boothProductService;
    private readonly IOrderLineService _orderLineService;

    public OrderAppService(IOrderService orderService, IWalletHistoryService walletHistoryService, IWalletService walletService, ISellerService sellerService, IAppUserService userService, ICustomerService customerService,
        IBoothProductService boothProductService, IOrderLineService orderLineService)
    {
        _orderService = orderService;
        _walletHistoryService = walletHistoryService;
        _walletService = walletService;
        _sellerService = sellerService;
        _userService = userService;
        _customerService = customerService;
        _boothProductService = boothProductService;
        _orderLineService = orderLineService;
    }

    public async Task<int> ByeProduct(int BoothProductId, string username, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByUserName(username, cancellationToken);
        var customer = await _customerService.GetByUserId(user.Id, cancellationToken);
        var product = await _boothProductService.GetById(BoothProductId, cancellationToken);
        if(customer.Orders.Any(c => c.OrderStatusId == 1))
        {
            var order = customer.Orders.Where(x => x.OrderStatusId ==1).FirstOrDefault();
            var orderlines = await _orderLineService.GetAllByOrderId(order.Id, cancellationToken);
            order.OrderLines = orderlines;
            var orderline = order.OrderLines.Where(c => c.BothProductId == BoothProductId).FirstOrDefault();
            if (orderline == null)
            {
                var newline = new OrderLineDto()
                {
                    OrderId = order.Id,
                    BothProductId = BoothProductId,
                    Count = 1,
                    PriceSum = product.Price
                };
                await _orderLineService.Create(newline, cancellationToken);
                order.PriceSum = order.PriceSum + product.Price;
                await _orderService.Update(order, cancellationToken);
            }
            else
            {
                orderline.Count = orderline.Count + 1;  
                orderline.PriceSum = product.Price * orderline.Count;
                await _orderLineService.Update(orderline, cancellationToken);
                order.PriceSum = order.PriceSum + product.Price;
                await _orderService.Update(order, cancellationToken);
            }
            return order.Id;
        }
        else
        {
            var order = new OrderDto()
            {
                CustomerId = customer.Id,
                IsBid = false,
                OrderStatusId = 1,
                PriceSum = product.Price,
                CreatedAt = DateTime.Now,
                OrderLines =new List<OrderLineDto>() {new OrderLineDto()
                {
                    BothProductId = BoothProductId,
                    Count = 1,
                    PriceSum = product.Price
                } }

            };
           return await _orderService.Create(order, cancellationToken);

        }        
    }

    public async Task FinishOrder(int orderId, CancellationToken cancellationToken)
    {
        var order = await _orderService.GetById(orderId, cancellationToken);
        order.OrderStatusId = 2;

        await _orderService.Update(order,cancellationToken);
    }

    public async Task<OrderDto> GetbyId(int orderId, CancellationToken cancellationToken)
        => await _orderService.GetById(orderId, cancellationToken);

    public async Task<OrderDto> GetbyUsername(string username, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByUserName(username, cancellationToken);
        var customer = await _customerService.GetByUserId(user.Id, cancellationToken);
        var order = customer.Orders.Where(x => x.OrderStatusId == 1).FirstOrDefault();
        if (order != null)
        {
            var orderlines = await _orderLineService.GetAllByOrderId(order.Id, cancellationToken);
            order.OrderLines = orderlines;
        }
        return order;
    }
    public async Task<List<OrderDto>> GetAllbyUsername(string username, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByUserName(username, cancellationToken);
        var customer = await _customerService.GetByUserId(user.Id, cancellationToken);
        var order = customer.Orders.ToList();
        return order;
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
