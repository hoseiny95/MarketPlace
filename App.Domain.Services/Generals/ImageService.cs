using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Entities.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Generals;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<int> Create(string path, CancellationToken cancellationToken)
        => await _imageRepository.create(path, cancellationToken);

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            await _imageRepository.Delete(id, cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<ImageDto> GetById(int imageId, CancellationToken cancellationToken)
        => await _imageRepository.GetById(imageId, cancellationToken);

    public async Task<List<ImageDto>> GetByProductId(int productId, CancellationToken cancellationToken)
        => await _imageRepository.GetByProductId(productId, cancellationToken);

    public async Task<int> Update(string path, int id, CancellationToken cancellationToken)
        => await _imageRepository.Update(path, id, cancellationToken);

}

