using Telegram.Bot.Types.ReplyMarkups;

namespace Arix.Bot.Keyboard;

public static partial class Keyboard
{
    public static InlineKeyboardMarkup HomeMenu()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("🤖 Create Bot", "create_bot")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("🔙 Back to Main", "main_menu")
            }
        });
    }
}