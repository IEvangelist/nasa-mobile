using Apod;

namespace Nasa.Mobile.Extensions;

internal static class MauiAppBuilderExtensions
{
    internal static MauiAppBuilder AddAppServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton(
            _ => new ApodClient(
                Environment.GetEnvironmentVariable(
                    "NasaApiOptions__ApiKey")));

        return builder;
    }
}
