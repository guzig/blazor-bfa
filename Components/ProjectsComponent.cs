using BlazorBFA.ViewModels;
using Microsoft.JSInterop;

namespace BlazorBFA.Components;

public partial class ProjectsComponentView
{
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("portfolioMarquee.init");
    }

    public async void Dispose()
    {
        try { await JS.InvokeVoidAsync("portfolioMarquee.dispose"); } catch { }
    }

    private static string GetInitials(string name)
    {
        var parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return "BF";
        if (parts.Length == 1) return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpperInvariant();
        return string.Concat(parts[0][0], parts[^1][0]).ToUpperInvariant();
    }
}
