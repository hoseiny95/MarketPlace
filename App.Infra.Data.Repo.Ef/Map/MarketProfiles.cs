
using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Orders;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Orders;
using App.Domain.Core.Entities.Products;
using App.Domain.Core.Entities.Users;
using AutoMapper;


namespace App.Infra.Data.Repos.Ef.Map;

public class MarketProfiles : Profile
{
    public MarketProfiles()
    {
        //CreateMap<CustomAttributeTemplate, CustomAttributeTemplateInputDto>();
        CreateMap<Auction, AuctionDto>();
        CreateMap<AuctionDto, Auction>();

        CreateMap<Bid, BidDto>();
        CreateMap<BidDto, Bid>();

        CreateMap<Comment, CommentDto>();
        CreateMap<CommentDto, Comment>();

        CreateMap<Image, ImageDto>();
        CreateMap<ImageDto, Image>();

        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();

        CreateMap<OrderLine, OrderLineDto>();
        CreateMap<OrderLineDto, OrderLine>();

        CreateMap<OrderLine, OrderLineDto>();
        CreateMap<OrderLineDto, OrderLine>();

        CreateMap<Booth, BoothDto>();
        CreateMap<BoothDto, Booth>();

        CreateMap<BoothProduct, BoothProductDto>();
        CreateMap<BoothProductDto, BoothProduct>();

        CreateMap<CategoryAttributeTitle, CategoryAttributeTitleDto>();
        CreateMap<CategoryAttributeTitleDto, CategoryAttributeTitle>();

        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();

        CreateMap<ProductAttributeValue, ProductAttributeValueDto>();
        CreateMap<ProductAttributeValueDto, ProductAttributeValue>();

        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();

        CreateMap<ProductImage, ProductImageDto>();
        CreateMap<ProductImageDto, ProductImage>();

        CreateMap<Address, AddressDto>();
        CreateMap<AddressDto, Address>();

        CreateMap<AppUser, AppUserDto>();
        CreateMap<AppUserDto, AppUser>();
        
        CreateMap<MedalStatus, MedalStatusDto>();
        CreateMap<MedalStatusDto, MedalStatus>();

        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();

        CreateMap<Seller, SellerDto>();
        CreateMap<SellerDto, Seller>();

        CreateMap<Wallet, WalletDto>();
        CreateMap<WalletDto, Wallet>();

        CreateMap<WalletHistory, WalletHistoryDto>();
        CreateMap<WalletHistoryDto, WalletHistory>();
    }
}
