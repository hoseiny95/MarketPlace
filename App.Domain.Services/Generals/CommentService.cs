using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Generals;

public class CommentService : ICommentService
{
    public Task Create(CommentDto comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CommentDto> GetById(int commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(CommentDto comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
