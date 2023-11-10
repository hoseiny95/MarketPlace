using App.Domain.Core.Dtos.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices;

public interface ICustomerAppService
{
    Task<CustomerDto> GetCustomerInformation(string userName , CancellationToken cancellationToken);
    Task EditProfile(CustomerDto customer, IFormFile photo, CancellationToken cancellationToken);
}
