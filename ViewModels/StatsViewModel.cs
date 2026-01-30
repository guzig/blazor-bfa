namespace BlazorBFA.ViewModels;

public class StatsViewModel
{
    // Hero stats (floating on the hero section)
    public List<HeroStat> HeroStats { get; } =
    [
        new("50+", "Comuni Serviti"),
        new("2M", "Euro Risparmiati"),
        new("99%", "Efficienza")
    ];
    
    // Stats cards section
    public List<StatCard> StatCards { get; } =
    [
        new("apartment", "50", "+", "Comuni Serviti", "#0070a0", "#00a8e8"),
        new("group", "2", "M €", "Risparmi Generati", "#00a8e8", "#00d4aa"),
        new("sensors", "1000", "+", "Fatture Controllate", "#0070a0", "#00a8e8"),
        new("eco", "99", "%", "Efficienza Energetica", "#00d4aa", "#10b981")
    ];
    
    public string ScrollText { get; } = "Scorri per esplorare";
}

public record HeroStat(string Value, string Label);

public record StatCard(string Icon, string Value, string Suffix, string Label, string GradientStart, string GradientEnd);
