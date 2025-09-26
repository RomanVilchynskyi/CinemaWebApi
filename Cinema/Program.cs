using DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("Remotedb")
    ?? throw new Exception("No Connection String found.");

// Add services to the container.

builder.Services.AddDbContext<CinemaDbContext>(options =>
    options.UseSqlServer(connStr));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



//builder.Services.AddIdentity<User, IdentityRole>(options =>
//    options.SignIn.RequireConfirmedAccount = false)
//    .AddDefaultUI()
//    .AddDefaultTokenProviders()
//    .AddEntityFrameworkStores<ShelterDbContext>();

//builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<IFavService, FavService>();

//builder.Services.AddTransient<IEmailSender, EmailSender>();
//builder.Services.AddScoped<IViewRender, ViewRender>();



//var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    services.SeedRolesAsync().Wait();
//    services.SeedAdminAsync().Wait();
//}

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();
//app.UseSession();
