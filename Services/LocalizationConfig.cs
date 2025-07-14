using Microsoft.AspNetCore.Localization;
using System.Globalization;

public static class LocalizationConfig
{
    public static IServiceCollection AddCustomLocalization(this IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");

        services.AddControllersWithViews()
            .AddViewLocalization()
            .AddDataAnnotationsLocalization();

        return services;
    }

    public static IApplicationBuilder UseCustomLocalization(this IApplicationBuilder app)
    {
        var supportedCultures = new[]
        {
            new CultureInfo("es"),
            new CultureInfo("en"),
            new CultureInfo("it")
        };

        var localizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures,
            RequestCultureProviders = new IRequestCultureProvider[]
            {
                new CookieRequestCultureProvider(),
                new QueryStringRequestCultureProvider() 
            }
        };

        app.UseRequestLocalization(localizationOptions);

        return app;
    }
}
