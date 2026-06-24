using Microsoft.EntityFrameworkCore;
using Portafolio.Components;
using Portafolio.Modelos;  // ← esta línea conecta tu AppDBContext

var builder = WebApplication.CreateBuilder(args);

// ✅ AGREGA ESTAS 3 LÍNEAS
string? connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<AppDBContext>(options => options.UseSqlServer(connStr));
builder.Services.AddQuickGridEntityFrameworkAdapter();
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();