namespace BlazorBFA.ViewModels;

public class NavbarViewModel
{
    public string BrandName { get; } = "BFA Consulting";
    
    public List<NavLinkItem> NavLinks { get; } =
    [
        new("Home", "#home"),
        new("Chi Siamo", "#about"),
        new("Servizi", "#services"),
        new("Progetti", "#projects"),
        new("Testimonial", "#testimonials"),
        new("Contatti", "#contact")
    ];
    
    public string CtaButtonText { get; } = "Preventivo";
    public string CtaButtonIcon { get; } = "call";
}

public record NavLinkItem(string Name, string Href);
