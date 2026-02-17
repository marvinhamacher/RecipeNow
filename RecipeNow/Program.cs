using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeNow.Components;
using RecipeNow.Config;
using RecipeNow.Data;
using RecipeNow.Data.Contexts;
using RecipeNow.Data.Seeder;
using RecipeNow.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
// Falls Services benutzt werden:
builder.Services.AddScoped<IFileProviderService, FileProviderService>();
builder.Services.AddScoped<RecipeService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<StorageRoomService>();
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
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
});

    builder.Services.AddAuthorizationCore();
var app = builder.Build();

// Seeding für Mockdaten (muss VOR app.Run() passieren!)
if (args.Any(a => string.Equals(a, "seed", StringComparison.OrdinalIgnoreCase) ||
                  string.Equals(a, "--seed", StringComparison.OrdinalIgnoreCase)))
{
    using var scope = app.Services.CreateScope();
    var sp = scope.ServiceProvider;

    var appDb = sp.GetRequiredService<AppDbContext>();
    var authDb = sp.GetRequiredService<AuthDbContext>();
    var userManager = sp.GetRequiredService<UserManager<IdentityUser>>();

    // DB up-to-date (beide Contexts)
    await appDb.Database.MigrateAsync();
    await authDb.Database.MigrateAsync();

    // Seed-Reihenfolge: Ingredients -> Users -> Recipes
    await RecipeAndIngredientSeeder.SeedIngredientsAsync(appDb);

    // User Secrets / appsettings / Env (in der Reihenfolge) – alles über Configuration verfügbar
    var seedPassword =
        builder.Configuration["DEV_SEED_PASSWORD"]
        ?? Environment.GetEnvironmentVariable("DEV_SEED_PASSWORD");

    if (string.IsNullOrWhiteSpace(seedPassword))
        throw new InvalidOperationException("DEV_SEED_PASSWORD is not set. Set it via env var or user-secrets.");

    await RecipeAndIngredientSeeder.SeedUsersAsync(userManager, seedPassword);
    await RecipeAndIngredientSeeder.SeedRecipesAsync(appDb, userManager);

    return; // wichtig: Webserver NICHT starten
}

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
app.UseStaticFiles();
app.MapStaticAssets();
app.MapPost("/logout", async (SignInManager<IdentityUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Redirect("/");
});


app.MapPost("/recipes/delete/{id:int}", async (int id, IRecipeService recipeService) =>
    {
        await recipeService.DeleteAsync(id);
        return Results.Redirect("/recipes");
    })
    .RequireAuthorization();

app.MapPost("/StorageRoom/delete/{id:int}", async (int id, StorageRoomService storageRoomService) =>
    {
        await storageRoomService.DeleteStorageRoomAsync(id);
        return Results.Redirect("");
    })
    .RequireAuthorization();

app.MapPost("/StorageRoom/{Id:int}/delete/{ShelfId:int}", async (int Id, int ShelfId, StorageRoomService storageRoomService) =>
    {
        await storageRoomService.DeleteShelfAsync(ShelfId, Id);
        return Results.Redirect("/StorageRoom/"+Id);
    })
    .RequireAuthorization();

////StorageRoom/@_deleteModel.Id/delete/@_deleteModel.ShelfId


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
app.Run();