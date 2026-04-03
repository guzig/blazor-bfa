using Microsoft.JSInterop;

namespace BlazorBFA.Components;

public partial class NavbarComponentView
{
    private bool isMobileMenuOpen;

    private void ToggleMobileMenu() => isMobileMenuOpen = !isMobileMenuOpen;
    private void CloseMobileMenu() => isMobileMenuOpen = false;

    private async Task ScrollToContatti()
    {
        CloseMobileMenu();
        await JS.InvokeVoidAsync("scrollToSection", "contatti");
    }

    private static string GetBrandText(string brandName)
    {
        return brandName.StartsWith("BFA ", StringComparison.OrdinalIgnoreCase)
            ? brandName[4..]
            : brandName;
    }
}
