namespace BlazorBFA.ViewModels;

public class ServicesViewModel
{
    public string SectionLabel { get; } = "I Nostri Servizi";
    public string Title { get; } = "Quali servizi";
    public string TitleHighlight { get; } = "Offriamo";
    public string Description { get; } = "Un pacchetto completo per la gestione energetica degli enti pubblici, sollevandovi da ogni onere amministrativo.";

    public List<ServiceModel> Services { get; } =
    [
        new()
        {
            Number = "01",
            Icon = "fact_check",
            Title = "Controllo correttezza fatture",
            Summary = "Verifica contabile con certificazione di conformità alla normativa ARERA.",
            Accent = "blue",
            GradientFrom = "#3b82f6",
            GradientTo = "#22d3ee",
            Details =
            [
                "Acquisizione digitale completa della fattura",
                "Certificazione di conformità addebiti con normativa ARERA",
                "Gestione reclami per recupero errori di fatturazione"
            ]
        },
        new()
        {
            Number = "02",
            Icon = "electric_bolt",
            Title = "Gestione forniture energia elettrica e gas",
            Summary = "Catasto elettrico on-line con monitoraggio consumi e dashboard interattiva.",
            Accent = "emerald",
            GradientFrom = "#10b981",
            GradientTo = "hsl(160 84% 39%)",
            Details =
            [
                "Catasto forniture elettriche e gas on-line",
                "Ricognizione POD georiferiti su Google Maps",
                "Attivazione nuove forniture e adeguamento contratti",
                "Monitoraggio consumi con invio allarmi automatici",
                "Dashboard interattiva per statistiche e spese"
            ]
        },
        new()
        {
            Number = "03",
            Icon = "account_balance",
            Title = "Gestione liquidazione fatture",
            Summary = "Liquidazione periodica per fornitore e centro di costo con controllo on-line.",
            Accent = "indigo",
            GradientFrom = "#6366f1",
            GradientTo = "#3b82f6",
            Details =
            [
                "Previsione fabbisogno di spesa per centro di costo",
                "Determina e distinta di liquidazione",
                "Gestione dei pagamenti e aggiornamento PEG",
                "Rendicontazione e controllo on-line della spesa"
            ]
        },
        new()
        {
            Number = "04",
            Icon = "gavel",
            Title = "Gestione contenzioso pregresso",
            Summary = "Analisi e gestione completa delle richieste di pagamento per fatturazioni pregresse.",
            Accent = "violet",
            GradientFrom = "#8b5cf6",
            GradientTo = "#a855f7",
            Details =
            [
                "Ricognizione e liquidazione insoluto pregresso",
                "Gestione richieste di pagamento e cessioni di credito",
                "Supporto in tutte le fasi del contenzioso",
                "Consulenza legale specializzata"
            ]
        },
        new()
        {
            Number = "05",
            Icon = "savings",
            Title = "Risparmio sulla spesa energetica",
            Summary = "Massimizza il risparmio riducendo inefficienze e risorse umane dedicate.",
            Accent = "teal",
            GradientFrom = "hsl(160 84% 39%)",
            GradientTo = "#2dd4bf",
            Details =
            [
                "Controllo dei consumi e della spesa",
                "Recupero errori di fatturazione",
                "Riduzione perdite e inefficienze",
                "Riduzione risorse umane interne dedicate"
            ]
        }
    ];
}

public class ServiceModel
{
    public string Number { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Accent { get; set; } = string.Empty;
    public string GradientFrom { get; set; } = string.Empty;
    public string GradientTo { get; set; } = string.Empty;
    public List<string> Details { get; set; } = [];
}
