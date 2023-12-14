using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Users;
using App.Domain.Services.Generals;
using App.Domain.Services.Products;
using App.Domain.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Users;

public class SellerAppService : ISellerAppService
{
    private readonly ISellerService _sellerService;
    private readonly IAppUserService _appUserService;
    private readonly IImageService _imageService;
    private readonly IBoothService _boothService;

    public SellerAppService(ISellerService sellerService, IAppUserService appUserService,
        IImageService imageService, IBoothService boothService)
    {
        _sellerService = sellerService;
        _appUserService = appUserService;
        _imageService = imageService;
        _boothService = boothService;
    }

    public async Task<List<BoothProductDto>> GetSellerBooths(string userName, CancellationToken cancellationToken)
    {
        var user = await _appUserService.GetByUserName(userName, cancellationToken);
        return await _sellerService.GetBoothsByUserId(user.Id, cancellationToken);
    }
    public async Task<int> GetSellerBoothId(string userName, CancellationToken cancellationToken)
    {
        var user = await _appUserService.GetByUserName(userName, cancellationToken);
        var mee = await _sellerService.GetBoothId(user.Id, cancellationToken);
        return mee;
    }
    public async Task<SellerDto> GetSellerByUserName(string userName, CancellationToken cancellationToken)
    {
        var user = await _appUserService.GetByUserName(userName, cancellationToken);
        return await _sellerService.GetbyUserId(user.Id, cancellationToken);

    }

    public async Task<Tuple<IdentityResult, bool>> EditProfile(SellerDto seller, IFormFile photo, CancellationToken cancellationToken)
    {
        bool check = false;
        IdentityResult result = new IdentityResult();
        var DataSeller = await _sellerService.GetById(seller.Id, cancellationToken);
        if (photo != null)
        {
            var image = await _imageService.GetById((int)DataSeller.Booth.ImageId, cancellationToken);
            var path = _imageService.CreateImagePath(photo);
            _imageService.Image_resize(path[0], path[1], 150);
            var index = path[1].LastIndexOf('\\');
            var imagePath = "smallPic/" + path[1].Substring(index + 1);
            var imageId = await _imageService.Create(imagePath, cancellationToken);
            await _boothService.ImageUpdate((int)DataSeller.BoothId, imageId, cancellationToken);
            if (image != null)
            {
                await _imageService.Delete((int)DataSeller.Booth.ImageId, cancellationToken);
                _imageService.Delete(image.ImagePath);
            }

        }

        seller.BoothId = DataSeller.BoothId;
        seller.Medal = DataSeller.Medal;
        await _sellerService.Update(seller, cancellationToken);
        var user = await _appUserService.GetById(seller.UserId, cancellationToken);
        if (user.UserName != seller.UserName || user.Email != seller.Email)
        {
            user.UserName = seller.UserName;
            user.Email = seller.Email;
            await _appUserService.Update(user, cancellationToken);

            var appUser = new AppUserDto()
            {
                Id = seller.UserId,
                UserName = seller.UserName,
                Email = seller.Email
            };
            result = await _appUserService.Update(appUser, cancellationToken);
            check = true;
        }
        var res = new Tuple<IdentityResult,bool>(result,check);

        return res;

    }


}
