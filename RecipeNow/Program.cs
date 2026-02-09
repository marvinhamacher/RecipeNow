using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeNow.Components;
using RecipeNow.Config;
using RecipeNow.Data;
using RecipeNow.Data.Contexts;
using RecipeNow.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
// Falls Services benutzt werden:
builder.Services.AddScoped<RecipeService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.Configure<UploadSettings>(
    builder.Configuration.GetSection("UploadSettings"));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AuthDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCascadingAuthenticationState(); // Wichtig für Blazor Auth-Status
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
            options.Password.RequireDigit = false; // Optional: Passwort-Regeln anpassen
            options.Password.RequiredLength = 6; 
    })
        .AddEntityFrameworkStores<AuthDbContext>()
        .AddDefaultTokenProviders();
// Falls Services benutzt werden:
builder.Services.AddScoped<RecipeService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
});

    builder.Services.AddAuthorizationCore();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapPost("/logout", async (SignInManager<IdentityUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Redirect("/");
});

// Delete genau wie Logout als POST-Endpoint
app.MapPost("/recipes/delete/{id:int}", async (int id, IRecipeService recipeService) =>
    {
        await recipeService.DeleteAsync(id);
        return Results.Redirect("/recipes");
    })
    .RequireAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();