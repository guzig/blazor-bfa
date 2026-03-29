namespace BlazorBFA.ViewModels;

public class AboutViewModel
{
    public string SectionLabel { get; } = "Chi siamo";
    public string Title { get; } = "Siamo un team di professionisti con esperienza nel settore energetico e nella PA per trasformare la complessit\u00E0 del mercato in vantaggio per i nostri clienti";
    public string Description { get; } = "Fondata nel 2015, BFA Consulting \u00E8 una societ\u00E0 di consulenza energetica che affianca imprese e PA nella gestione strategica dell'energia. Uniamo competenza tecnica, software specialistico avanzato, e visione di lungo periodo per offrire soluzioni concrete di risparmio, efficienza e sostenibilit\u00E0. Perch\u00E9 il cambiamento energetico non \u00E8 solo una sfida: \u00E8 un'opportunit\u00E0.";
    public string VideoPath { get; } = "images/chisiamo-video.mp4";
    public string ImagePath { get; } = "images/about.jpg";
    public string ImageAlt { get; } = "BFA Consulting Team";

    public string CtaText { get; } = "Scopri i nostri servizi";
    public string CtaHref { get; } = "#services";

    public List<StatItem> Stats { get; } =
    [
        new("Controllo", 100),
        new("Gestione", 100),
        new("Risparmio", 100)
    ];
}

public record StatItem(string Label, double Value);
