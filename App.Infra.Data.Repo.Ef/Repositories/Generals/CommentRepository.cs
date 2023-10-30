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
        public async Task Create(CommentDto comment, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CommentDto>(comment);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
                        => _mapper.Map<List<CommentDto>>(await _context.Comments.ToListAsync(cancellationToken));


        public async Task<CommentDto> GetById(int commentId, CancellationToken cancellationToken)
                     => _mapper.Map<CommentDto>(await _context.Comments
                         .FirstOrDefaultAsync(x => x.Id == commentId, cancellationToken));


        public async Task Delete(int commentId, CancellationToken cancellationToken)
        {
            var entity = await _context.Comments.FindAsync(commentId, cancellationToken);
            _context.Comments.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(CommentDto comment, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Comment>(comment);
            _context.Comments.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
