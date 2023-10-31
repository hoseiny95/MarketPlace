using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Products;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Products
{
    public class ProductAttributeValueRepository : IProductAttributeValueRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;

        public ProductAttributeValueRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(ProductAttributeValueDto productAttribute, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductAttributeValue>(productAttribute);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task Delete(int productAttributeId, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductAttributeValues.FindAsync(productAttributeId, cancellationToken);
            _context.ProductAttributeValues.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductAttributeValueDto>> GetAll(CancellationToken cancellationToken)
                       => _mapper.Map<List<ProductAttributeValueDto>>(await _context.ProductAttributeValues.ToListAsync(cancellationToken));


        public async Task<ProductAttributeValueDto> GetById(int productAttributeId, CancellationToken cancellationToken)
                      => _mapper.Map<ProductAttributeValueDto>(await _context.Comments
                               .FirstOrDefaultAsync(x => x.Id == productAttributeId, cancellationToken));

        public async Task<int> Update(ProductAttributeValueDto productAttribute, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductAttributeValue>(productAttribute);
            _context.ProductAttributeValues.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
