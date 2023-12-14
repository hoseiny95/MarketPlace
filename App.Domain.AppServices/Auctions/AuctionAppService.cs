using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Auctions;

public class AuctionAppService : IAuctionAppService
{
    private readonly IAuctionService _auctionService;
    private readonly IBoothProductService _boothProductService;
    private readonly ICustomerService _customerService;
    private readonly IAppUserService _userService;
    private readonly IBidService _bidService;

    public AuctionAppService(IAuctionService auctionService, IBoothProductService boothProductService, 
        ICustomerService customerService, IAppUserService userService, IBidService bidService)
    {
        _auctionService = auctionService;
        _boothProductService = boothProductService;
        _customerService = customerService;
        _userService = userService;
        _bidService = bidService;
    }

    public async Task<int> StartAuction(int boothId, double minPrice, int duration, int BoothProdectId, 
        CancellationToken cancellationToken)
    {
        var AuctionDto = new AuctionDto()
        {
            BothId = boothId,
            BothProductId = BoothProdectId,
            MinPrice = minPrice,
            Starttime = DateTime.Now,
            Endtime = DateTime.Now.AddHours(duration),
            CreateAt = DateTime.Now,
            IsSold = false,
            LastPrice = minPrice
          
        };
        int AuctionId = await _auctionService.Create(AuctionDto, cancellationToken);
        var boothProduct = await _boothProductService.GetById(BoothProdectId, cancellationToken);
        boothProduct.IsBid = true;
        await _boothProductService.BidUpdate(boothProduct, cancellationToken);
        return AuctionId;
    }
    public async Task EndAuction(int auctionId, CancellationToken cancellationToken)
    {
        var auction = await _auctionService.GetById(auctionId, cancellationToken);
        foreach(var item in auction.Bids)
        {
            if (item.Price == auction.LastPrice )
                auction.WinnerId = item.CustomerId;
        }
        var boothProduct = await _boothProductService.GetById(auction.BothProductId, cancellationToken);
        boothProduct.IsBid = false;
        if (auction.WinnerId == 0)
            boothProduct.IsAvailable = false;
        await _boothProductService.BidUpdate(boothProduct, cancellationToken);
        auction.IsSold = true;
        await _auctionService.Update(auction, cancellationToken);
    }

    public async Task<double> GetLastPrice(int auctionId, CancellationToken cancellationToken)
    {
        var auction = await _auctionService.GetById(auctionId, cancellationToken);
        return auction.LastPrice;
    }

    public async Task CreateBid(string username, int auctionId, double price, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByUserName(username, cancellationToken);
        var customer = await _customerService.GetByUserId(user.Id, cancellationToken);
        var bid = new BidDto()
        {
            AuctionId = auctionId,
            CustomerId = customer.Id,
            Price = price,
            CreateAt = DateTime.UtcNow,
        };
        await _bidService.Create(bid, cancellationToken);
        var auction = await _auctionService.GetById(auctionId, cancellationToken);
        auction.LastPrice = price;
        await _auctionService.Update(auction, cancellationToken);

    }
}
