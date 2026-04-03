namespace BlazorBFA.Components;

public partial class FooterComponentView
{
    private static string GetBrandText(string brandName)
    {
        return brandName.StartsWith("BFA ", StringComparison.OrdinalIgnoreCase)
            ? brandName[4..]
            : brandName;
    }
}
