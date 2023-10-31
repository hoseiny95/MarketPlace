using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Users
{
    public class AddressService : IAddressService
    {
        public Task Delete(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<AddressDto>> GetAll(CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AddressDto> GetById(int AddressId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(AddressDto Address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
