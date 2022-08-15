using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppBookStore.Commands;

namespace WpfAppBookStore.View
{
    /// <summary>
    /// Логика взаимодействия для GenreView.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {
        public ViewWindow()
        {
            InitializeComponent();
            CommandBinding command1 = new CommandBinding();
            command1.Command = WindowCommands.LoadListGenre;
            command1.Executed += LoadListGenre_Executed;
            btnLstGenre.CommandBindings.Add(command1);
            CommandBinding command2 = new CommandBinding();
            command2.Command = WindowCommands.LoadListBook;
            command2.Executed += LoadListBook_Executed;
            //Binding binding = new Binding();
            //binding.Source = MainWindow.dB.genres;
            //binding.Mode = BindingMode.TwoWay;
            //lstGenre.SetBinding(ListView.ItemsSourceProperty, binding);
        }

        private void LoadListBook_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadListGenre_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (MainWindow.dB.genres != null)
                foreach (var item in MainWindow.dB.genres)
                {
                    lstGenre.Items.Add(item.ToString());
                }
        }

        
    }
}
