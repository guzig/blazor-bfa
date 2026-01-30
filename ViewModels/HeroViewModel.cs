namespace BlazorBFA.ViewModels;

public class HeroViewModel
{
    public string Label { get; } = "BFA CONSULTING";
    public string Title { get; } = "Consulenza e servizi per la";
    public string TitleHighlight { get; } = "gestione energetica";
    public string Subtitle { get; } = "Semplifichiamo la gestione delle forniture energetiche massimizzando il risparmio.";
    
    public string PrimaryButtonText { get; } = "Scopri i Servizi";
    public string PrimaryButtonIcon { get; } = "arrow_forward";
    
    public string SecondaryButtonText { get; } = "Contattaci";
    
    public string ScrollText { get; } = "Scorri per esplorare";
}
