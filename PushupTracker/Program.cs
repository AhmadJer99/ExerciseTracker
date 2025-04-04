using Microsoft.Extensions.Configuration;

static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory());
    builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    builder.AddEnvironmentVariables();
}