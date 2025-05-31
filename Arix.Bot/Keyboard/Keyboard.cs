using Telegram.Bot.Types.ReplyMarkups;

namespace Arix.Bot.Keyboard;

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