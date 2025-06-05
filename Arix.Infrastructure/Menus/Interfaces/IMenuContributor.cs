using Arix.Infrastructure.Menus.Navigations;

namespace Arix.Infrastructure.Menus.Interfaces;

public interface IMenuContributor
{
    IEnumerable<MenuNode> GetMenuNodes();
}
