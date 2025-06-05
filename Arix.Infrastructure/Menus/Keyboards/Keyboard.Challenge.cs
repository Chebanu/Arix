using Telegram.Bot.Types.ReplyMarkups;

namespace Arix.Infrastructure.Keyboards;

public static partial class Keyboard
{
    public static InlineKeyboardMarkup Challenge()
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
