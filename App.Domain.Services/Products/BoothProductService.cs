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

        public async Task<int> Create(BoothProductDto boothProduct, CancellationToken cancellationToken)
            => await _boothProductRepository.Create(boothProduct, cancellationToken);

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

        public async Task<List<BoothProductDto>> GetAll(CancellationToken cancellationToken)
            => await _boothProductRepository.GetAll(cancellationToken);

        public async Task<BoothProductDto> GetById(int boothProductId, CancellationToken cancellationToken)
            => await _boothProductRepository.GetById(boothProductId, cancellationToken);

        public async Task<int> Update(BoothProductDto boothProduct, CancellationToken cancellationToken)
            => await _boothProductRepository.Update(boothProduct, cancellationToken);
    }
}
