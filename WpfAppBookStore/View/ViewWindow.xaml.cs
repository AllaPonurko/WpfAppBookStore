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
            if(lstGenre.Items==null)
            {
                MessageBox.Show("Список жанров пуст! Добавьте жанр");
            }
            if(lstGenre.Items != null&& lstGenre.SelectedItems==null)
            {
                MessageBox.Show(" Не выбран жанр!");
            }
            if(lstGenre.Items != null && lstGenre.SelectedItems != null)
            {
                BookView book = new BookView();
                book.Show();
                //book.txtGenre.Text = lstGenre.SelectedItem.ToString();
                //var g = (from genre in MainWindow.dB.genres
                //         where lstGenre.SelectedItem.ToString() == genre.Tostring()
                //         select genre).First();
                foreach(var item in MainWindow.dB.genres)
                {
                    if(item.Name== lstGenre.SelectedItem.ToString())
                    {
                        item.GetBooks.Add(book.book);
                    }
                }
                MainWindow.dB.SaveChanges();
            }
        }

        private void AddGenre_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GenreView genre = new GenreView();
            genre.Show();
        }

        private void LoadListBook_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadListGenre_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (MainWindow.dB.genres !=null)
                foreach (var item in MainWindow.dB.genres)
                {
                    lstGenre.Items.Add(item.ToString());
                }
        }

        
    }
}
