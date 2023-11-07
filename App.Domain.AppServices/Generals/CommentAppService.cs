using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Generals;

namespace App.Domain.AppServices.Generals;

public class CommentAppService : ICommentAppService
{
    private readonly ICommentService _commentService;

    public CommentAppService(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task ConfirmComment(int id, CancellationToken cancellationToken)
    {
       var comment = await _commentService.GetById(id , cancellationToken);
        comment.IsConfirm = true;
        await _commentService.Update(comment,cancellationToken);
    }

    public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        => await _commentService.GetAll(cancellationToken);

    public async Task RefuseComment(int id, CancellationToken cancellationToken)
    {
        var comment = await _commentService.GetById(id, cancellationToken);
        comment.IsRefuse = true;
        await _commentService.Update(comment, cancellationToken);
    }
}
