using Arix.Infrastructure.Keyboards;
using Arix.Infrastructure.Menus.Interfaces;
using Arix.Infrastructure.Menus.Navigations;

namespace Arix.Infrastructure.Menus.Contributors;

public class DealsMenuContributor : IMenuContributor
{
    public IEnumerable<MenuNode> GetMenuNodes()
    {
        yield return new MenuNode
        {
            Key = "deals",
            Text = "📊 Deals Menu:",
            Keyboard = Keyboard.DealsMenu,
            ParentKey = "home"
        };
    }
}