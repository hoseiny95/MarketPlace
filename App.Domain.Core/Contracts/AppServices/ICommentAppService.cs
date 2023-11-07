using App.Domain.Core.Dtos.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices;

public interface ICommentAppService
{
    Task<List<CommentDto>> GetAll(CancellationToken cancellationToken);
    Task ConfirmComment(int id , CancellationToken cancellationToken);
    Task RefuseComment(int id , CancellationToken cancellationToken);

}
