using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Admin;
using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Products;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App.Infra.Data.Repo.Ef.Repositories.Products
{
    public class BoothProductRepository : IBoothProductRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;
        public BoothProductRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(BoothProductDto boothProduct, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BoothProduct>(boothProduct);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task Delete(int boothProductId, CancellationToken cancellationToken)
        {
            var entity = await _context.BoothProducts.FindAsync(boothProductId, cancellationToken);
            entity.IsAvailable = false;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<BoothProductDto>> GetAll(CancellationToken cancellationToken)
                    => _mapper.Map<List<BoothProductDto>>(await _context.BoothProducts.Include(c => c.Both).Include(c => c.Product)
                        .Include(c => c.Auctions)
                        .Include(c => c.ProductImages).ThenInclude(c => c.Image)
                        .ToListAsync(cancellationToken));
        public async Task<BoothProductDto> GetById(int boothProductId, CancellationToken cancellationToken)
            => _mapper.Map<BoothProductDto>(await _context.BoothProducts.FirstOrDefaultAsync(x => x.Id == boothProductId, cancellationToken));
        public async Task<int> Update(BoothProductDto boothProduct, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BoothProduct>(boothProduct);
            _context.ChangeTracker.Clear();
            _context.BoothProducts.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
        public async Task<List<ProductAdminDto>> GetAdminProducts(CancellationToken cancellationToken)
        {
            var result = _context.BoothProducts.Include(x => x.Both).Include(x => x.Product)
                .Include(x => x.ProductImages).ThenInclude(x => x.Image).Where(c => c.IsConfirm == true && c.IsAvailable == true)
                .Select(c => new ProductAdminDto
                {
                    Id = c.Id,
                    BoothName = c.Both.Name,
                    Description = c.Both.Description,
                    ImagePath = c.ProductImages.Select(x => x.Image.ImagePath).ToList(),
                    Name = c.Product.Name,
                    price = c.Price.ToString()
                });
            return await result.ToListAsync(cancellationToken);
        }
        public async Task<List<ProductAdminDto>> GetAdminProductsNotConfirm(CancellationToken cancellationToken)
        {
            var result = _context.BoothProducts.Include(x => x.Both).Include(x => x.Product)
                .Include(x => x.ProductImages).ThenInclude(x => x.Image).Where(x => x.IsConfirm == false && x.IsAvailable == true)
                .Select(c => new ProductAdminDto
                {
                    Id = c.Id,
                    BoothName = c.Both.Name,
                    Description = c.Both.Description,
                    ImagePath = c.ProductImages.Select(x => x.Image.ImagePath).ToList(),
                    Name = c.Product.Name,
                    price = c.Price.ToString()
                });
            var res = result.ToList();
            return await result.ToListAsync(cancellationToken);
        }
        public async Task<ProductAdminDto> GetAdminProductsbyId(int id, CancellationToken cancellationToken)
        {
            var result = _context.BoothProducts.Include(x => x.Both).Include(x => x.Product)
                .Include(x => x.ProductImages).ThenInclude(x => x.Image).Where(x => x.Id == id)
                .Select(c => new ProductAdminDto
                {
                    Id = c.Id,
                    BoothName = c.Both.Name,
                    Description = c.Product.Description,
                    ImagePath = c.ProductImages.Select(x => x.Image.ImagePath).ToList(),
                    Name = c.Product.Name,
                    price = c.Price.ToString()
                });
            return await result.FirstOrDefaultAsync(cancellationToken);
        }
        public async Task UpdateByPrice(int id, string price, CancellationToken cancellationToken)
        {
            var entity = await _context.BoothProducts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            entity.Price = double.Parse(price);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task ConfirmProduct(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.BoothProducts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            entity.IsConfirm = true;
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task RefuseProduct(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.BoothProducts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            entity.IsAvailable = false;
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task CreateProductImage(int boothProductId, int imageId, CancellationToken cancellationToken)
        {
            var proimg = new ProductImage()
            {
                BoothProductId = boothProductId,
                ImageId = imageId,
            };
            await _context.AddAsync(proimg, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<Tuple<List<BoothProductDto>, int>> GetAllPaging( CancellationToken cancellationToken, List<int> ProductsId, int pageId = 1,
        string orderByType = "date", int startPrice = 0, int endPrice = 0)
        {

            IQueryable<BoothProduct> result = _context.BoothProducts;


            switch (orderByType)
            {
                case "date":
                    result = result.OrderByDescending(c => c.CreatedAt);
                    break;

                case "PriceDescend":
                    result = result.OrderByDescending(c => c.Price);
                    break;

                case "PriceAcsend":
                    result = result.OrderBy(c => c.Price);
                    break;
            }

            if (startPrice > 0)
            {
                result = result.Where(c => c.Price > startPrice);
            }

            if (endPrice > 0)
            {
                result = result.Where(c => c.Price < startPrice);
            }

            if (ProductsId.Count() != 0)
            {
                result = result.Where(x => ProductsId.Contains(x.ProductId));
            }
            int skip = (pageId - 1) * 8;

            int pageCount =(int) Math.Ceiling( (decimal)result.Include(c => c.Both).Include(c => c.Product)
                        .Include(c => c.Auctions)
                        .Include(c => c.ProductImages).ThenInclude(c => c.Image)
                .Count() / 8);

            var entities = await result.Include(c => c.Both).Include(c => c.Product)
                        .Include(c => c.Auctions)
                        .Include(c => c.ProductImages).ThenInclude(c => c.Image)
                        .Skip(skip).Take(8).ToListAsync(cancellationToken);

            return Tuple.Create(_mapper.Map<List<BoothProductDto>>(entities), pageCount);
        }
    }
}
