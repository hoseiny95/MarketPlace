

using App.Domain.Core.Dtos.Generals;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Contracts.Services;

public interface IImageService
{
    Task<ImageDto> GetById(int imageId, CancellationToken cancellationToken);
    Task<List<ImageDto>> GetByProductId(int productId, CancellationToken cancellationToken);
    Task<int> Update(string path,int id, CancellationToken cancellationToken);
    Task<int> Create(IFormFile file, CancellationToken cancellationToken);
    Task<bool> Delete(int id, CancellationToken cancellationToken);
    void Image_resize(string input_Image_Path, string output_Image_Path, int new_Width);
    Task<ImageDto> GetByBothProductId(int BothproductId, CancellationToken cancellationToken);
    string CreateSmallImagePath(IFormFile file);
    List<string> CreateImagePath(IFormFile file);

}
