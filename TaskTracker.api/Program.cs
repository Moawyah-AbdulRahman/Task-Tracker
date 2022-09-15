using FluentValidation;
using FluentValidation.AspNetCore;
using TaskTracker.api;
using TaskTracker.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt=>opt.Filters.Add<ValidationFilter>());
builder.Services.AddFluentValidationAutoValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskTrackerDbContext>();

builder.Services.AddScoped<IProjectRepository, ProjectDbRepository>();
builder.Services.AddScoped<IUserRepository, UserDbRepository>();
builder.Services.AddScoped<ITaskRepository, TaskDbRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IValidator<CreateProjectDto>, CreateProjectDtoValidator>();
builder.Services.AddScoped<IValidator<CreateTaskDto>, CreateTaskDtoValidator>();

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
