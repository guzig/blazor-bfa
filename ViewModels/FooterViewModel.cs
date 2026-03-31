namespace BlazorBFA.ViewModels;

public class FooterViewModel
{
    public int CurrentYear { get; } = DateTime.Now.Year;
    
    public string CompanyName { get; } = "BFA Consulting";
    
    public string CompanyDescription { get; } = "Semplifichiamo la gestione delle forniture energetiche massimizzando il risparmio. Partner di fiducia per le pubbliche amministrazioni dal 2015.";
    
    public List<FooterLinkGroup> LinkGroups { get; } =
    [
        new("Servizi",
        [
            new("Controllo Fatture", "#services"),
            new("Gestione Energia", "#services"),
            new("PEG Energetico", "#services"),
            new("Contenzioso", "#services"),
            new("Risparmio", "#services")
        ]),
        new("Azienda",
        [
            new("Chi Siamo", "#about"),
            new("Progetti", "#projects"),
            new("Testimonial", "#testimonials"),
            new("Contatti", "#contact")
        ]),
        new("Risorse",
        [
            new("Documentazione", "#"),
            new("Case Study", "#"),
            new("Blog", "#"),
            new("FAQ", "#")
        ]),
        new("Legale",
        [
            new("Privacy Policy", "#"),
            new("Termini di Servizio", "#"),
            new("Cookie Policy", "#"),
            new("GDPR", "#")
        ])
    ];
    
    public List<SocialLink> SocialLinks { get; } =
    [
        new("facebook", "https://facebook.com"),
        new("alternate_email", "mailto:info@bfaconsulting.it"),
        new("calendar_month", "#contact"),
        new("photo_camera", "https://instagram.com")
    ];
}

public record FooterLinkGroup(string Title, List<FooterLink> Links);

public record FooterLink(string Text, string Href);

public record SocialLink(string Icon, string Href);
