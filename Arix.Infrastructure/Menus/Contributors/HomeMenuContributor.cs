using Arix.Infrastructure.Keyboards;
using Arix.Infrastructure.Menus.Interfaces;
using Arix.Infrastructure.Menus.Navigations;

namespace Arix.Infrastructure.Menus.Contributors;

public class HomeMenuContributor : IMenuContributor
{
    public IEnumerable<MenuNode> GetMenuNodes()
    {
        yield return new MenuNode
        {
            Key = "home",
            Text = "🏠 Home Menu:",
            Keyboard = Keyboard.HomeMenu,
            ParentKey = "main_menu"
        };

        yield return new MenuNode
        {
            Key = "create_bot",
            Text = "🤖 Create Bot Menu:",
            Keyboard = Keyboard.CreateBotMenu,
            ParentKey = "home"
        };
    }
}