using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Domain.Services.Generals;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Users;

public class CustomerAppService : ICustomerAppService
{
    private readonly IAppUserService _appUserService;
    private readonly ICustomerService _customerService;
    private readonly IImageService _imageService;

    public CustomerAppService(IAppUserService appUserService, ICustomerService customerService, IImageService imageService)
    {
        _appUserService = appUserService;
        _customerService = customerService;
        _imageService = imageService;
    }

    public async Task EditProfile(CustomerDto customer, IFormFile photo, CancellationToken cancellationToken)
    {
        if(photo != null)
        {
            var image = await _imageService.GetById(customer.ImageId, cancellationToken);
            var path = _imageService.CreateImagePath(photo);
            _imageService.Image_resize(path[0], path[1], 150);
            var index = path[1].LastIndexOf('\\');
            var imagePath = "smallPic/" + path[1].Substring(index + 1);
            var imageId = await _imageService.Create(imagePath, cancellationToken);
            if(image != null)
            {
                await _imageService.Delete(customer.ImageId, cancellationToken);
                _imageService.Delete(image.ImagePath);
            }
            customer.ImageId = imageId;
         
        }
        else
        {
            var image = await _imageService.GetById(customer.ImageId, cancellationToken);
        }
        await _customerService.UpdateBaseInfo(customer, cancellationToken);
        //var user = new AppUserDto()
        //{
        //    Id = customer.UserId,
        //    UserName = customer.UserName,
        //    Email = customer.Email
        //};
        //await _appUserService.Update(user, cancellationToken);
    }

    public async Task<CustomerDto> GetCustomerInformation(string userName , CancellationToken cancellationToken)
    {
      var user =  await _appUserService.GetByUserName(userName,cancellationToken);
        return await _customerService.GetByUserId(user.Id, cancellationToken);

    }
}
