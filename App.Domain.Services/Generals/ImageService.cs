using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Entities.Auctions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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

    public async Task<int> Create(IFormFile file, CancellationToken cancellationToken)
    {
        string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
        var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        string filePath = Path.Combine(uploadFolder, fileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }
     
       return  await _imageRepository.create(filePath, cancellationToken);
    }
       

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

