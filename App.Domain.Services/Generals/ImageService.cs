using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Generals;

public class ImageService : IImageService
{
    public Task Delete(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ImageDto> GetById(int imageId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<ImageDto>> GetByProductId(int productId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(string path, int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
