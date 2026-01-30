namespace BlazorBFA.ViewModels;

public class TestimonialsViewModel
{
    public List<TestimonialModel> Testimonials { get; } =
    [
        new()
        {
            Name = "Ing. Otranto Antonio",
            Role = "Tecnico Comunale",
            Content = "Personale qualificato e sempre disponibile. Ci hanno facilitato la fuoriuscita dal regime di salvaguardia in tempi brevissimi, con grande risparmio per l'Ente.",
            Rating = 5
        },
        new()
        {
            Name = "Arch. Aprigliano Marilena",
            Role = "Responsabile Amministrativo",
            Content = "Ci hanno supportato operativamente, anche presso i nostri uffici, facilitando sia la gestione corrente che il superamento del contenzioso pregresso. Con la loro consulenza e il loro supporto abbiamo contestato numerose fatture non conformi, ottenendo un risparmio molto superiore al costo dei loro servizi.",
            Rating = 5
        },
        new()
        {
            Name = "Arch. Benincasa Luigi",
            Role = "Direttore Tecnico",
            Content = "Una squadra giovane, efficiente e dinamica sempre al nostro fianco. Ci supportano in tutte le fasi della gestione energetica comunale. Il risparmio è stato superiore al costo del loro servizio.",
            Rating = 4
        }
    ];
}

public class TestimonialModel
{
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Rating { get; set; }
}
