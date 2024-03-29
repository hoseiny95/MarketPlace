﻿

using App.Domain.Core.Dtos.Admin;
using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Repositories;

public interface IBoothProductRepository
{
    Task<List<BoothProductDto>> GetAll(CancellationToken cancellationToken);
    Task<BoothProductDto> GetById(int boothProductId, CancellationToken cancellationToken);
    Task<int> Create(BoothProductDto boothProduct, CancellationToken cancellationToken);
    Task<int> Update(BoothProductDto boothProduct, CancellationToken cancellationToken);
    Task Delete(int boothProductId, CancellationToken cancellationToken);
    Task<List<ProductAdminDto>> GetAdminProducts(CancellationToken cancellationToken);
    Task<ProductAdminDto> GetAdminProductsbyId(int id, CancellationToken cancellationToken);
    Task UpdateByPrice(int id, string price, CancellationToken cancellationToken);
    Task<List<ProductAdminDto>> GetAdminProductsNotConfirm(CancellationToken cancellationToken);
    Task ConfirmProduct(int id, CancellationToken cancellationToken);
    Task RefuseProduct(int id, CancellationToken cancellationToken);
    Task CreateProductImage(int boothProductId, int imageId, CancellationToken cancellationToken);
    Task<Tuple<List<BoothProductDto>, int>> GetAllPaging(CancellationToken cancellationToken, List<int> ProductsId, int pageId = 1,
        string orderByType = "date", int startPrice = 0, int endPrice = 0, string filter = null);
    Task<int> BidUpdate(BoothProductDto boothProduct, CancellationToken cancellationToken);
    Task<List<BoothProductDto>> GetByBoothId(int boothId, CancellationToken cancellationToken);
    Task<List<BoothProductDto>> GetAllByName(string name, CancellationToken cancellationToken);
}
