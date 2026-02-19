using GeniusChuck.Newsletter.Web;
using GeniusChuck.Newsletter.Web.Data;
using GeniusChuck.Newsletter.Web.Interfaces;
using GeniusChuck.Newsletter.Web.Services;
using GeniusChuck.Newsletter.Web.Validations;
using Mapster;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var mvcBuilder = builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        // Utilisation d'un fichier de ressources pour traduire les messages par défaut des annotations de validation.
        // Source: https://github.com/dotnet/aspnetcore/issues/4848#issuecomment-718060602
        options.ModelMetadataDetailsProviders.Add(new MetadataTranslationProvider(typeof(MyAnnotations)));
    });

if (builder.Environment.IsDevelopment())
{
    // Ajouter le RazorRuntimeCompilation seulement lorsqu'on est en mode développement
    mvcBuilder.AddRazorRuntimeCompilation();
}

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(x =>
{
    if (builder.Environment.IsDevelopment())
    {
        // N'affichez les données sensibles qu'en mode développement uniquement.
        x.EnableSensitiveDataLogging();
    }
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//builder.Services.AddScoped<INewsletterService, NewsletterInMemoryService>(); // Liste en mémoire au lieu d'une BD.
builder.Services.AddScoped<INewsletterService, NewsletterService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddMapster();
//builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}")
app.MapDefaultControllerRoute().WithStaticAssets();


app.Run();
