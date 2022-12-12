using QuotesService.BusinessLogicLayer;
using QuotesService.Model;
using QuotesService.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<QuotesFileRepository>(s => new QuotesFileRepository(@".\MyFavoriteQuotes.json", QuoteType.FAVORITE));
builder.Services.AddTransient<QuotesFileRepository>(s => new QuotesFileRepository(@".\FamouseQuotes.json", QuoteType.FAMOUSE));
builder.Services.AddTransient<QuotesFileRepository>(s => new QuotesFileRepository(@".\Temp\OthersFavoriteQuotes.json", QuoteType.SOMEONE_OTHERS_FAVORITE));
builder.Services.AddTransient<QuotesHandler>();
builder.Services.AddTransient<QuotesRandomizer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
