using Arix.Infrastructure.Keyboards;
using Arix.Infrastructure.Menus.Interfaces;
using Arix.Infrastructure.Menus.Navigations;

namespace Arix.Infrastructure.Menus.Contributors;

public class SettingsMenuContributor : IMenuContributor
{
    public IEnumerable<MenuNode> GetMenuNodes()
    {
        yield return new MenuNode
        {
            Key = "settings",
            Text = "⚙️ Settings Menu:",
            Keyboard = Keyboard.SettingsMenu,
            ParentKey = "home"
        };
    }
}