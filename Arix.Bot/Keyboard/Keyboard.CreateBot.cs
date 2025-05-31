using Telegram.Bot.Types.ReplyMarkups;

namespace Arix.Bot.Keyboard;

public static partial class Keyboard
{
    public static InlineKeyboardMarkup CreateBotMenu()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("🔮 Futures Bot", "futures_bot"),
                InlineKeyboardButton.WithCallbackData("💹 Spot Bot", "spot_bot")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("🔙 Back to Home", "home")
            }
        });
    }
}