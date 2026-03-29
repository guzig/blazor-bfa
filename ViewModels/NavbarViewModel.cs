namespace BlazorBFA.ViewModels;

public class NavbarViewModel
{
    public string BrandName { get; } = "BFA Consulting";
    
    public List<NavLinkItem> NavLinks { get; } =
    [
        new("Chi Siamo", "#chi-siamo"),
        new("Servizi", "#servizi"),
        new("Portfolio", "#portfolio"),
        new("Testimonial", "#testimonial"),
        new("Contatti", "#contatti")
    ];
    
    public string CtaButtonText { get; } = "Preventivo";
    public string CtaButtonIcon { get; } = "call";
}

public record NavLinkItem(string Name, string Href);
