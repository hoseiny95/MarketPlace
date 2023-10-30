using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Products;
using App.Domain.Core.Entities.Users;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Users
{
    public class AddressRepository : IAddressRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;

        public AddressRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Addresses.FindAsync(id, cancellationToken);
            _context.Addresses.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<AddressDto>> GetAll(CancellationToken CancellationToken)
                        => _mapper.Map<List<AddressDto>>(await _context.Addresses.ToListAsync(CancellationToken));


        public async Task<AddressDto> GetById(int AddressId, CancellationToken cancellationToken)
                             => _mapper.Map<AddressDto>(await _context.Addresses
                                 .FirstOrDefaultAsync(x => x.Id == AddressId, cancellationToken));


        public async Task Update(AddressDto address, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Address>(address);
            _context.Addresses.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
