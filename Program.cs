using System;

namespace MenuHierarchyApp
{
    class Program
    {
        static void Main()
        {
            using (var context = new ApplicationContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

           
                var fileMenu = new MenuItem { Name = "File" };
                var openMenu = new MenuItem { Name = "Open", Parent = fileMenu };
                var saveMenu = new MenuItem { Name = "Save", Parent = fileMenu };
                var saveAsMenu = new MenuItem { Name = "Save As", Parent = fileMenu };
                var toHardDrive = new MenuItem { Name = "To hard-drive..", Parent = saveAsMenu };
                var toOnlineDrive = new MenuItem { Name = "To online-drive..", Parent = saveAsMenu };

                var editMenu = new MenuItem { Name = "Edit" };
                var viewMenu = new MenuItem { Name = "View" };

             
                context.MenuItems.AddRange(fileMenu, openMenu, saveMenu, saveAsMenu, toHardDrive, toOnlineDrive, editMenu, viewMenu);
                context.SaveChanges();

                var service = new MenuService(context);
                service.PrintMenuHierarchy();

            }
        }
    }
}
