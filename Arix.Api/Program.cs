using Arix.Api;
using Arix.Infrastructure.Menus.Contributors;
using Arix.Infrastructure.Menus.Interfaces;
using Arix.Infrastructure.Menus.Navigations;
using Arix.Infrastructure.Menus.Services;
using Arix.Infrastructure.TelegramHandler;
using Telegram.Bot;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHostedService<TelegramBotWorker>();

        var config = builder.Configuration;

        string botToken = Environment.GetEnvironmentVariable("Arix");

        builder.Services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(botToken));
        builder.Services.AddSingleton<IMenuContributor, HomeMenuContributor>();
        builder.Services.AddSingleton<IMenuContributor, DealsMenuContributor>();
        builder.Services.AddSingleton<IMenuContributor, MainMenuContributor>();
        builder.Services.AddSingleton<IMenuContributor, SettingsMenuContributor>();
        builder.Services.AddSingleton<IMenuContributor, BalanceMenuContributor>();
        builder.Services.AddSingleton<IMenuContributor, ChallengeMenuContributor>();

        builder.Services.AddSingleton<ITelegramHandler, TelegramHandler>();
        builder.Services.AddSingleton<IMenuService, MenuService>();


        var host = builder.Build();
        host.Run();
    }
}