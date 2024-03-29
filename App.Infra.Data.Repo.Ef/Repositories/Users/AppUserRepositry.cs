﻿using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Products;
using App.Domain.Core.Entities.Users;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
        if (userDto.Role == "Customer")
        {
            user = new AppUser
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                Customer = new Customer { },
                IsActive = true
                
            };
        }
        else
        {
            user = new AppUser
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                IsActive = true
            };

        }

        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, userDto.Role);
            user = await _userManager.FindByNameAsync(userDto.UserName);
            int id = _context.Wallets.Max(x => x.Id);
            var wallet = new Wallet() { Id = id +1, Balance = 0, AppUser = user };
            _context.Add(wallet);
            if (userDto.Role == "Seller")
            {
                int sellerid = _context.Sellers.Max(x => x.Id);
                var seller = new Seller() { Id = sellerid + 1, UserId = user.Id, Medal = 1, User = user, Booth = 
                    new Booth { IsDeleted = false, CreatedAt = DateTime.Now, IsSuprior = false } };
                _context.Add(seller);
               
            }
            _context.SaveChanges();

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
        var user = await _userManager.FindByEmailAsync(userDto.Email);
        var result = await _signInManager.PasswordSignInAsync(user.UserName, userDto.Password, true, false);
        return result;
    }
    public async Task Delete(int userId, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        //_context.AppUsers.Remove(user);
        //_context.Remove(user);
        //_context.Entry(userrole).State = EntityState.Modified;
        //_context.Entry(user).State = EntityState.Deleted;
        user.IsActive = false;
        await _context.SaveChangesAsync(cancellationToken);
    

    }

    public async Task<List<AppUserDto>> GetAll(CancellationToken CancellationToken)
    {
        var res = await _userManager.Users
              .AsNoTracking()
              .ToListAsync(CancellationToken);
        var meee = _mapper.Map<List<AppUserDto>>(res);
        var users = _mapper.Map<List<AppUserDto>>(await _userManager.Users
              .AsNoTracking()
              .ToListAsync(CancellationToken));

        foreach (var item in users)
        {
            var userRole = await _userManager.GetRolesAsync(await _userManager.Users.FirstAsync(x => x.Id == item.Id));
            item.Role = userRole.FirstOrDefault();
        }
        return users;
    }

    public async Task<AppUserDto> GetById(int userId, CancellationToken CancellationToken)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        var entity = _mapper.Map<AppUserDto>(user);
        var userRole = await _userManager.GetRolesAsync(user);
        entity.Role = userRole.First();
        return entity;
    }


    public async Task<IdentityResult> Update(AppUserDto appuser, CancellationToken CancellationToken)
    {
        var user = await _userManager.FindByIdAsync(appuser.Id.ToString());
        user.UserName = appuser.UserName;
        user.Email = appuser.Email;
        var userRole = (await _userManager.GetRolesAsync(user)).First();
        if (appuser.Role != userRole && appuser.Role != null)
        {
            await _userManager.RemoveFromRoleAsync(user, userRole);
            await _userManager.AddToRoleAsync(user, appuser.Role);
        }

        var result = await _userManager.UpdateAsync(user);
        return result;
    }
    public async Task<AppUserDto> GetByUserName(string userName, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(userName);
        return _mapper.Map<AppUserDto>(user);
    }

    public async Task<AppUserDto> GetByEmail(string email, CancellationToken cancellationToken)
        => _mapper.Map <AppUserDto> (await _userManager.FindByEmailAsync(email));
    
}
