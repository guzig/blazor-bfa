namespace BlazorBFA.ViewModels;

public class AboutViewModel
{
    public string SectionLabel { get; } = "Chi siamo";
    public string Title { get; } = "Siamo un team di professionisti con esperienza nel settore energetico e nella PA per trasformare la complessità del mercato in vantaggio per i nostri clienti";
    public string Description { get; } = "Fondata nel 2015, BFA Consulting è una società di consulenza energetica che affianca imprese e PA nella gestione strategica dell'energia. Uniamo competenza tecnica, software specialistico avanzato, e visione di lungo periodo per offrire soluzioni concrete di risparmio, efficienza e sostenibilità. Perché il cambiamento energetico non è solo una sfida — è un'opportunità.";
    public string VideoPath { get; } = "videos/about-bg.mp4";
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
