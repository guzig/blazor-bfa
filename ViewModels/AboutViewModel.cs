namespace BlazorBFA.ViewModels;

public class AboutViewModel
{
    public string SectionLabel { get; } = "Chi siamo";
    public string Title { get; } = "Siamo un team di professionisti con la passione per l'energia!";
    public string Description { get; } = "BFA Consulting nasce nel 2015. Siamo una società giovane, dinamica e in continua evoluzione. Forniamo servizi avanzati per l'approvvigionamento e la gestione dell'energia. Siamo sempre attenti alle esigenze di risparmio nei confronti del cliente. Ma soprattutto siamo sempre attenti e sensibili alle sfide poste dal grande tema del cambiamento climatico.";
    public string ImagePath { get; } = "images/about.jpg";
    public string ImageAlt { get; } = "BFA Consulting Team";
    
    public List<StatItem> Stats { get; } =
    [
        new("Controllo", 100),
        new("Gestione", 100),
        new("Risparmio", 100)
    ];
}

public record StatItem(string Label, double Value);
