using _8Sual.Db;
using _8Sual.Mapping;
using _8Sual.Middlewares;
using _8Sual.Options;
using _8Sual.Repositories.Implementations;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Implementations;
using _8Sual.Services.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//    AddNewtonsoftJson(options =>
//{
//    options.SerializerSettings.ContractResolver =
//                                 new DefaultContractResolver();
//});
//
ConfigurationManager configuration = builder.Configuration;

builder.Services.Configure<QuestionOptions>(configuration.GetSection("QuestionOptions"));
// inject all repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAdminUserRepository, AdminUserRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// inject all services
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IAdminUserService, AdminUserService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoginService, LoginService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuestionContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

var assembly = Assembly.GetExecutingAssembly();

builder.Services.AddValidatorsFromAssembly(assembly);

// configure AutoMapper
builder.Services.AddAutoMapper(typeof(MapProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
