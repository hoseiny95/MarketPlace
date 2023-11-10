using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
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

    public CustomerAppService(IAppUserService appUserService, ICustomerService customerService)
    {
        _appUserService = appUserService;
        _customerService = customerService;
    }

    public Task EditProfile(CustomerDto customer, IFormFile photo, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<CustomerDto> GetCustomerInformation(string userName , CancellationToken cancellationToken)
    {
      var user =  await _appUserService.GetByUserName(userName,cancellationToken);
        return await _customerService.GetByUserId(user.Id, cancellationToken);

    }
}
