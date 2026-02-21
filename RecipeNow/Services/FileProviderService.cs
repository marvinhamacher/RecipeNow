using RecipeNow.Data.Entities.RecipeSystem;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
namespace RecipeNow.Services;

public class FileProviderService : IFileProviderService
{
    
    private readonly IRecipeService _recipeService;
    private readonly IStorageRoomService _storageRoomService;
    private readonly IWebHostEnvironment _env;
    public FileProviderService(IRecipeService recipeService, IStorageRoomService storageRoomService, IWebHostEnvironment env)
    {
        _recipeService = recipeService;
        _storageRoomService = storageRoomService;
        _env = env;
    }
    
    public async Task<byte[]> CreateRecipeTxtBlob(int recipeId)
    {
        Recipe recipe = await _recipeService.GetByIdAsync(recipeId) ?? throw new Exception("Recipe not found");
        string content = "Rezept: " + recipe.Name + Environment.NewLine +
                         "Beschreibung: " + recipe.Description + Environment.NewLine +
                         "Zubereitungszeit: " + recipe.PreparationTime + " Minuten" + Environment.NewLine +
                         "Kochzeit:" + recipe.CookingTime + Environment.NewLine +
                         "Zutaten:" + Environment.NewLine;
        foreach (var ingredient in recipe.RecipeIngredients)
        {
            content += "- " + ingredient.Ingredient.Name + ": " + ingredient.Amount + Environment.NewLine;
        }

        content += "Anleitung:" + Environment.NewLine + recipe.CookingInstructions + Environment.NewLine;
        return System.Text.Encoding.UTF8.GetBytes(content);
    }
    

    public async Task<Stream> CreateRecipePdfStream(int recipeId)
    {
        Recipe recipe = await _recipeService.GetByIdAsync(recipeId)
                        ?? throw new Exception("Recipe not found");

        var stream = new MemoryStream();

        Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);

                    page.Header()
                        .Text(recipe.Name)
                        .FontSize(24)
                        .SemiBold()
                        .FontColor(Colors.Black);

                    page.Content().Column(column =>
                    {
                        column.Spacing(10);
                        var fullPath = Path.Combine(_env.WebRootPath, recipe.ImagePath.TrimStart('/'));
                        if (File.Exists(fullPath))
                        {
                            var imageBytes = File.ReadAllBytes(fullPath);

                            column.Item()
                                .Image(imageBytes)
                                .FitWidth();
                        }


                        column.Item().Text($"Beschreibung: {recipe.Description}");
                        
                        column.Item().Text($"Zubereitungszeit: {recipe.PreparationTime} Minuten");
                        column.Item().Text($"Kochzeit: {recipe.CookingTime} Minuten");
                        
                        column.Item().Text("Zutaten:")
                            .FontSize(16)
                            .SemiBold();

                        foreach (var ingredient in recipe.RecipeIngredients)
                        {
                            column.Item().Text(
                                $"- {ingredient.Ingredient.Name}: {ingredient.Amount}"
                            );
                        }
                        column.Item().Text("Anleitung:")
                            .FontSize(16)
                            .SemiBold();
                        column.Item().Text($"{recipe.CookingInstructions}");
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Erstellt am ");
                            x.Span(DateTime.Now.ToString("dd.MM.yyyy"));
                        });
                });
            })
            .GeneratePdf(stream);

        stream.Position = 0;
        return stream;
    }
    
    public async Task<Stream> CreateInventoryPdfStream()
    {
        var rooms = await _storageRoomService.GetAllStorageRoomsByCurrentUserAsync();

        var stream = new MemoryStream();
        var today = DateTime.UtcNow.Date;
        var warningThreshold = today.AddDays(7);

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);

                page.Header()
                    .Text("Inventur")
                    .FontSize(24)
                    .SemiBold();

                page.Content().Column(column =>
                {
                    column.Spacing(10);

                    foreach (var room in rooms)
                    {
                        column.Item().Text($"Raum: {room.Name}")
                            .FontSize(18)
                            .SemiBold();

                        foreach (var shelf in room.StorageRoomShelf)
                        {
                            column.Item().Text($"Schrank: {shelf.ContentDescription}")
                                .FontSize(14)
                                .SemiBold();

                            foreach (var si in shelf.ShelfIngredients)
                            {
                                var status = "";
                                var color = Colors.Black;

                                if (si.ExpirationDate.Date < today)
                                {
                                    status = "ABGELAUFEN";
                                    color = Colors.Red.Darken2;
                                }
                                else if (si.ExpirationDate.Date <= warningThreshold)
                                {
                                    status = "Kurz vor Ablauf";
                                    color = Colors.Orange.Darken2;
                                }

                                column.Item().Text(text =>
                                {
                                    text.Span($"{si.Ingredient?.Name} | ");
                                    text.Span($"{si.Amount} {si.Ingredient?.Measurement} | ");
                                    text.Span($"Reihe: {si.Row} | Spalte: {si.Column} | ");
                                    text.Span($"Ablauf: {si.ExpirationDate:dd.MM.yyyy} ");

                                    if (!string.IsNullOrEmpty(status))
                                    {
                                        text.Span($"({status})")
                                            .FontColor(color)
                                            .SemiBold();
                                    }
                                });
                            }
                        }

                        column.Item().PaddingBottom(10);
                    }
                });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Inventur erstellt am ");
                        x.Span(DateTime.Now.ToString("dd.MM.yyyy"));
                    });
            });
        })
        .GeneratePdf(stream);

        stream.Position = 0;
        return stream;
    }
}