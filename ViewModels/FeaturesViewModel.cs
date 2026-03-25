namespace BlazorBFA.ViewModels;

public class FeaturesViewModel
{
    public string BadgeText { get; } = "Perch\u00e9 Sceglierci";

    public string Title { get; } = "Una piattaforma";
    public string TitleHighlight { get; } = "specializzata";
    public string TitleEnd { get; } = "per la gestione energetica e il monitoraggio della spesa.";

    public string Description { get; } = "La nostra piattaforma integra le tecnologie pi\u00f9 avanzate per gestire l'energia in modo intelligente, efficiente e sostenibile.";

    public string ButtonText { get; } = "Inizia Ora";
    public string ButtonIcon { get; } = "rocket_launch";

    public string ImagePath { get; } = "images/smart-data.jpg";
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
            Icon = "hub",
            Title = "Un solo posto per tutto",
            Description = "Contratti, consumi, fatture e scadenze: tutto visibile da un'unica interfaccia, senza saltare tra sistemi.",
            IconBg = "rgba(0, 112, 160, 0.15)",
            IconColor = "#0070a0"
        },
        new()
        {
            Icon = "tips_and_updates",
            Title = "Dati che diventano decisioni",
            Description = "Non solo grafici \u2014 il portale segnala anomalie, scostamenti e opportunit\u00e0 di risparmio in modo azionabile.",
            IconBg = "rgba(139, 92, 246, 0.2)",
            IconColor = "#a78bfa"
        },
        new()
        {
            Icon = "account_balance",
            Title = "Pensato per la PA",
            Description = "Flussi conformi al codice degli appalti, gestione multi-ente, tracciabilit\u00e0 documentale. Non adattato \u2014 progettato.",
            IconBg = "rgba(16, 185, 129, 0.15)",
            IconColor = "#10b981"
        },
        new()
        {
            Icon = "speed",
            Title = "Risparmi dimostrabili",
            Description = "Report pronti per dirigenti e revisori, con evidenza concreta dei risultati ottenuti.",
            IconBg = "rgba(245, 158, 11, 0.2)",
            IconColor = "#fbbf24"
        },
        new()
        {
            Icon = "monitor_heart",
            Title = "Monitoraggio Continuo",
            Description = "Consumi, scostamenti e anomalie sotto controllo in tempo reale \u2014 con alert automatici prima che un problema diventi un costo.",
            IconBg = "rgba(239, 68, 68, 0.15)",
            IconColor = "#ef4444"
        },
        new()
        {
            Icon = "space_dashboard",
            Title = "Cruscotto operativo",
            Description = "I dati energetici vengono acquisiti, elaborati e resi fruibili sulla piattaforma senza alcun impegno per l'Ente, che dispone di un cruscotto operativo a supporto delle proprie decisioni strategiche in materia di energia e sostenibilit\u00e0.",
            IconBg = "rgba(0, 112, 160, 0.12)",
            IconColor = "#0070a0"
        }
    ];

    public List<FloatingBadge> FloatingBadges { get; } =
    [
        new("check_circle", "Sistema Attivo", "var(--accent-color)", "badge-top-left"),
        new("schedule", "Real-time", "var(--primary-light)", "badge-bottom-left"),
        new("trending_up", "+45% Efficienza", "var(--accent-color)", "badge-right")
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
