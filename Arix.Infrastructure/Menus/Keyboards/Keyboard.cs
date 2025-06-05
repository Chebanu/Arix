using Telegram.Bot.Types.ReplyMarkups;

namespace Arix.Infrastructure.Keyboards;

public static partial class Keyboard
{
    public static InlineKeyboardMarkup MainMenu()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("🏠 Home", "home"),
                InlineKeyboardButton.WithCallbackData("⚙️ Settings", "settings")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("💰 Balance", "balance"),
                InlineKeyboardButton.WithCallbackData("📊 Deals", "deals")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("🔥 Challenge", "challenge")
            }
        });
    }
}