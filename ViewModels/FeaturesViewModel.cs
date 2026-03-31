namespace BlazorBFA.ViewModels;

public class FeaturesViewModel
{
    public string BadgeText { get; } = "Perch\u00E9 Sceglierci";

    public string Title { get; } = "La differenza che";
    public string TitleHighlight { get; } = "fa la differenza";

    public string Description { get; } = "Non siamo un semplice fornitore. Siamo il vostro ufficio energia esterno, sempre operativo.";

    public string CtaLabel { get; } = "Pronti a iniziare?";
    public string CtaTitle { get; } = "Il risparmio parte da una semplice chiamata.";
    public string CtaButton { get; } = "Preventivo gratuito \u2192";

    public List<FeaturesStat> Stats { get; } =
    [
        new("schedule", "10+", "Anni di esperienza", "Dal 2015 al fianco degli enti pubblici calabresi"),
        new("location_city", "14+", "Comuni serviti", "In tutta la Calabria, dalle province di CS, KR, CZ, RC"),
        new("trending_up", "100%", "Risparmio garantito", "Il nostro compenso \u00E8 sempre inferiore al risparmio ottenuto")
    ];

    public List<FeatureItem> Features { get; } =
    [
        new()
        {
            Icon = "gavel",
            Title = "Conformit\u00E0 normativa ARERA",
            Description = "Ogni fattura viene analizzata e certificata secondo le ultime disposizioni dell\u2019Autorit\u00E0 di Regolazione per Energia Reti e Ambiente.",
            GradientStyle = "linear-gradient(to bottom right, #3b82f6, #22d3ee)"
        },
        new()
        {
            Icon = "support_agent",
            Title = "Risposta rapida e puntuale",
            Description = "Interveniamo in tempi brevissimi su richieste di chiarimento, reclami e situazioni di contenzioso, senza lasciare l\u2019ente scoperto.",
            GradientStyle = "linear-gradient(to bottom right, #10b981, hsl(var(--primary)))"
        },
        new()
        {
            Icon = "engineering",
            Title = "Supporto operativo in loco",
            Description = "Non solo consulenza remota: i nostri tecnici affiancano il vostro personale direttamente presso gli uffici comunali quando necessario.",
            GradientStyle = "linear-gradient(to bottom right, #8b5cf6, #6366f1)"
        }
    ];
}

public record FeaturesStat(string Icon, string Value, string Label, string Description);

public class FeatureItem
{
    public string Icon { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string GradientStyle { get; set; } = string.Empty;
}
