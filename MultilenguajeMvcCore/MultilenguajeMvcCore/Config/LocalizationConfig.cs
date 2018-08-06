using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace MultilenguajeMvcCore.Config
{
    public class LocalizationConfig
    {
        public static void Configure(IServiceCollection service)
        {
            service.AddLocalization(options => options.ResourcesPath = "Resources");
            service.Configure<RequestLocalizationOptions>(options =>
            {
                var supporteCultures = new[]
                {
                    new CultureInfo("en-Us"),
                    new CultureInfo("es-ES")
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "es-ES", uiCulture: "es-ES");

                options.SupportedCultures = supporteCultures;
                options.SupportedUICultures = supporteCultures;
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
        }
    }
}
