using BLL;
using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;
using BLL.Services;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

SetupDependencies(builder);

SetupAuthentication(builder);

SetupSessions(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();


static void SetupDependencies(WebApplicationBuilder builder)
{
    //services
    builder.Services.AddTransient<IAnimalService, AnimalService>();
    builder.Services.AddTransient<IContentService, ContentService>();
    builder.Services.AddTransient<IEmployeeService, EmployeeService>();
    builder.Services.AddTransient<IEnclosureService, EnclosureService>();
    builder.Services.AddTransient<INoteService, NoteService>();
    builder.Services.AddTransient<ISpeciesService, SpeciesService>();
    builder.Services.AddTransient<ITaskService, TaskService>();

    //repos
    builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
    builder.Services.AddTransient<IContentRepository, ContentRepository>();
    builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
    builder.Services.AddTransient<IEnclosureRepository, EnclosureRepository>();
    builder.Services.AddTransient<INoteRepository, NoteRepository>();
    builder.Services.AddTransient<ISpeciesRepository, SpeciesRepository>();
    builder.Services.AddTransient<ITaskRepository, TaskRepository>();
}

static void SetupAuthentication(WebApplicationBuilder builder)
{
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/Error");
    });
}

static void SetupSessions(WebApplicationBuilder builder)
{
    builder.Services.AddSession
        (options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(5);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
}