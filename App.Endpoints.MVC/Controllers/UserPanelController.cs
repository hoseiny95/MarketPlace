using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using App.Domain.Core.Dtos.Users;
using App.Endpoints.MVC.Models;
using AutoMapper;

namespace App.Endpoints.MVC.Controllers;

public class UserPanelController : Controller
{
    private readonly ICustomerAppService _customerAppService;
    private readonly IMapper _mapper;

    public UserPanelController(ICustomerAppService customerAppService, IMapper mapper)
    {
        _customerAppService = customerAppService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        return View(await _customerAppService.GetCustomerInformation(User.Identity.Name, cancellationToken));

    }
    public async Task<IActionResult> EditProfile(CancellationToken cancellationToken)
    {
        return View(await _customerAppService.GetCustomerInformation(User.Identity.Name, cancellationToken));
    }
    [HttpPost]
    public IActionResult EditProfile(CustomerViewModel model , FormFile photo)
    {
       
       if (ModelState.IsValid)
        {
            var customer = _mapper.Map<CustomerDto>(model);

        }

        //Log Out User
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return Redirect("/Login?EditProfile=true");

    }
}
