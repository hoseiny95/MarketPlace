using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Products;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App.Infra.Data.Repo.Ef.Repositories.Products;

public class CategoryRepository : ICategoryRepository
{
    private readonly MarketPlaceContext _context;
    private readonly IMapper _mapper;
    public CategoryRepository(MarketPlaceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<int> Create(CategoryDto category, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Category>(category);
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task Delete(int categoryId, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories.FindAsync(categoryId, cancellationToken);
        _context.Categories.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
                         => _mapper.Map<List<CategoryDto>>(await _context.Categories.ToListAsync(cancellationToken));


    public async Task<CategoryDto> GetById(int categoryId, CancellationToken cancellationToken)
                            => _mapper.Map<CategoryDto>(await _context.Categories.Include(c => c.InverseParent)
                                .FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken));


    public async Task<int> Update(CategoryDto category, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Category>(category);
        _context.Categories.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
    public async Task<List<SelectListItem>> GetBaseCategoryItems(CancellationToken cancellationToken)
    {
        var categories = await _context.Categories.Where(x => x.ParentId == null)
            .Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToListAsync(cancellationToken);
        return categories;

    }
    public async Task<List<SelectListItem>> GetFirstSubCategoryItems(int parentId, CancellationToken cancellationToken)
    {
        var categories = await _context.Categories.Where(x => x.ParentId == parentId)
          .Select(c => new SelectListItem
          {
              Text = c.Name,
              Value = c.Id.ToString()
          }).ToListAsync(cancellationToken);
        categories.Insert(0, new SelectListItem
        {
            Text = "انتخاب کنید",
            Value = 0.ToString()
        });
        return categories;
    }
    public async Task<List<SelectListItem>> GetSecondSubCategoryItems(int parentId, CancellationToken cancellationToken)
    {
        var categories = await _context.Categories.Where(x => x.ParentId == parentId)
          .Select(c => new SelectListItem
          {
              Text = c.Name,
              Value = c.Id.ToString()
          }).ToListAsync(cancellationToken);
        categories.Insert(0, new SelectListItem
        {
            Text = "انتخاب کنید",
            Value = 0.ToString()
        });
        return categories;
    }

  
}
