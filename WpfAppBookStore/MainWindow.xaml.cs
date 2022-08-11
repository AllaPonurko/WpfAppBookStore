using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppBookStore.Commands;
using WpfAppBookStore.View;

namespace WpfAppBookStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public DB_BookStore.DB_BookStore dB = new DB_BookStore.DB_BookStore();
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding command = new CommandBinding();
            command.Command = WindowCommands.OpenUserView;
            command.Executed += OpenUserView_Executed;
            btnRegistr.CommandBindings.Add(command);
        }

        private void OpenUserView_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UserView user = new UserView();
            user.Show();
        }
    }
}
