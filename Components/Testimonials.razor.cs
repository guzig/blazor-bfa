using BlazorBFA.ViewModels;

namespace BlazorBFA.Components;

public partial class Testimonials : IDisposable
{
    private int currentIndex;
    private System.Threading.Timer? _autoTimer;
    private bool _userInteracted;
    private string _slideClass = "";

    protected override void OnAfterRender(bool firstRender)
    {
        if (!firstRender) return;
        _autoTimer = new System.Threading.Timer(async _ =>
            await InvokeAsync(async () =>
            {
                if (_userInteracted) return;
                currentIndex = (currentIndex + 1) % ViewModel.Testimonials.Count;
                _slideClass = "slide-from-right";
                StateHasChanged();
                await Task.Delay(530);
                _slideClass = "";
                StateHasChanged();
            }),
            null,
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(5));
    }

    public void Dispose() => _autoTimer?.Dispose();

    private async Task Previous()
    {
        _userInteracted = true;
        currentIndex = (currentIndex - 1 + ViewModel.Testimonials.Count) % ViewModel.Testimonials.Count;
        _slideClass = "slide-from-left";
        StateHasChanged();
        await Task.Delay(530);
        _slideClass = "";
        StateHasChanged();
        ResumeAutoPlay();
    }

    private async Task Next()
    {
        _userInteracted = true;
        currentIndex = (currentIndex + 1) % ViewModel.Testimonials.Count;
        _slideClass = "slide-from-right";
        StateHasChanged();
        await Task.Delay(530);
        _slideClass = "";
        StateHasChanged();
        ResumeAutoPlay();
    }

    private async Task GoTo(int index)
    {
        _userInteracted = true;
        var dir = index > currentIndex ? "slide-from-right" : "slide-from-left";
        currentIndex = index;
        _slideClass = dir;
        StateHasChanged();
        await Task.Delay(530);
        _slideClass = "";
        StateHasChanged();
        ResumeAutoPlay();
    }

    private void ResumeAutoPlay() =>
        Task.Delay(8000).ContinueWith(_ => InvokeAsync(() => { _userInteracted = false; }));

    private TestimonialModel GetRelative(int offset)
    {
        var count = ViewModel.Testimonials.Count;
        var index = (currentIndex + offset + count) % count;
        return ViewModel.Testimonials[index];
    }
}
