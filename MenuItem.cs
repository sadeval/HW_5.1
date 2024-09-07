using System.Collections.Generic;

namespace MenuHierarchyApp
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string? Name { get; set; }

        public int? ParentId { get; set; }
        public virtual MenuItem Parent { get; set; }

        public virtual ICollection<MenuItem> SubMenuItems { get; set; } = new List<MenuItem>();
    }
}
