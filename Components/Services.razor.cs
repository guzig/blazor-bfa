namespace BlazorBFA.Components;

public partial class Services
{
    private int? _openIndex = null;

    private void ToggleCard(int idx) =>
        _openIndex = _openIndex == idx ? null : idx;
}
