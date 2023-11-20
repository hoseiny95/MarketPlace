using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Users;

public class SellerService : ISellerService
{
    private readonly ISellerRepository _sellerRepository;

    public SellerService(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<int> Create(SellerDto seller, CancellationToken cancellationToken)
        => await _sellerRepository.Create(seller, cancellationToken);

    public async Task<bool> Delete(int sellerId, CancellationToken cancellationToken)
    {
        try
        {
            await _sellerRepository.Delete(sellerId, cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<SellerDto>> GetAll(CancellationToken cancellationToken)
        => await _sellerRepository.GetAll(cancellationToken);

    public async Task<int> GetBoothId(int userId, CancellationToken cancellationToken)
        => await _sellerRepository.GetBoothId(userId, cancellationToken);

    public async Task<List<BoothProductDto>> GetBoothsByUserId(int userId, CancellationToken cancellationToken)
        => await _sellerRepository.GetBoothsByUserId(userId, cancellationToken);

    public async Task<SellerDto> GetByBoothProductId(int boothProductId, CancellationToken cancellationToken)
        => await _sellerRepository.GetByBoothProductId(boothProductId, cancellationToken);

    public async Task<SellerDto> GetById(int sellerId, CancellationToken cancellationToken)
        => await _sellerRepository.GetById(sellerId, cancellationToken);

    public async Task<SellerDto> GetbyUserId(int userId, CancellationToken cancellationToken)
        => await _sellerRepository.GetbyUserId(userId, cancellationToken);

    public async Task<int> Update(SellerDto seller, CancellationToken cancellationToken)
        => await _sellerRepository.Update(seller, cancellationToken);
}
