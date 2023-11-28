using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Admin;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Products;
using App.Domain.Services.Products;
using App.Domain.Services.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App.Domain.AppServices.Products;

public class BoothProductAppService : IBoothProductAppService
{
    private IBoothProductService _boothProductService;
    private IProductService _productService;
    private IBoothService _boothService;
    private IImageService _imageService;
    private ICategoryService _categoryService;
    private readonly IAppUserService _userService;
    private readonly ICustomerService _customerService;
    private readonly ICommentService _commentService;

    public BoothProductAppService(IBoothProductService boothProductService, IProductService productService,
        IBoothService boothService, IImageService imageService, ICategoryService categoryService,
        IAppUserService userService, ICustomerService customerService, ICommentService commentService)
    {
        _boothProductService = boothProductService;
        _productService = productService;
        _boothService = boothService;
        _imageService = imageService;
        _categoryService = categoryService;
        _userService = userService;
        _customerService = customerService;
        _commentService = commentService;
    }

    public async Task ConfirmProduct(int id, string confitm, string refuse, CancellationToken cancellationToken)
    {
        if (confitm == null)
        {
            await _boothProductService.RefuseProduct(id, cancellationToken);

        }
        if (refuse == null)
        {
            await _boothProductService.ConfirmProduct(id, cancellationToken);

        }
    }

    public async Task Create(BoothProductDto boothProductDto, IFormFile photo, int imageId, CancellationToken cancellationToken)
    {


        if (photo != null)
        {
            var path = _imageService.CreateImagePath(photo);
            _imageService.Image_resize(path[0], path[1], 150);
            imageId = await _imageService.Create(path[2], cancellationToken);
            //boothProductDto.ProductImages.FirstOrDefault().Image.Id = imageId;

        }
        var boothId = await _boothProductService.Create(boothProductDto, cancellationToken);

        await _boothProductService.CreateProductImage(boothId, imageId, cancellationToken);
    }

    public async Task<bool> Delete(int boothProductId, CancellationToken cancellationToken)
        => await _boothProductService.Delete(boothProductId, cancellationToken);

    public async Task<List<ProductAdminDto>> GetAdminProductsNotConfirm(CancellationToken cancellationToken)
        => await _boothProductService.GetAdminProductsNotConfirm(cancellationToken);

    public async Task UpdateAdminProduct(ProductAdminDto adminProduct, IFormFile photo,
        CancellationToken cancellationToken)
    {
        var entity = await _boothProductService.GetById(adminProduct.Id, cancellationToken);
        var product = await _productService.GetById(entity.ProductId, cancellationToken);
        var booth = await _boothService.GetById(entity.BothId, cancellationToken);
        if (entity.Price.ToString() != adminProduct.price)
            await _boothProductService.UpdateByPrice(adminProduct.Id, adminProduct.price, cancellationToken);
        if (product.Name != adminProduct.Name || product.Description != adminProduct.Description)
        {
            product.Description = adminProduct.Description;
            product.Name = adminProduct.Name;
            await _productService.Update(product, cancellationToken);
        }
        if (booth.Name != adminProduct.BoothName)
        {
            booth.Name = adminProduct.BoothName;
            await _boothService.Update(booth, cancellationToken);
        }
        if (photo != null)
        {
            var path = _imageService.CreateImagePath(photo);
            _imageService.Image_resize(path[0], path[1], 150);
            var image = await _imageService.GetByBothProductId(adminProduct.Id, cancellationToken);
            await _imageService.Update(path[2], image.Id, cancellationToken);

        }

    }

    public async Task<Tuple<List<BoothProductDto>,int>> GetAllPaging(CancellationToken cancellationToken, List<int> selectedCategory, int pageId = 1, 
        string orderByType = "date",int startPrice = 0, int endPrice = 0, string filter = null)
    {
        var categories = new List<CategoryDto>();
        foreach (var categoryId in selectedCategory)
        {
            categories.AddRange(await _categoryService.GetChildren(categoryId, cancellationToken));
            categories.Add(await _categoryService.GetById(categoryId, cancellationToken));

        }
        var noDupes = new HashSet<CategoryDto>(categories);
        var noDupes2 = categories.Distinct().ToList();
        var result = await _productService.GetIDByCategories(categories, cancellationToken);
        var me = await _boothProductService.GetAllPaging(cancellationToken,result, pageId, orderByType, startPrice, endPrice, filter);
        return me;
    }

    public async Task<BoothProductDto> GetById(int id, CancellationToken cancellationToken)
        => await _boothProductService.GetById(id, cancellationToken);

    public async Task<bool> SetComment(string username, int productId, string comment, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByUserName(username, cancellationToken);
        var customer = await _customerService.GetByUserId(user.Id, cancellationToken);
        bool check = false;
        int orderId = 0;
        foreach (var item in customer.Orders)
        {
            foreach (var orderline in item.OrderLines)
            {
                if (orderline.BothProductId == productId)
                {
                    check = true;
                    orderId = orderline.OrderId;
                }
                   
            }
        }
        if (check)
        {
            var commentDto = new CommentDto()
            {
                CustomerId = customer.Id,
                BoothProductId = productId,
                Descriotion = comment,
                IsConfirm = true,
                CreateAt = DateTime.Now,
                OrderId = orderId,
            };
            await _commentService.Create(commentDto, cancellationToken);
        }
        return check;
    }

    public async Task<List<BoothProductDto>> GetByBoothId(int boothId, CancellationToken cancellationToken)
        => await _boothProductService.GetByBoothId(boothId, cancellationToken);

    public async Task<List<BoothProductDto>> GetAllByName(string name, CancellationToken cancellationToken)
        => await _boothProductService.GetAllByName(name, cancellationToken);
}
