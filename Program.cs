using Npgsql;
using web_api_practise_dotnet_core.DbContext;
using web_api_practise_dotnet_core.IRepository;
using web_api_practise_dotnet_core.Repository;
using web_api_practise_dotnet_core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDbContext<NpgsqlCommand>,PostgreDbContext>();

builder.Services.AddSingleton(typeof(StudentService));

builder.Services.AddTransient<IStudentRepo, StudentRepo>();
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
