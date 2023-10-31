using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Users;

internal class SellerService : ISellerService
{
    public Task Create(SellerDto seller, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int sellerId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<SellerDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<SellerDto> GetById(int sellerId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(SellerDto seller, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
