using System.Windows.Input;


namespace WpfAppBookStore.Commands
{
    public class WindowCommands
    {   static WindowCommands()
        {
            SaveBook = new RoutedCommand("SaveBook", typeof(Book));
        }
        public static RoutedCommand SaveBook { get; set; }
    }
}
