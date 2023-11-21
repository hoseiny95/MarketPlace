using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using App.Domain.Core.Dtos.Users;
using App.Endpoints.MVC.Models;
using AutoMapper;
using App.Domain.AppServices.Users;
using App.Domain.Core.Entities.Users;
using App.Domain.Core.Contracts.Services;

namespace App.Endpoints.MVC.Controllers;

public class UserPanelController : Controller
{
    private readonly ICustomerAppService _customerAppService;
    private readonly ISellerAppService _sellerAppService;
    private readonly IAppUserService _appUserService;
    private readonly IMapper _mapper;

    public UserPanelController(ICustomerAppService customerAppService, ISellerAppService sellerAppService,
        IAppUserService appUserService, IMapper mapper)
    {
        _customerAppService = customerAppService;
        _sellerAppService = sellerAppService;
        _appUserService = appUserService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        return View();
    }
    public async Task<IActionResult> EditProfile(CancellationToken cancellationToken)
    {
        var user = await _appUserService.GetByUserName(User.Identity.Name, default);
        if (User.IsInRole("Customer"))
        {
            var res = await _customerAppService.GetCustomerInformation(User.Identity.Name, cancellationToken);
            var model = _mapper.Map<UserViewModel>(res);
            model.userName = user.UserName;
            model.Email = user.Email;
            return View(model);
        }
        else
        {
            var res = await _sellerAppService.GetSellerByUserName(User.Identity.Name, cancellationToken);
            var model = _mapper.Map<UserViewModel>(res);
            model.userName = user.UserName;
            model.Email = user.Email;
            model.UserId = user.Id;
            return View(model);
        }
    }
    [HttpPost]
    public async Task<IActionResult> EditProfile( UserViewModel model , IFormFile photo, CancellationToken cancellationToken)
    {
        if (User.IsInRole("Customer"))
        {
            var customer = _mapper.Map<CustomerDto>(model);
            await _customerAppService.EditProfile(customer, photo, cancellationToken);
        }
        else
        {
            var seller = _mapper.Map<SellerDto>(model);
            await _sellerAppService.EditProfile(seller, photo, cancellationToken);
        }
        return RedirectToAction(nameof(Index));

    }
}
