using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Products;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Products
{
     public class ProductRepository : IProductRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(ProductDto newProduct, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(newProduct);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task Delete(int ProductId, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(ProductId, cancellationToken);
            entity.IsDeleted=true;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
                       => _mapper.Map<List<ProductDto>>(await _context.Products.ToListAsync(cancellationToken));


        public async Task<ProductDto> GetById(int ProductId, CancellationToken cancellationToken)
                     => _mapper.Map<ProductDto>(await _context.Products.FirstOrDefaultAsync(x => x.Id == ProductId, cancellationToken));


        public async Task<int> Update(ProductDto product, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(product);
            _context.ChangeTracker.Clear();
            _context.Products.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
