using Telegram.Bot.Types.ReplyMarkups;

namespace Arix.Bot.Keyboard;

public static partial class Keyboard
{
    public static InlineKeyboardMarkup BalanceMenu()
    {
        return new InlineKeyboardMarkup(new[]
        {
        new[]
        {
            InlineKeyboardButton.WithCallbackData("🔙 Back to Main", "main_menu")
        }
    });
    }
}