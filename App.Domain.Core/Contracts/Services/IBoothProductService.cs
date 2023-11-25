

using App.Domain.Core.Dtos.Admin;
using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Services;

public interface IBoothProductService
{
    Task<List<BoothProductDto>> GetAll(CancellationToken cancellationToken);
    Task<BoothProductDto> GetById(int boothProductId, CancellationToken cancellationToken);
    Task<int> Create(BoothProductDto boothProduct, CancellationToken cancellationToken);
    Task<int> Update(BoothProductDto boothProduct, CancellationToken cancellationToken);
    Task<bool> Delete(int boothProductId, CancellationToken cancellationToken);
    Task<List<ProductAdminDto>> GetAdminProducts(CancellationToken cancellationToken);
    Task<ProductAdminDto> GetAdminProductsbyId(int id, CancellationToken cancellationToken);
    Task UpdateByPrice(int id, string price, CancellationToken cancellationToken);
    Task<List<ProductAdminDto>> GetAdminProductsNotConfirm(CancellationToken cancellationToken);
    Task ConfirmProduct(int id, CancellationToken cancellationToken);
    Task RefuseProduct(int id, CancellationToken cancellationToken);
    Task CreateProductImage(int boothProductId, int imageId, CancellationToken cancellationToken);
    Task<Tuple<List<BoothProductDto>, int>> GetAllPaging(CancellationToken cancellationToken, List<int> ProductsId, int pageId = 1,
        string orderByType = "date", int startPrice = 0, int endPrice = 0);

}
