using QuotesService.BusinessLogicLayer;
using QuotesService.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var endpoint = Environment.GetEnvironmentVariable("AZURE_COSMOSDB_ENDPOINT");
var key = Environment.GetEnvironmentVariable("AZURE_COSMOSDB_KEY");
var respository = new QuotesCosmosRepository(endpoint, key, "howtoreact", "quotes") ;
_ = respository.InitializeAsync();

builder.Services.AddSingleton(s => respository);
builder.Services.AddTransient<QuotesHandler>();
builder.Services.AddTransient<QuotesRandomizer>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "all",
                      policy =>
                      {
                          policy.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("all");

app.Run();