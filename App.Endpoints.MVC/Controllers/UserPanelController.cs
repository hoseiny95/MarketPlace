using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using App.Domain.Core.Dtos.Users;
using App.Endpoints.MVC.Models;
using AutoMapper;
using App.Domain.AppServices.Users;

namespace App.Endpoints.MVC.Controllers;

public class UserPanelController : Controller
{
    private readonly ICustomerAppService _customerAppService;
    private readonly ISellerAppService _sellerAppService;

    private readonly IMapper _mapper;

    public UserPanelController(ICustomerAppService customerAppService, ISellerAppService sellerAppService, IMapper mapper)
    {
        _customerAppService = customerAppService;
        _sellerAppService = sellerAppService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        //return View(await _customerAppService.GetCustomerInformation(User.Identity.Name, cancellationToken));
        CustomerDto user = await _customerAppService.GetCustomerInformation(User.Identity.Name, default);
        SellerDto seller = await _sellerAppService.GetSellerByUserName(User.Identity.Name, default);
        return View();

    }
    public async Task<IActionResult> EditProfile(CancellationToken cancellationToken)
    {
        var res = await _customerAppService.GetCustomerInformation(User.Identity.Name, cancellationToken);
        var meee = _mapper.Map<CustomerViewModel>(res);
        return View(meee);
    }
    [HttpPost]
    public async Task<IActionResult> EditProfile( CustomerViewModel model , IFormFile photo, CancellationToken cancellationToken)
    {
       
      
            var customer = _mapper.Map<CustomerDto>(model);
            await _customerAppService.EditProfile(customer, photo, cancellationToken);

      


        return Redirect("/Login?EditProfile=true");

    }
}
