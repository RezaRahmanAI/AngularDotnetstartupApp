var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Enables controllers with views

// Add Swagger (Optional for API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Swagger and static file serving
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Serve Angular static files (dist folder)
app.UseRouting(); // Enable routing

app.UseAuthorization();

// Map API controllers
app.MapControllers();

// Map fallback to Angular's index.html for SPA routing
app.MapFallbackToFile("index.html").AllowAnonymous();

app.Run();
