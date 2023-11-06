using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Entities.Auctions;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace App.Domain.Services.Generals;
public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<int> Create(string imagePath, CancellationToken cancellationToken)
        => await _imageRepository.create(imagePath, cancellationToken);
    
    //public string CreateImagePath(IFormFile file)
    //{
    //    string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/pic");
    //    var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
    //    string filePath = Path.Combine(uploadFolder, fileName);
    //    using (var fileStream = new FileStream(filePath, FileMode.Create))
    //    {
    //        file.CopyTo(fileStream);
    //    }
    //    return filePath;
    //}
    public string CreateSmallImagePath(IFormFile file)
    {
        string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/smallPic");
        var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        string filePath = Path.Combine(uploadFolder, fileName);

        return filePath;
    }
    public List<string> CreateImagePath(IFormFile file)
    {
        var list = new List<string>();
        string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/pic");
        string uploadSmallFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/smallPic");
        string ext = Path.GetExtension(file.FileName);
        var fileName = Guid.NewGuid().ToString() + "_" + ext;
        string filePath = Path.Combine(uploadFolder, fileName);
        string fileSmallPath = Path.Combine(uploadSmallFolder, fileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }
        list.Add(filePath);
        list.Add(fileSmallPath);
        list.Add("smallPic/" + fileName);
        return list;
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
    public void Image_resize(string input_Image_Path, string output_Image_Path, int new_Width)
    {

        const long quality = 50L;

        Bitmap source_Bitmap = new Bitmap(input_Image_Path);



        double dblWidth_origial = source_Bitmap.Width;

        double dblHeigth_origial = source_Bitmap.Height;

        double relation_heigth_width = dblHeigth_origial / dblWidth_origial;

        int new_Height = (int)(new_Width * relation_heigth_width);



        //< create Empty Drawarea >

        var new_DrawArea = new Bitmap(new_Width, new_Height);

        //</ create Empty Drawarea >



        using (var graphic_of_DrawArea = Graphics.FromImage(new_DrawArea))

        {

            //< setup >

            graphic_of_DrawArea.CompositingQuality = CompositingQuality.HighSpeed;

            graphic_of_DrawArea.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphic_of_DrawArea.CompositingMode = CompositingMode.SourceCopy;

            //</ setup >



            //< draw into placeholder >

            //*imports the image into the drawarea

            graphic_of_DrawArea.DrawImage(source_Bitmap, 0, 0, new_Width, new_Height);

            //</ draw into placeholder >



            //--< Output as .Jpg >--

            using (var output = System.IO.File.Open(output_Image_Path, FileMode.Create))

            {

                //< setup jpg >

                var qualityParamId = System.Drawing.Imaging.Encoder.Quality;

                var encoderParameters = new EncoderParameters(1);

                encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);

                //</ setup jpg >



                //< save Bitmap as Jpg >

                var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                new_DrawArea.Save(output, codec, encoderParameters);

                //resized_Bitmap.Dispose ();

                output.Close();

                //</ save Bitmap as Jpg >

            }


            graphic_of_DrawArea.Dispose();

        }

        source_Bitmap.Dispose();
    }

    public async Task<ImageDto> GetByBothProductId(int BothproductId, CancellationToken cancellationToken)
        => await _imageRepository.GetByBothProductId(BothproductId, cancellationToken);

    public bool Delete(string path)
    {
        try
        {
            string imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + path);
            FileInfo file = new FileInfo(imagepath);
            file.Delete();
            return true;
        }
        catch
        {
            return false;
        }
       

    }
}

