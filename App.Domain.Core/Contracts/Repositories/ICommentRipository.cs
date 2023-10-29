
using App.Domain.Core.Dtos.Generals;


namespace App.Domain.Core.Contracts.Repositories;

public interface ICommentRipository
{
    
    Task<List<CommentDto>> GetAll(CancellationToken cancellationToken);
    Task<CommentDto> GetDatail(int commentId, CancellationToken cancellationToken);
    Task Create(CommentDto comment, CancellationToken cancellationToken);
    Task Update(CommentDto comment, CancellationToken cancellationToken);
    Task SoftDelete(int commentId, CancellationToken cancellationToken);
    Task HardDelted(int commentId, CancellationToken cancellationToken);
}
