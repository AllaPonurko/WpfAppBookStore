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
using WpfAppBookStore.Models;


namespace WpfAppBookStore
{
    /// <summary>
    /// Логика взаимодействия для Book.xaml
    /// </summary>
    public partial class BookView : Window
    {
        public BookView()
        {
            InitializeComponent();
            CommandBinding command1 = new CommandBinding();
            command1.Command = WindowCommands.SaveBook;
            command1.Executed += SaveBook_Executed;
            btnSave.CommandBindings.Add(command1);
        }
        public Book book=new Book();
        
        private void SaveBook_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if(txtAuthor.Text.Length != 0 ||txtName.Text.Length != 0|| txtGenre.Text.Length != 0
                || txtPrice.Text.Length != 0 || txtDate.Text.Length != 0)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            if(txtAuthor.Text.Length!=0&&txtName.Text.Length!=0&&txtGenre.Text.Length!=0
                &&txtPrice.Text.Length!=0&&txtDate.Text.Length!=0)
            {
                book.Title = txtName.Text;
                book.Author = txtAuthor.Text;
                //Genre = txtGenre.Text;
                book.Price = Convert.ToDouble(txtPrice.Text);
                book.dateTime = Convert.ToDateTime(txtDate);
            }
            MainWindow.dB.books.Add(book);
            MainWindow.dB.SaveChanges();
        }
    }
}
