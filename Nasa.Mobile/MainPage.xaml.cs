using Apod;

namespace Nasa.Mobile;

public sealed partial class MainPage : ContentPage
{
    public readonly DateTime MinDate = new(1995, 6, 20);
    public readonly DateTime MaxDate = DateTime.Today;

    public DateTime SelectedDate { get; set; } = DateTime.Today;

    public MainPage() => InitializeComponent();

    private async void OnCounterClicked(object sender, EventArgs e) =>
        await LoadRandomImageAsync();

    private async Task LoadRandomImageAsync()
    {
        var client = Handler.MauiContext.Services.GetRequiredService<ApodClient>();
        var response = await client.FetchApodAsync(1);
        if (response is { StatusCode: ApodStatusCode.OK })
        {
            _image.Source = response.Content.ContentUrlHD;
            SemanticScreenReader.Announce(response.Content.Explanation);
        }
    }
}

