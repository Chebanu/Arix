using Telegram.Bot.Types;
using Telegram.Bot;

namespace Arix.Domain.TelegramHandler;

public interface ITelegramHandler
{
    Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
}