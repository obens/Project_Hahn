using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleApi.Models;

// Create a WebApplication builder to configure services and app
var builder = WebApplication.CreateBuilder(args);

// Register the InMemoryDataRepository as a singleton service for the IDataRepository interface
builder.Services.AddSingleton<IDataRepository, InMemoryDataRepository>();

// Add support for controllers (MVC pattern)
builder.Services.AddControllers();

// Build the WebApplication from the configured builder
var app = builder.Build();

// Map controller endpoints (e.g., [Route], [HttpGet]) to handle HTTP requests
app.MapControllers();

// Start the web server
app.Run();

// Define the repository interface to abstract data access
public interface IDataRepository
{
    IEnumerable<DataModel> GetAll(); // Method to get all data items
}

// In-memory implementation of the IDataRepository interface
public class InMemoryDataRepository : IDataRepository
{
    // A simple list of DataModel items used as mock data
    private readonly List<DataModel> _data = new()
    {
        new DataModel { Id = 1, Name = "Item 1" },
        new DataModel { Id = 2, Name = "Item 2" },
    };

    // Implementation of GetAll method to return all items
    public IEnumerable<DataModel> GetAll() => _data;
}
