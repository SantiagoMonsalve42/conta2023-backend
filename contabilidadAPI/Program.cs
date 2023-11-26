using Bussines.implementations;
using Bussines.Implementations;
using Bussines.Interfaces;
using Common.Utilities;
using Data.Common;
using Data.Implementations;
using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
#region swagger
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
#endregion
builder.Services.AddCors();
#region endpoint
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("isAdmin", policy => policy.RequireClaim("isAdmin"));
});
#endregion
#region dependency injection
builder.Services.AddScoped<SpDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IBaseCrud<>), typeof(BaseCrud<>));
builder.Services.AddScoped(typeof(AccountTypeData));
builder.Services.AddScoped(typeof(DocumentTypeData));
builder.Services.AddScoped(typeof(ExecuteSp));
builder.Services.AddScoped(typeof(StringUtil));
builder.Services.AddScoped(typeof(FileSystemGenerico));
builder.Services.AddScoped(typeof(ILogBussines), typeof(LogBussines));
builder.Services.AddScoped(typeof(ILogData), typeof(LogData));
builder.Services.AddScoped(typeof(IUserData), typeof(UserData));
builder.Services.AddScoped(typeof(IUserAccountData), typeof(UserAccountData));
builder.Services.AddScoped(typeof(ITransaccionData), typeof(TransaccionData));

builder.Services.AddScoped(typeof(IAccountTypeBussines), typeof(AccountTypeBussines));
builder.Services.AddScoped(typeof(IDocumentTypeBussines), typeof(DocumentTypeBussines));
builder.Services.AddScoped(typeof(IUserBussines), typeof(UserBussines));
builder.Services.AddScoped(typeof(IUserAccountBussines), typeof(UserAccountBussines));
builder.Services.AddScoped(typeof(ITransactionBussines), typeof(TransactionBussines));
#endregion

HelperConfiguration.Configuration = builder.Configuration;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();
var origin = builder.Configuration["AppConfig:Origin"];
app.UseCors(options =>
  options.WithOrigins(origin)
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
