using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApi.DbContexts;
using WebApi.Middlewares;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddDbContext<LibaryDbContext>(options => options.UseInMemoryDatabase(string.Format("BookStoreDB")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILoggerService, DBLogger>();
builder.Services.AddScoped<ILibaryDbContext>(provider => provider.GetService<LibaryDbContext>());

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

DataGenerator.Initialize(builder.Services.BuildServiceProvider());

app.UseCustomExceptionMiddle();

app.Run();

//app.Run(async context => Console.Write("Middleware 1."));

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Middleware 1 baþladý.");
//    await next.Invoke();
//    Console.WriteLine("Middleware 1 sonlandýrýlýyor.");

//});


//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Middleware 2 baþladý.");
//    await next.Invoke();
//    Console.WriteLine("Middleware 2 sonlandýrýlýyor.");

//});


//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Middleware 3 baþladý.");
//    await next.Invoke();
//    Console.WriteLine("Middleware 3 sonlandýrýlýyor.");

//});

