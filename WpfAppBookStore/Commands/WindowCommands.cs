﻿using System.Windows.Input;
using WpfAppBookStore.View;

namespace WpfAppBookStore.Commands
{
    public class WindowCommands
    {   static WindowCommands()
        {
            SaveBook = new RoutedCommand("SaveBook", typeof(BookView));
            SaveUser=new RoutedCommand("SaveUser",typeof(UserView));
            Cancle = new RoutedCommand("Cancle", typeof(BookView));
            OpenUserView= new RoutedCommand("OpenUserView", typeof(MainWindow));
            SaveGenre = new RoutedCommand("SaveGenre", typeof(ViewWindow));
        }
        public static RoutedCommand SaveBook { get; set; }
        public static RoutedCommand SaveUser { get; set; }
        public static RoutedCommand Cancle { get; set; }
        public static RoutedCommand OpenUserView { get; set; }
        public static RoutedCommand SaveGenre { get; set; }
    }
}
