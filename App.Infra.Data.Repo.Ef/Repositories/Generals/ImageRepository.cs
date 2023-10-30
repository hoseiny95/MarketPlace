﻿using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Generals;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Generals
{
    public class ImageRepository : IImageRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;
        public ImageRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Images.FindAsync(id, cancellationToken);
            _context.Images.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<ImageDto> GetById(int imageId, CancellationToken cancellationToken)
                       => _mapper.Map<ImageDto>(await _context.Comments.FirstOrDefaultAsync(x => x.Id == imageId, cancellationToken));
        public async Task<List<ImageDto>> GetByProductId(int productId, CancellationToken cancellationToken)
            =>  _mapper.Map<List<ImageDto>>( await _context.Images.Include(c => c.ProductImages)
                .Where(x => x.ProductImages.Any(c => c.BoothProductId == productId)).ToListAsync(cancellationToken));

        public async Task Update(string path, int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Images.FindAsync(id);
            entity.ImagePath = path;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}