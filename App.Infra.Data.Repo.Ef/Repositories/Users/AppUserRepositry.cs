using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Users;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App.Infra.Data.Repo.Ef.Repositories.Users;

public class AppUserRepositry : IAppUserRepositry
{
    private readonly MarketPlaceContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public AppUserRepositry(MarketPlaceContext context,
        IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager
        , RoleManager<IdentityRole<int>> roleManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<IdentityResult> Create(AppUserDto userDto, CancellationToken CancellationToken)
    {
        var user = new AppUser();
        userDto.Role = "Admin";
        user = new AppUser
        {
            UserName = userDto.Email,
            Email = userDto.Email,
        };
        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, userDto.Role);
        }
        return result;

    }
    public async Task CreateRole(string name)
    {
        var role = new IdentityRole<int>();
        role.Name = name;
        await _roleManager.CreateAsync(role);
    }

    public async Task<SignInResult> Login(AppUserDto userDto, CancellationToken cancellationToken)
    {
       var result =  await _signInManager.PasswordSignInAsync(userDto.Email, userDto.Password, true, false);
        return result;
    }
    public Task Delete(int userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<AppUserDto>> GetAll(CancellationToken CancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<AppUserDto> GetById(int userId, CancellationToken CancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(AppUserDto appuser, CancellationToken CancellationToken)
    {
        throw new NotImplementedException();
    }
}
