using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Users
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<int> Create(AddressDto Address, CancellationToken cancellationToken)
            => await _addressRepository.Create(Address, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {

            try
            {
                await _addressRepository.Delete(id, cancellationToken);
                return true;
            }
            catch { return false; }
        }

        public async Task<List<AddressDto>> GetAll(CancellationToken CancellationToken)
            => await _addressRepository.GetAll(CancellationToken);  

        public async Task<AddressDto> GetById(int AddressId, CancellationToken cancellationToken)
            => await _addressRepository.GetById(AddressId, cancellationToken);

        public async Task<int> Update(AddressDto Address, CancellationToken cancellationToken)
            => await _addressRepository.Update(Address, cancellationToken);
    }
}
