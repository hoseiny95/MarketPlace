using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using App.Domain.Services.Generals;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Products
{
    public class BoothAppService : IBoothAppService
    {
        private readonly IBoothService _boothService;
        private readonly IImageService _imageService;

        public BoothAppService(IBoothService boothService, IImageService imageService)
        {
            _boothService = boothService;
            _imageService = imageService;
        }

        public async Task<List<BoothDto>> GetAll(CancellationToken cancellationToken)
            => await _boothService.GetAll(cancellationToken);

        public async Task<BoothDto> GetById(int boothId, CancellationToken cancellationToken)
            => await _boothService.GetById(boothId, cancellationToken);

        public async Task Update(BoothDto boothDto, IFormFile photo, CancellationToken cancellationToken)
        {
            var image = await _imageService.GetById(boothDto.ImageId, cancellationToken);
            if (photo != null)
            {
                var path = _imageService.CreateImagePath(photo);
                _imageService.Image_resize(path[0], path[1], 150);
                var index = path[1].LastIndexOf('\\');
                var imagePath = "smallPic/" + path[1].Substring(index + 1);
                var imageId = await _imageService.Create(imagePath, cancellationToken);
                await _imageService.Delete(boothDto.ImageId, cancellationToken);
                _imageService.Delete(image.ImagePath);
                boothDto.ImageId = imageId;
            }
            await _boothService.Update(boothDto, cancellationToken);
        }
        public async Task<List<BoothDto>> GetAllDeleted(CancellationToken cancellationToken)
            => await _boothService.GetAllDeleted(cancellationToken);

        public async Task<bool> Delete(int boothId, CancellationToken cancellationToken)
            => await _boothService.Delete(boothId, cancellationToken);

        public async Task Return(int boothId, CancellationToken cancellationToken)
        {
            var res = await _boothService.GetById(boothId, cancellationToken);
            res.IsDeleted = false;
            await _boothService.Update(res, cancellationToken);
           
        }
    }
}
