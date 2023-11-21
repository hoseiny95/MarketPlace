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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Users
{
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

        public async Task EditProfile(SellerDto seller, IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null)
            {
                var image = await _imageService.GetById((int)seller.Booth.ImageId, cancellationToken);
                var path = _imageService.CreateImagePath(photo);
                _imageService.Image_resize(path[0], path[1], 150);
                var index = path[1].LastIndexOf('\\');
                var imagePath = "smallPic/" + path[1].Substring(index + 1);
                var imageId = await _imageService.Create(imagePath, cancellationToken);
                if (image != null)
                {
                    await _imageService.Delete((int)seller.Booth.ImageId, cancellationToken);
                    _imageService.Delete(image.ImagePath);
                }
                seller.Booth.ImageId = imageId;
                await _boothService.Update(seller.Booth, cancellationToken);
            }
          
            await _sellerService.Update(seller, cancellationToken);
            var user = await _appUserService.GetById(seller.UserId, cancellationToken);
            user.UserName = seller.UserName;
            user.Email = seller.Email; 
            await _appUserService.Update(user, cancellationToken);
        }
    }
}
