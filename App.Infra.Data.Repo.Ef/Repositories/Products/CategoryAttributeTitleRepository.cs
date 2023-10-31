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
    public class CategoryAttributeTitleRepository : ICategoryAttributeTitleRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;

        public CategoryAttributeTitleRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(CategoryAttributeTitleDto categoryAttribute, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CategoryAttributeTitle>(categoryAttribute);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
           
        }
    

        public async Task Delete(int categoryAttributeId, CancellationToken cancellationToken)
        {
            var entity = await _context.CategoryAttributeTitles.FindAsync(categoryAttributeId, cancellationToken);
            _context.CategoryAttributeTitles.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<CategoryAttributeTitleDto>> GetAll(CancellationToken cancellationToken)
                       => _mapper.Map<List<CategoryAttributeTitleDto>>(await _context.CategoryAttributeTitles
                           .ToListAsync(cancellationToken));


        public async Task<CategoryAttributeTitleDto> GetById(int categoryAttributeId, CancellationToken cancellationToken)
                             => _mapper.Map<CategoryAttributeTitleDto>(await _context.CategoryAttributeTitles
                                 .FirstOrDefaultAsync(x => x.Id == categoryAttributeId, cancellationToken));


        public async Task<int> Update(CategoryAttributeTitleDto categoryAttribute, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CategoryAttributeTitle>(categoryAttribute);
            _context.CategoryAttributeTitles.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
