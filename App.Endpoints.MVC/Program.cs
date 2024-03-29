using App.Domain.AppServices.Generals;
using App.Domain.AppServices.Products;
using App.Domain.AppServices.Users;
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Entities.Users;
using App.Domain.Services.Auctions;
using App.Domain.Services.Generals;
using App.Domain.Services.Orders;
using App.Domain.Services.Products;
using App.Domain.Services.Users;
using App.Endpoints.MVC.Models;
using App.Infra.Data.Repo.Ef.Repositories.Auctions;
using App.Infra.Data.Repo.Ef.Repositories.Generals;
using App.Infra.Data.Repo.Ef.Repositories.Orders;
using App.Infra.Data.Repo.Ef.Repositories.Products;
using App.Infra.Data.Repo.Ef.Repositories.Users;
using App.Infra.Data.Repos.Ef.Map;
using App.Infra.Db.Sql.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using Hangfire;
using App.Domain.AppServices.Auctions;
using App.Domain.AppServices.Orders;
using System.Reflection.Metadata;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

LogManager.Configuration = new NLogLoggingConfiguration(builder.Configuration.GetSection("NLog"));
var logger = NLogBuilder.ConfigureNLog(LogManager.Configuration).GetCurrentClassLogger();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddNLog();
    loggingBuilder.AddSeq();
});
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MarketProfiles)));
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MarketUiProfile)));
builder.Services.AddDbContext<MarketPlaceContext>(options =>
    options.UseSqlServer()) ;
#region Identity
builder.Services.AddIdentity<AppUser, IdentityRole<int>>()
.AddEntityFrameworkStores<MarketPlaceContext>()
.AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(option =>
{
    //UserSetting
    //option.User.AllowedUserNameCharacters = "abcd123";
    option.User.RequireUniqueEmail = true;

    //Password Setting
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireNonAlphanumeric = false;//!@#$%^&*()_+
    option.Password.RequireUppercase = false;
    option.Password.RequiredLength = 6;
    option.Password.RequiredUniqueChars = 1;

    //Lokout Setting
    option.Lockout.MaxFailedAccessAttempts = 3;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(10);

    //SignIn Setting
    option.SignIn.RequireConfirmedAccount = false;
    option.SignIn.RequireConfirmedEmail = false;
    option.SignIn.RequireConfirmedPhoneNumber = false;

});

#endregion

#region MyServices
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAppUserRepositry, AppUserRepositry>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<IBoothProductRepository, BoothProductRepository>();
builder.Services.AddScoped<IBoothRepository, BoothRepository>();
builder.Services.AddScoped<ICategoryAttributeTitleRepository, CategoryAttributeTitleRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IOrderLineRepository, OrderLineRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductAttributeValueRepository, ProductAttributeValueRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IWalletHistoryRepository, WalletHistoryRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();


builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IBoothProductService, BoothProductService>();
builder.Services.AddScoped<IBoothService, BoothService>();
builder.Services.AddScoped<ICategoryAttributeTitleService, CategoryAttributeTitleService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IOrderLineService, OrderLineService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductAttributeValueService, ProductAttributeValueService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IWalletHistoryService, WalletHistoryService>();
builder.Services.AddScoped<IWalletService, WalletService>();

builder.Services.AddScoped<IBoothProductAppService, BoothProductAppService>();
builder.Services.AddScoped<IBoothAppService, BoothAppService>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();
builder.Services.AddScoped<ISellerAppService, SellerAppService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IAuctionAppService, AuctionAppService>();
builder.Services.AddScoped<IOrderAppService, OrderAppService>();


#endregion
#region HangFire
builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireStorage"));
});

builder.Services.AddHangfireServer();

#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
name: "Admin",
pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
