using BLL.AutomapperProfiles;
using BLL.Services;
using DAL.Models;
using DAL.Repositories;
using PL.AutomapperProfiles;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddMvc();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IRepository<Person>>(provider => new PersonRepository(connectionString));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(PersonProfile), typeof(PersonViewModelProfile));


builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ICSVProcessing, CSVProcessingService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
