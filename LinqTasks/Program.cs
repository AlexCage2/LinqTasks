using LinqTasks.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    /* Servives */
    /* Database Context Dependecy Injection */
    string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
    string dbName = Environment.GetEnvironmentVariable("DB_NAME");
    string dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
    string connection = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};Encrypt = false;";
    //string connection = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

    /* MVC Dependecy Injection */
    builder.Services.AddControllersWithViews();
}


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

{
    /* Middlewares */
    app.UseHttpsRedirection();
    app.UseFileServer();
    app.UseRouting();
}

/* Configure Routing */
app.MapControllers();

app.Run();