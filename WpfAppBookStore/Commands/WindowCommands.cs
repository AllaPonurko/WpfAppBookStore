using System.Windows.Input;
using WpfAppBookStore.View;

namespace WpfAppBookStore.Commands
{
    public class WindowCommands
    {   static WindowCommands()
        {
            SaveBook = new RoutedCommand("SaveBook", typeof(BookView));
            SaveUser=new RoutedCommand("SaveUser",typeof(UserView));
        }
        public static RoutedCommand SaveBook { get; set; }
        public static RoutedCommand SaveUser { get; set; }
    }
}
