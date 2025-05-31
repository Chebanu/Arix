using Telegram.Bot.Types.ReplyMarkups;

namespace Arix.Bot.Keyboard;

public static partial class Keyboard
{
    public static InlineKeyboardMarkup SettingsMenu()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("💳 Top Up", "top_up")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("🔔 Modify Notifications", "modify_notifications")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("🔙 Back to Main", "main_menu")
            }
        });
    }
}