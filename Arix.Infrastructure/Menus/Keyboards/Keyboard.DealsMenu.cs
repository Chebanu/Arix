using Telegram.Bot.Types.ReplyMarkups;

namespace Arix.Infrastructure.Keyboards;

public static partial class Keyboard
{
    public static InlineKeyboardMarkup DealsMenu()
    {
        return new InlineKeyboardMarkup(new[]
        {
        new[]
        {
            InlineKeyboardButton.WithCallbackData("📈 Active Deals", "active_deals"),
            InlineKeyboardButton.WithCallbackData("📊 Statistics", "statistics")
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData("🧪 Backtest", "backtest")
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData("🔙 Back to Main", "main_menu")
        }
    });
    }
}