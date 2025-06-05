using Arix.Infrastructure.Keyboards;
using Arix.Infrastructure.Menus.Interfaces;
using Arix.Infrastructure.Menus.Navigations;

namespace Arix.Infrastructure.Menus.Contributors;

public class MainMenuContributor : IMenuContributor
{
    public IEnumerable<MenuNode> GetMenuNodes()
    {
        yield return new MenuNode
        {
            Key = "main_menu",
            Text = "📊 Deals Menu:",
            Keyboard = Keyboard.MainMenu,
            ParentKey = null
        };
    }
}