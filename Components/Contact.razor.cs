namespace BlazorBFA.Components;

public partial class Contact
{
    private FormData formData = new();
    private string? successMessage;

    private void HandleSubmit(FormData _)
    {
        successMessage = "Messaggio inviato! Ti risponderemo al più presto.";
        formData = new FormData();
    }

    private class FormData
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
