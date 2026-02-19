using RecipeNow.Data.Entities.RecipeSystem;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
namespace RecipeNow.Services;

public class FileProviderService : IFileProviderService
{
    
    private readonly IRecipeService _recipeService;
    private readonly IWebHostEnvironment _env;
    public FileProviderService(IRecipeService recipeService, IWebHostEnvironment env)
    {
        _recipeService = recipeService;
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

        content += "Anleitung:" + recipe.CookingInstructions + Environment.NewLine;
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
                        column.Item().Text($"Anleitung: {recipe.CookingInstructions}");
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
}