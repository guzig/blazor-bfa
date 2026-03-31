namespace BlazorBFA.ViewModels;

public class FeaturesViewModel
{
    public string BadgeText { get; } = "Perch\u00E9 Sceglierci";
    
    public string Title { get; } = "Tecnologia";
    public string TitleHighlight { get; } = "All'avanguardia";
    public string TitleEnd { get; } = "per la Tua Citt\u00E0";
    
    public string Description { get; } = "La nostra piattaforma integra le tecnologie pi\u00F9 avanzate per gestire l'energia in modo intelligente, efficiente e sostenibile.";
    
    public string ButtonText { get; } = "Inizia Ora";
    public string ButtonIcon { get; } = "rocket_launch";
    
    public string ImagePath { get; } = "images/energy-consulting.jpg";
    public string ImageAlt { get; } = "Tecnologia avanzata";
    
    public List<FeatureItem> Features { get; } =
    [
        new()
        {
            Icon = "dashboard",
            Title = "Piattaforma Unificata",
            Description = "Tutti i servizi integrati in un'unica dashboard intuitiva e potente.",
            IconBg = "rgba(0, 112, 160, 0.2)",
            IconColor = "#4db8ff"
        },
        new()
        {
            Icon = "insights",
            Title = "Analisi Intelligente",
            Description = "Algoritmi avanzati per predizione, ottimizzazione e automazione.",
            IconBg = "rgba(16, 185, 129, 0.2)",
            IconColor = "#10b981"
        },
        new()
        {
            Icon = "security",
            Title = "Sicurezza Garantita",
            Description = "Protezione dati conforme GDPR e massima riservatezza.",
            IconBg = "rgba(139, 92, 246, 0.2)",
            IconColor = "#a78bfa"
        },
        new()
        {
            Icon = "speed",
            Title = "Risultati Misurabili",
            Description = "Monitoraggio costante con report dettagliati sui risparmi ottenuti.",
            IconBg = "rgba(245, 158, 11, 0.2)",
            IconColor = "#fbbf24"
        }
    ];
    
    public List<FloatingBadge> FloatingBadges { get; } =
    [
        new("check_circle", "Sistema Attivo", "var(--accent-color)", "badge-top-left"),
        new("schedule", "Real-time", "var(--primary-light)", "badge-bottom-left"),
        new("trending_up", "+45% Efficienza", "var(--accent-color)", "badge-right")
    ];

    public List<KpiStat> KpiStats { get; } =
    [
        new("52+", "Comuni assistiti", "Reti territoriali attive"),
        new("2.4M €", "Risparmi generati", "Valore annuo ottimizzato"),
        new("1.250+", "Fatture analizzate", "Controllo tecnico-contabile"),
        new("98.7%", "Accuratezza processi", "Qualità operativa continuativa")
    ];
}

public class FeatureItem
{
    public string Icon { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string IconBg { get; set; } = string.Empty;
    public string IconColor { get; set; } = string.Empty;
}

public record FloatingBadge(string Icon, string Text, string IconColor, string PositionClass);
public record KpiStat(string Value, string Label, string Detail);
