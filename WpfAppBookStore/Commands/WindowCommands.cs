using System.Windows.Input;
using WpfAppBookStore.View;

namespace WpfAppBookStore.Commands
{
    public class WindowCommands
    {   static WindowCommands()
        {
            SaveBook = new RoutedCommand("SaveBook", typeof(BookView));
            Cancle = new RoutedCommand("Cancle", typeof(BookView));
            
            SaveGenre = new RoutedCommand("SaveGenre", typeof(ViewWindow));
            CancleGenre = new RoutedCommand("CancleGenre", typeof(ViewWindow));
            SaveUser=new RoutedCommand("SaveUser",typeof(UserView));
            CancleUser = new RoutedCommand("CancleUser", typeof(UserView));
            UserEnter = new RoutedCommand("UserEnter", typeof(MainWindow));
            OpenUserView= new RoutedCommand("OpenUserView", typeof(MainWindow));
        }
        public static RoutedCommand SaveBook { get; set; }
        public static RoutedCommand SaveUser { get; set; }
        public static RoutedCommand Cancle { get; set; }
        public static RoutedCommand OpenUserView { get; set; }
        public static RoutedCommand SaveGenre { get; set; }
        public static RoutedCommand CancleUser { get; set; }
        public static RoutedCommand UserEnter{ get; set; }
        public static RoutedCommand CancleGenre { get; set; }
    }
}
