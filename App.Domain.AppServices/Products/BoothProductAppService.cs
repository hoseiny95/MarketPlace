using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Admin;
using App.Domain.Core.Dtos.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Products
{
    public class BoothProductAppService : IBoothProductAppService
    {
        private IBoothProductService _boothProductService;
        private IProductService _productService;
        private IBoothService _boothService;
        private IImageService _imageService;

        public BoothProductAppService(IBoothProductService boothProductService, 
            IProductService productService, IBoothService boothService, IImageService imageService)
        {
            _boothProductService = boothProductService;
            _productService = productService;
            _boothService = boothService;
            _imageService = imageService;
        }

        public async Task ConfirmProduct(int id, CancellationToken cancellationToken)
            => await _boothProductService.ConfirmProduct(id, cancellationToken);

        public async Task<List<ProductAdminDto>> GetAdminProductsNotConfirm(CancellationToken cancellationToken)
            => await _boothProductService.GetAdminProductsNotConfirm(cancellationToken);

        public async Task UpdateAdminProduct(ProductAdminDto adminProduct, IFormFile photo, 
            CancellationToken cancellationToken)
        {
            var entity = await _boothProductService.GetById(adminProduct.Id, cancellationToken);
            var product = await _productService.GetById(entity.ProductId, cancellationToken);
            var booth = await  _boothService.GetById(entity.BothId, cancellationToken);
            if(entity.Price.ToString() != adminProduct.price)
               await _boothProductService.UpdateByPrice(adminProduct.Id, adminProduct.price, cancellationToken);
            if(product.Name != adminProduct.Name || product.Description != adminProduct.Description)
            {
                product.Description = adminProduct.Description;
                product.Name = adminProduct.Name;
               await _productService.Update(product, cancellationToken);
            }
            if(booth.Name != adminProduct.BoothName)
            {
                booth.Name = adminProduct.BoothName;
                await _boothService.Update(booth, cancellationToken);
            }
            if(photo != null)
            {
                var path = _imageService.CreateImagePath(photo);
                _imageService.Image_resize(path[0], path[1] , 150);
                var image = await _imageService.GetByBothProductId(adminProduct.Id, cancellationToken);
                await _imageService.Update(path[2], image.Id,cancellationToken);

            }
            
        }
    }
}
