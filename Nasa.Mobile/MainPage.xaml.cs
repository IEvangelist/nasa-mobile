using Apod;

namespace Nasa.Mobile;

public sealed partial class MainPage : ContentPage, IDisposable
{
    private readonly ApodClient _client = null!;

    public readonly DateTime MinDate = new(1995, 6, 20);
    public readonly DateTime MaxDate = DateTime.Today;

    public DateTime SelectedDate { get; set; } = DateTime.Today;

    public MainPage()
    {
        InitializeComponent();
        _client = Handler.MauiContext.Services.GetRequiredService<ApodClient>();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        var response = await _client.FetchApodAsync(1);
        if (response is { StatusCode: ApodStatusCode.OK })
        {
            _image.Source = response.Content.ContentUrlHD;
            SemanticScreenReader.Announce(response.Content.Explanation);
        }
    }

    void IDisposable.Dispose() => _client?.Dispose();
}

