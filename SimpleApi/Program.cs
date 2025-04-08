using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDataRepository, InMemoryDataRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();

public interface IDataRepository
{
    IEnumerable<DataModel> GetAll();
}

public class InMemoryDataRepository : IDataRepository
{
    private readonly List<DataModel> _data = new()
    {
        new DataModel { Id = 1, Name = "Item 1" },
        new DataModel { Id = 2, Name = "Item 2" },
        new DataModel { Id = 3, Obenson = "Item 2" },
        new DataModel { Id = 4, Maurice = "Item 2" },
    };

    public IEnumerable<DataModel> GetAll() => _data;
}