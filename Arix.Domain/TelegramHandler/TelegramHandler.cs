using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot;
using Arix.Bot.Keyboard;

namespace Arix.Domain.TelegramHandler;

public class TelegramHandler : ITelegramHandler
{
    private readonly ILogger<ITelegramHandler> _logger;

    public TelegramHandler(ILogger<ITelegramHandler> logger)
    {
        _logger = logger;
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


    private async Task HandleCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery callbackQuery, CancellationToken cancellationToken)
    {
        var data = callbackQuery.Data;

        _logger.LogInformation($"Got callback: {data} from {callbackQuery.From.Id}");

        var actions = new Dictionary<string, Func<Task>>(StringComparer.OrdinalIgnoreCase)
        {
            ["home"] = () => botClient.EditMessageText(
                chatId: callbackQuery.Message.Chat.Id,
                messageId: callbackQuery.Message.MessageId,
                text: "🏠 Home Menu:",
                replyMarkup: Keyboard.HomeMenu(),
                cancellationToken: cancellationToken),

            ["create_bot"] = () => botClient.EditMessageText(
                chatId: callbackQuery.Message.Chat.Id,
                messageId: callbackQuery.Message.MessageId,
                text: "🤖 Create Bot Menu:",
                replyMarkup: Keyboard.CreateBotMenu(),
                cancellationToken: cancellationToken),

            ["main_menu"] = () => botClient.EditMessageText(
                chatId: callbackQuery.Message.Chat.Id,
                messageId: callbackQuery.Message.MessageId,
                text: "🏠 Main Menu:",
                replyMarkup: Keyboard.MainMenu(),
                cancellationToken: cancellationToken),

            ["settings"] = () => botClient.EditMessageText(
                chatId: callbackQuery.Message.Chat.Id,
                messageId: callbackQuery.Message.MessageId,
                text: "⚙️ Settings Menu:",
                replyMarkup: Keyboard.SettingsMenu(),
                cancellationToken: cancellationToken),

            ["balance"] = () => botClient.EditMessageText(
                chatId: callbackQuery.Message.Chat.Id,
                messageId: callbackQuery.Message.MessageId,
                text: "💰 Balance Menu:",
                replyMarkup: Keyboard.BalanceMenu(),
                cancellationToken: cancellationToken),

            ["deals"] = () => botClient.EditMessageText(
                chatId: callbackQuery.Message.Chat.Id,
                messageId: callbackQuery.Message.MessageId,
                text: "📊 Deals Menu:",
                replyMarkup: Keyboard.DealsMenu(),
                cancellationToken: cancellationToken),
        };

        if (actions.TryGetValue(data, out var action))
        {
            await action();
        }
        else
        {
            await botClient.AnswerCallbackQuery(
                callbackQueryId: callbackQuery.Id,
                text: "Unknown action.",
                showAlert: false,
                cancellationToken: cancellationToken);
        }
    }



    private async Task Home(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        await botClient.SendMessage(
            chatId: message.Chat.Id,
            text: "You pressed Button 1!",
            cancellationToken: cancellationToken);
    }

    private async Task Challenge(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        await botClient.SendMessage(
            chatId: message.Chat.Id,
            text: "You pressed Button 2!",
            cancellationToken: cancellationToken);
    }

    private async Task Settings(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        await botClient.SendMessage(
            chatId: message.Chat.Id,
            text: "You pressed Button 2!",
            cancellationToken: cancellationToken);
    }

    private async Task Deals(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        await botClient.SendMessage(
            chatId: message.Chat.Id,
            text: "You pressed Button 2!",
            cancellationToken: cancellationToken);
    }

    private async Task Balance(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        await botClient.SendMessage(
            chatId: message.Chat.Id,
            text: "You pressed Button 2!",
            cancellationToken: cancellationToken);
    }

    private async Task HandleUnknown(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        await botClient.SendMessage(
            chatId: message.Chat.Id,
            text: "Unknown command!",
            cancellationToken: cancellationToken);
    }
}