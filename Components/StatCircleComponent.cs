using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorBFA.Components;

public partial class StatCircleComponentView
{
    [Parameter] public int Percentage { get; set; }
    [Parameter] public string Label { get; set; } = "";
    [Parameter] public int Delay { get; set; }

    private ElementReference circleRef;
    private int currentValue = 0;
    private double circumference = 2 * Math.PI * 45;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("statCircleInterop.animate", circleRef, Percentage, Delay);
            await AnimateValue();
        }
    }

    private async Task AnimateValue()
    {
        await Task.Delay(Delay);
        var steps = 30;
        var increment = (double)Percentage / steps;
        var delayPerStep = 1500 / steps;

        for (int i = 0; i <= steps; i++)
        {
            currentValue = (int)Math.Round(increment * i);
            StateHasChanged();
            await Task.Delay(delayPerStep);
        }
    }
}
