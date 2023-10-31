

using App.Domain.Core.Dtos.Generals;

namespace App.Domain.Core.Contracts.Repositories;

public interface IImageRepository
{
    Task<ImageDto> GetById(int imageId, CancellationToken cancellationToken);
    Task<List<ImageDto>> GetByProductId(int productId, CancellationToken cancellationToken);
    Task<int> Update(string path,int id, CancellationToken cancellationToken);
    Task<int> create(string path, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);

}
