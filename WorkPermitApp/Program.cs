using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkPermitApp.Data;
using WorkPermitApp.Mapper;
using WorkPermitApp.Repository.Implementation;
using WorkPermitApp.Repository.Interfaces;
using WorkPermitApp.ServiceExtensions;
using WorkPermitApp.Services.Implementation;
using WorkPermitApp.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Connect to the database 
builder.Services.AddDbContext<WorkPermitDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add the auto Mapper configuation to create the mapping.
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IWorkPermitRepository, WorkPermitRepository>();
builder.Services.AddScoped<IWorkPermitService, WorkPermitService>();

// invoke database configuration 
//builder.Services.AddDbConfiguration(builder.Configuration);
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowAnyOrigin();
    });
});
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
