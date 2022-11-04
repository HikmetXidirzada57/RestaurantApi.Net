using Business.Abstract;
using Business.Concrete;
using Core.Security.Hasing;
using Core.Security.JWT;
using Core.Security.TokenHandler;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.Configure<JWTKey>(builder.Configuration.GetSection("JWTKey"));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JWTKey:Key"]);
    var issuer = builder.Configuration["JWTKey:Issuer"];
    var audience = builder.Configuration["JWTKey:Audience"];
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidIssuer = issuer,
        ValidAudience = audience
    };
});

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings
.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RestaurantDbContext>();
builder.Services.AddScoped<IMealService, MealManager>();
builder.Services.AddScoped<IMealDal, EFMealDal>();
builder.Services.AddScoped<IMealCategoryDal, EFMealCategoryDal>();
builder.Services.AddScoped<IMealCategoryService,MealCategoryManager>();
builder.Services.AddScoped<IAccaountService, AccaountManager>();
builder.Services.AddScoped<IAccauntDal, EFAccaountDal>();
builder.Services.AddScoped<IWaiterDal, EFWaiterDal>();
builder.Services.AddScoped<IWaiterService,WaiterManager>();
builder.Services.AddScoped<ITableDal, EFTableDal>();
builder.Services.AddScoped<ITableService, TableManager>();
builder.Services.AddScoped<IOrderDal, EFOrderDal>();
builder.Services.AddScoped<IOrderService,OrderManager>();
builder.Services.AddScoped<IOrderInfoDal, EFOrderInfoDal>();
builder.Services.AddScoped<IUsertoRoleDal, EFUsertoRoleDal>();
builder.Services.AddScoped<IUsertoRoleService, UsertoRoleManager>();

builder.Services.AddScoped<IRoleDal, EFRoleDal>();
builder.Services.AddScoped<IRoleService, RoleManager>();
builder.Services.AddScoped<HasingHandler>();
builder.Services.AddScoped<TokenGenerator>();
builder.Services.AddScoped<JWTKey>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
