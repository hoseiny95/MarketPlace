using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Users;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Users;

public class AppUserRepositry : IAppUserRepositry
{
    private readonly MarketPlaceContext _context;
    private readonly IMapper _mapper;

    public AppUserRepositry(MarketPlaceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Delete(int userId, CancellationToken cancellationToken)
    {
        var entity = await _context.AppUsers.FindAsync(userId, cancellationToken);
        _context.AppUsers.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<AppUserDto>> GetAll(CancellationToken CancellationToken)
               => _mapper.Map<List<AppUserDto>>(await _context.AppUsers.ToListAsync(CancellationToken));


    public async Task<AppUserDto> GetById(int userId, CancellationToken CancellationToken)
              => _mapper.Map<AppUserDto>(await _context.AppUsers
                     .FirstOrDefaultAsync(x => x.Id == userId, CancellationToken));

    public async Task Update(AppUserDto appuser, CancellationToken CancellationToken)
    {
        var entity = _mapper.Map<AppUser>(appuser);
        _context.AppUsers.Update(entity);
        await _context.SaveChangesAsync(CancellationToken);
    }
}
