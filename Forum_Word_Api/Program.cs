using forum_api.Models;
using forum_api.Repositories;
using forum_api.Repositories.Interfaces;
using forum_api.Services;
using forum_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// REPOSITORIES
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<ITopicRepository, TopicRepository>();

// SERVICES
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ITopicService, TopicService>();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddEntityFrameworkMySql().AddDbContext<forum_api_dbContext>((option) =>
{
    option.UseMySql(builder.Configuration.GetConnectionString("admin"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"),
        mySqlOptionsAction: mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
