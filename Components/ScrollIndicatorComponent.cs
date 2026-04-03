using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorBFA.Components;

public partial class ScrollIndicatorComponentView
{
    [Inject] private IJSRuntime JS { get; set; } = default!;

    [Parameter] public string TargetSection { get; set; } = "";
    [Parameter] public string Text { get; set; } = "Scorri";
    /// <summary>"light" (default, white) for dark sections; "dark" for light/white sections.</summary>
    [Parameter] public string Variant { get; set; } = "light";

    private async Task ScrollToNext()
    {
        if (!string.IsNullOrEmpty(TargetSection))
        {
            await JS.InvokeVoidAsync("scrollToSection", TargetSection);
        }
    }
}
