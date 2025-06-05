using Telegram.Bot.Types.ReplyMarkups;

namespace Arix.Infrastructure.Menus.Navigations;

public class MenuNode
{
    public string Key { get; init; }
    public string Text { get; init; }
    public Func<InlineKeyboardMarkup> Keyboard { get; init; }
    public string ParentKey { get; init; }
}
