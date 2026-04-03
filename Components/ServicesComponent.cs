namespace BlazorBFA.Components;

public partial class ServicesComponentView
{
    private int? _openIndex = null;

    private void ToggleCard(int idx) =>
        _openIndex = _openIndex == idx ? null : idx;
}
