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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Generals
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;

        public CommentRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(CommentDto comment, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Comment>(comment);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            var res =  _context.Comments.Include(x => x.Customer).Include(x => x.BoothProduct)
                .ThenInclude(x => x.Both).Include(x => x.BoothProduct).ThenInclude(x => x.Product)
                .Where(x => x.IsConfirm == false && x.IsRefuse == false)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    CreateAt = c.CreateAt,
                    BoothName = c.BoothProduct.Both.Name,
                    CustomerName = c.Customer.Name +" " + c.Customer.Lastname,
                    BoothProductName = c.BoothProduct.Product.Name,
                    Descriotion = c.Descriotion
                });
            return await res.ToListAsync(cancellationToken);
        }
                       


        public async Task<CommentDto> GetById(int commentId, CancellationToken cancellationToken)
                     => _mapper.Map<CommentDto>(await _context.Comments
                         .FirstOrDefaultAsync(x => x.Id == commentId, cancellationToken));


        public async Task Delete(int commentId, CancellationToken cancellationToken)
        {
            var entity = await _context.Comments.FindAsync(commentId, cancellationToken);
            _context.Comments.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> Update(CommentDto comment, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Comment>(comment);
            _context.ChangeTracker.Clear();
            _context.Comments.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
