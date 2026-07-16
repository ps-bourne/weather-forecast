using weather_forecast.Services;

namespace weather_forecast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var cities = builder.Configuration.GetSection("Cities").Get<ICollection<string>>() ?? new List<string>();

            builder.Services.Configure<Configs.WeatherForecastOptions>(options =>
            {
                options.Cities = cities;
            });

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<WeatherForecastService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
