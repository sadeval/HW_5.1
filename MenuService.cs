using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MenuHierarchyApp
{
    public class MenuService
    {
        private readonly ApplicationContext _context;

        public MenuService(ApplicationContext context)
        {
            _context = context;
        }

        public void PrintMenuHierarchy()
        {
            var menuItems = _context.MenuItems
                .Where(m => m.ParentId == null)
                .Include(m => m.SubMenuItems)
                    .ThenInclude(sm => sm.SubMenuItems)
                .ToList();

            foreach (var menuItem in menuItems)
            {
                PrintMenuItem(menuItem, 0);
            }
        }

        private void PrintMenuItem(MenuItem item, int level)
        {
            Console.WriteLine(new string('-', level * 2) + item.Name);

            foreach (var subItem in item.SubMenuItems)
            {
                PrintMenuItem(subItem, level + 1);
            }
        }
    }
}
