using Microsoft.EntityFrameworkCore;
using OutDoor_Backend;
using OutDoor_Backend.ExceptionHanlder;
using OutDoor_Models;
using OutDoor_Models.Repositorys;
using OutDoor_Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#if DEBUG
    var varConnectionString = builder.Configuration.GetConnectionString("DataBaseDev");
#else
    var varConnectionString = builder.Configuration.GetConnectionString("DataBaseProd");
#endif
builder.Services.AddDbContext<DbMainContext>(options => options.UseNpgsql(varConnectionString));

ConfigScoped configuration = new ConfigScoped();

builder = configuration.ConfigureServiceScopes(builder);

builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000", "http://localhost:49400")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ExceptionProcessor));
});

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
app.UseCors(MyAllowSpecificOrigins);

app.Run();


