
using App.Domain.Core.Dtos.Generals;


namespace App.Domain.Core.Contracts.Services;

public interface ICommentService
{
    
    Task<List<CommentDto>> GetAll(CancellationToken cancellationToken);
    Task<CommentDto> GetById(int commentId, CancellationToken cancellationToken);
    Task Create(CommentDto comment, CancellationToken cancellationToken);
    Task Update(CommentDto comment, CancellationToken cancellationToken);
    Task Delete(int commentId, CancellationToken cancellationToken);
}
