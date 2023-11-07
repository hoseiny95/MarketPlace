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

namespace App.Infra.Data.Repo.Ef.Repositories.Products
{
    public class BoothRepository : IBoothRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;
        public BoothRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(BoothDto booth, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Booth>(booth);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
        public async Task Delete(int boothId, CancellationToken cancellationToken)
        {
            var entity = await _context.Booths.FindAsync(boothId, cancellationToken);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<BoothDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = _context.Booths.Include(c => c.Image)
                                .Include(c => c.City).Where(c=> c.IsDeleted == false)
                                .Select(c=> new BoothDto()
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    City =c.City,
                                    Image = c.Image,
                                    Phone = c.Phone,
                                    CreatedAt = c.CreatedAt,
                                    Description = c.Description,
                                    
                                });
            return await result.ToListAsync(cancellationToken);
        }             
        public async Task<BoothDto> GetById(int boothId, CancellationToken cancellationToken)
        {
            var result = _context.Booths.Include(c => c.Image)
                          .Include(c => c.City).Where(c=> c.Id ==boothId)
                          .Select(c => new BoothDto()
                          {
                              Id = c.Id,
                              Name = c.Name,
                              City = c.City,
                              Image = c.Image,
                              Phone = c.Phone,
                              CreatedAt = c.CreatedAt,
                              Description = c.Description,
                              CityId = (int)c.CityId,
                              ImageId = (int)c.ImageId,

                          });
            return await result.FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<int> Update(BoothDto booth, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Booth>(booth);
            _context.ChangeTracker.Clear();
            _context.Booths.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
        public async Task<List<BoothDto>> GetAllDeleted(CancellationToken cancellationToken)
        {
            var result = _context.Booths.Include(c => c.Image)
                                .Include(c => c.City).Where(c => c.IsDeleted == true)
                                .Select(c => new BoothDto()
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    City = c.City,
                                    Image = c.Image,
                                    Phone = c.Phone,
                                    CreatedAt = c.CreatedAt,
                                    Description = c.Description,

                                });
            return await result.ToListAsync(cancellationToken);
        }
    }
}
