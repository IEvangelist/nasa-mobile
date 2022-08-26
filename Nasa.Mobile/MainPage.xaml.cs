using Apod;

namespace Nasa.Mobile;

public partial class MainPage : ContentPage
{
    public readonly DateTime MinDate = new(1995, 6, 20);
    public readonly DateTime MaxDate = DateTime.Today;

    DateTime _selectedDate = DateTime.Today;
    public DateTime SelectedDate
    {
        get => _selectedDate;
        set => _selectedDate = value;
    }

    public MainPage() => InitializeComponent();

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        using var client = new ApodClient(
            Environment.GetEnvironmentVariable("NasaApiOptions__ApiKey"));

        var response = await client.FetchApodAsync(1);
        if (response is { StatusCode: ApodStatusCode.OK })
        {
            _image.Source = response.Content.ContentUrlHD;
            SemanticScreenReader.Announce(response.Content.Explanation);
        }
    }
}

