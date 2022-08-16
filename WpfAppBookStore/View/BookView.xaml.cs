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
using WpfAppBookStore.View;

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
            
            //CommandBinding command1 = new CommandBinding();
            //command1.Command = WindowCommands.SaveBook;
            //command1.Executed += SaveBook_Executed;
            //btnSave.CommandBindings.Add(command1);
            //CommandBinding command2 = new CommandBinding();
            //command2.Command = WindowCommands.Cancle;
            //command2.Executed += Cancle_Executed;
            //btnCancle.CommandBindings.Add(command2);
        }

        private void Cancle_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        public Book book = new Book();

        private void SaveBook_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                {
                    if (txtAuthor.Text.Length == 0 || txtName.Text.Length == 0 || 
                        txtPrice.Text.Length == 0)
                    {
                        MessageBox.Show("Не все поля заполнены");
                        return;
                    }
                    if (txtAuthor.Text.Length != 0 && txtName.Text.Length != 0
                        && txtPrice.Text.Length != 0)
                    {
                        book.Title = txtName.Text;
                        book.Author = txtAuthor.Text;
                        book.Price = Convert.ToDouble(txtPrice.Text);
                        
                        //var g = (from genre in MainWindow.dB.genres where genre.Name == txtGenre.Text select genre).First();
                        foreach(var item in MainWindow.dB.genres)
                        {
                            if(item.Name== txtGenre.Text.ToString())
                            {
                                item.GetBooks.Add(book);
                            }
                        }
                    }
                    
                }
                    MainWindow.dB.books.Add(book);
                    MainWindow.dB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
