using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Admin;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products
{
    public class BoothProductService : IBoothProductService
    {
        private readonly IBoothProductRepository _boothProductRepository;

        public BoothProductService(IBoothProductRepository boothProductRepository)
        {
            _boothProductRepository = boothProductRepository;
        }

        public async Task ConfirmProduct(int id, CancellationToken cancellationToken)
            => await _boothProductRepository.ConfirmProduct(id, cancellationToken);

        public async Task<int> Create(BoothProductDto boothProduct, CancellationToken cancellationToken)
            => await _boothProductRepository.Create(boothProduct, cancellationToken);

        public async Task CreateProductImage(int boothProductId, int imageId, CancellationToken cancellationToken)
            => await _boothProductRepository.CreateProductImage(boothProductId, imageId, cancellationToken);

        public async Task<bool> Delete(int boothProductId, CancellationToken cancellationToken)
        {
            try
            {
                await _boothProductRepository.Delete(boothProductId, cancellationToken);
                return true;
            }
            catch { return false; }
        }

        public async Task<List<ProductAdminDto>> GetAdminProducts(CancellationToken cancellationToken)
            => await _boothProductRepository.GetAdminProducts(cancellationToken);

        public async Task<ProductAdminDto> GetAdminProductsbyId(int id, CancellationToken cancellationToken)
            => await _boothProductRepository.GetAdminProductsbyId(id, cancellationToken);

        public async Task<List<ProductAdminDto>> GetAdminProductsNotConfirm(CancellationToken cancellationToken)
            => await _boothProductRepository.GetAdminProductsNotConfirm(cancellationToken);

        public async Task<List<BoothProductDto>> GetAll(CancellationToken cancellationToken)
            => await _boothProductRepository.GetAll(cancellationToken);

        public async Task<Tuple<List<BoothProductDto>, int>> GetAllPaging(CancellationToken cancellationToken, List<int> ProductsId , int pageId = 1, 
            string orderByType = "date", int startPrice = 0, int endPrice = 0)
            => await _boothProductRepository.GetAllPaging(cancellationToken, ProductsId, pageId, orderByType, startPrice, endPrice);

        public async Task<BoothProductDto> GetById(int boothProductId, CancellationToken cancellationToken)
            => await _boothProductRepository.GetById(boothProductId, cancellationToken);


        public async Task RefuseProduct(int id, CancellationToken cancellationToken)
            => await _boothProductRepository.RefuseProduct(id, cancellationToken);

        public async Task<int> Update(BoothProductDto boothProduct, CancellationToken cancellationToken)
            => await _boothProductRepository.Update(boothProduct, cancellationToken);

        public async Task UpdateByPrice(int id, string price, CancellationToken cancellationToken)
            => await _boothProductRepository.UpdateByPrice(id, price, cancellationToken);
    }
}
