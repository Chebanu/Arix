using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Arix.Infrastructure.Keyboards;
using Arix.Infrastructure.Menus.Navigations;

namespace Arix.Infrastructure.TelegramHandler;

public class TelegramHandler : ITelegramHandler
{
    private readonly ILogger<ITelegramHandler> _logger;
    private readonly IMenuService _menuService;

    public TelegramHandler(ILogger<ITelegramHandler> logger, IMenuService menuService)
    {
        _logger = logger;
        _menuService = menuService;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.CallbackQuery is { } callbackQuery)
        {
            await HandleCallbackQueryAsync(botClient, callbackQuery, cancellationToken);
            return;
        }

        if (update.Message is { } message && message.Text is { } messageText)
        {
            _logger.LogInformation($"Domain Layer: got message '{messageText}' from {message.Chat.Id}");

            if (messageText.Equals("/start", StringComparison.OrdinalIgnoreCase))
            {
                await HandleStart(botClient, message, cancellationToken);
                return;
            }
        }
    }

    private async Task HandleStart(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        await botClient.SendMessage(
            chatId: message.Chat.Id,
            text: "🏠 Welcome! Here is the main menu:",
            replyMarkup: Keyboard.MainMenu(),
            cancellationToken: cancellationToken);
    }


    private async Task HandleCallbackQueryAsync(ITelegramBotClient botClient,
                                                CallbackQuery callbackQuery,
                                                CancellationToken cancellationToken)
    {
        var data = callbackQuery.Data;

        _logger.LogInformation("Got callback: {Data} from {UserId}", data, callbackQuery.From.Id);

        if (_menuService.Exists(data))
        {
            var menu = _menuService.GetMenu(data);

            await botClient.EditMessageText(
                chatId: callbackQuery.Message.Chat.Id,
                messageId: callbackQuery.Message.MessageId,
                text: menu.Text,
                replyMarkup: menu.Keyboard(),
                cancellationToken: cancellationToken);
        }
        else
        {
            await botClient.AnswerCallbackQuery(
                callbackQueryId: callbackQuery.Id,
                text: "❌ Unknown action.",
                showAlert: false,
                cancellationToken: cancellationToken);
        }
    }
}