using System.Windows.Input;


namespace WpfAppBookStore.Commands
{
    public class WindowCommands
    {   static WindowCommands()
        {
            SaveBook = new RoutedCommand("SaveBook", typeof(BookView));
        }
        public static RoutedCommand SaveBook { get; set; }
    }
}
