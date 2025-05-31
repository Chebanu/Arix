using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Arix.Domain.TelegramHandler;

namespace Arix.Api;

public class TelegramBotWorker : BackgroundService
{
    private readonly ILogger<TelegramBotWorker> _logger;
    private readonly ITelegramBotClient _botClient;
    private readonly ITelegramHandler _tgHandler;

    public TelegramBotWorker(ILogger<TelegramBotWorker> logger,
                              ITelegramBotClient botClient,
                              ITelegramHandler tgHandler)
    {
        _logger = logger;
        _botClient = botClient;
        _tgHandler = tgHandler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Bot starting...");

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        _botClient.StartReceiving(
            _tgHandler.HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions,
            cancellationToken: stoppingToken);

        _logger.LogInformation("Bot started!");

        await Task.Delay(-1, stoppingToken);
    }

    private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}] {apiRequestException.Message}",
            _ => exception.ToString()
        };

        _logger.LogError(errorMessage);
        return Task.CompletedTask;
    }
}