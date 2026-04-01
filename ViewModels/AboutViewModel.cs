namespace BlazorBFA.ViewModels;

public class AboutViewModel
{
    public string SectionLabel { get; } = "Chi siamo";
    public string Title { get; } = "Siamo un team di professionisti con esperienza nel settore energetico e nella PA per trasformare la complessit\u00E0 del mercato in";
    public string TitleHighlight { get; } = "vantaggio per i nostri clienti";
    public string Description { get; } = "Fondata nel 2015, BFA Consulting \u00E8 una societ\u00E0 di consulenza energetica che affianca imprese e PA nella gestione strategica dell'energia. Uniamo competenza tecnica, software specialistico avanzato, e visione di lungo periodo per offrire soluzioni concrete di risparmio, efficienza e sostenibilit\u00E0. Perch\u00E9 il cambiamento energetico non \u00E8 solo una sfida: \u00E8 un'opportunit\u00E0.";
    public string VideoPath { get; } = "images/chisiamo-video.mp4";
    public string ImagePath { get; } = "images/about.jpg";
    public string ImageAlt { get; } = "BFA Consulting Team";

    public string CtaText { get; } = "Scopri i nostri servizi";
    public string CtaHref { get; } = "#services";

    public List<AboutHighlight> Highlights { get; } =
    [
        new("insights", "Analisi Predittiva", "Monitoriamo costi e consumi per prevenire inefficienze.", "#0070a0", "#00a8e8"),
        new("account_tree", "Governance Operativa", "Processi chiari tra uffici tecnici, finanziari e amministrativi.", "#00a8e8", "#00d4aa")
    ];

    public List<SuccessIndicator> SuccessIndicators { get; } =
    [
        new("52+", "Comuni assistiti", "Reti territoriali attive"),
        new("2.4M", "Euro ottimizzati", "Valore annuo stimato"),
        new("1.250+", "Fatture analizzate", "Controllo tecnico-contabile"),
        new("98.7%", "Accuratezza processi", "Qualita operativa continuativa")
    ];
}

public record StatItem(string Label, double Value);
public record AboutHighlight(string Icon, string Title, string Description, string GradientStart, string GradientEnd);
public record SuccessIndicator(string Value, string Label, string Detail);
