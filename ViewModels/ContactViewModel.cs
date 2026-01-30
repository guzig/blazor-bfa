namespace BlazorBFA.ViewModels;

public class ContactViewModel
{
    public string SectionLabel { get; } = "Contattaci";
    public string Title { get; } = "Resta in contatto con noi";
    public string TitleHighlight { get; } = "adesso";
    
    public string FormTitle { get; } = "Invia un messaggio";
    public string SubmitButtonText { get; } = "Invia messaggio";
    public string SubmitButtonIcon { get; } = "send";
    
    public string AddressCity { get; } = "Isola di Capo Rizzuto (KR)";
    public string AddressStreet { get; } = "Via Crotone 59";
    
    public List<ContactInfoItem> ContactInfo { get; } =
    [
        new("phone", "Telefono", "+39 0962 123456", "tel:+390962123456"),
        new("email", "Email", "info@bfaconsulting.it", "mailto:info@bfaconsulting.it"),
        new("schedule", "Orari", "Lun-Ven 9:00-18:00", "#contact")
    ];
}

public record ContactInfoItem(string Icon, string Label, string Value, string Href);
