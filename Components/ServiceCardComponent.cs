using BlazorBFA.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorBFA.Components;

public partial class ServiceCardComponentView
{
    [Parameter] public ServiceModel Service { get; set; } = new();
    [Parameter] public bool IsOpen { get; set; }
    [Parameter] public EventCallback OnToggle { get; set; }

    private async Task Toggle() => await OnToggle.InvokeAsync();

    private string CardClass => $"group bg-card rounded-2xl border transition-all duration-300 overflow-hidden cursor-pointer {(IsOpen ? $"border-2 {AccentBorderClass} shadow-lg" : "border-border/50 hover:border-primary/20 hover:shadow-md")}";

    private string IconStyle => IsOpen
        ? $"background: linear-gradient(to bottom right, {Service.GradientFrom}, {Service.GradientTo})"
        : $"background: {AccentBgColor}; color: {AccentColor}";

    private string AccentColor => Service.Accent switch
    {
        "blue"    => "#3b82f6",
        "emerald" => "#10b981",
        "indigo"  => "#6366f1",
        "violet"  => "#8b5cf6",
        "teal"    => "#14b8a6",
        _         => "hsl(var(--primary))"
    };

    private string AccentBgColor => Service.Accent switch
    {
        "blue"    => "rgb(59 130 246 / 0.1)",
        "emerald" => "rgb(16 185 129 / 0.1)",
        "indigo"  => "rgb(99 102 241 / 0.1)",
        "violet"  => "rgb(139 92 246 / 0.1)",
        "teal"    => "rgb(20 184 166 / 0.1)",
        _         => "hsl(var(--primary) / 0.1)"
    };

    private string AccentBorderClass => Service.Accent switch
    {
        "blue"    => "border-blue-500/30",
        "emerald" => "border-emerald-500/30",
        "indigo"  => "border-indigo-500/30",
        "violet"  => "border-violet-500/30",
        "teal"    => "border-teal-500/30",
        _         => "border-primary/30"
    };

    private string ChevronStyle => IsOpen
        ? "font-size:1.25rem;flex-shrink:0;transition:transform 0.3s;transform:rotate(180deg);color:hsl(var(--primary))"
        : "font-size:1.25rem;flex-shrink:0;transition:transform 0.3s;color:var(--muted-foreground)";

    private string AccentTextClass => Service.Accent switch
    {
        "blue"    => "text-blue-500",
        "emerald" => "text-emerald-500",
        "indigo"  => "text-indigo-500",
        "violet"  => "text-violet-500",
        "teal"    => "text-teal-500",
        _         => "text-primary"
    };
}
