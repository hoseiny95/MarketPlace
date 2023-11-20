using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Auctions;
using AutoMapper;

namespace App.Endpoints.MVC.Models
{
    public class MarketUiProfile : Profile
    {
        public MarketUiProfile()
        {
            //CreateMap<AppUserDto, RegisterViewModel>();
            CreateMap<RegisterViewModel, AppUserDto > ();
            CreateMap<LoginViewModel, AppUserDto > ();
            CreateMap<UserViewModel, CustomerDto > ();
            CreateMap<CustomerDto, UserViewModel> ();
            CreateMap<UserViewModel, SellerDto>();
            CreateMap<SellerDto, UserViewModel>();

        }
    }
}
