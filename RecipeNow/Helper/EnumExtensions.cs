using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RecipeNow.Helper;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum? value)
    {
        if (value == null)
            return "";

        var member = value.GetType()
            .GetMember(value.ToString())
            .FirstOrDefault();

        var attr = member?
            .GetCustomAttribute<DisplayAttribute>();

        return attr?.Name ?? value.ToString();
    }
}