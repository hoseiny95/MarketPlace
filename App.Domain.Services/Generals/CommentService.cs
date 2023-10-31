using App.Domain.Core.Contracts.Repositories;
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
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<int> Create(CommentDto comment, CancellationToken cancellationToken)
        => await _commentRepository.Create(comment, cancellationToken);
    

    public async Task<bool> Delete(int commentId, CancellationToken cancellationToken)
    {
        try
        {
            await _commentRepository.Delete(commentId, cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        => await _commentRepository.GetAll(cancellationToken);
    

    public async Task<CommentDto> GetById(int commentId, CancellationToken cancellationToken)
        => await _commentRepository.GetById(commentId, cancellationToken);

    public async Task<int> Update(CommentDto comment, CancellationToken cancellationToken)
        => await _commentRepository.Update(comment, cancellationToken);
}
