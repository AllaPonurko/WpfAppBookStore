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
            btnlstBook.CommandBindings.Add(command2);
            CommandBinding command3 = new CommandBinding();
            command3.Command = WindowCommands.AddGenre;
            command3.Executed += AddGenre_Executed;
            btnAddGenre.CommandBindings.Add(command3);
            CommandBinding command4 = new CommandBinding();
            command4.Command = WindowCommands.AddBook;
            command4.Executed += AddBook_Executed;
            btnAddBook.CommandBindings.Add(command4);

        }

        private void AddBook_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            { 
                if(lstGenre.Items==null)
            {
                MessageBox.Show("Список жанров пуст! Добавьте жанр");
            }
            if(lstGenre.Items != null&& lstGenre.SelectedItem==null)
            {
                MessageBox.Show(" Не выбран жанр!");
            }
            if(lstGenre.Items != null && lstGenre.SelectedItem!= null)
            {
                BookView book = new BookView();
                book.Show();
                book.txtGenre.Text = lstGenre.SelectedItem.ToString();
                    book.txtDate.Text = Convert.ToString(DateTime.Now);
            }
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.Message); 
            }
            
        }

        private void AddGenre_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GenreView genre = new GenreView();
            genre.Show();
        }

        private void LoadListBook_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lstBook.Items.Clear();
           if(lstGenre.Items==null)
            {
                MessageBox.Show("Нет данных для показа");
            }
           if(lstGenre.Items != null&& lstGenre.SelectedItem==null)
            {
                MessageBox.Show("Не выбран жанр");
            }
           if(lstGenre.Items != null && lstGenre.SelectedItem != null)
            {foreach(var item in MainWindow.dB.genres)
                if(item.Name== lstGenre.SelectedItem.ToString())
                        foreach(var item1 in item.GetBooks)
                    {
                            lstBook.Items.Add(item1);
                    }
            }
        }

        private void LoadListGenre_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lstGenre.Items.Clear();
            if (MainWindow.dB.genres !=null)
                foreach (var item in MainWindow.dB.genres)
                {
                    lstGenre.Items.Add(item.ToString());
                }
        }

        
    }
}
