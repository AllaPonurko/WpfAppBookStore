﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            //CommandBinding command1 = new CommandBinding();
            //command1.Command = WindowCommands.LoadListGenre;
            //command1.Executed += LoadListGenre_Executed;
            //btnLstGenre.CommandBindings.Add(command1);
            //CommandBinding command2 = new CommandBinding();
            //command2.Command = WindowCommands.LoadListBook;
            //command2.Executed += LoadListBook_Executed;
            //btnlstBook.CommandBindings.Add(command2);
            //CommandBinding command3 = new CommandBinding();
            //command3.Command = WindowCommands.AddGenre;
            //command3.Executed += AddGenre_Executed;
            //btnAddGenre.CommandBindings.Add(command3);
            //CommandBinding command4 = new CommandBinding();
            //command4.Command = WindowCommands.AddBook;
            //command4.Executed += AddBook_Executed;
            //btnAddBook.CommandBindings.Add(command4);
            //CommandBinding command5 = new CommandBinding();
            //command5.Command = WindowCommands.DelGenre;
            //command5.Executed += DelGenre_Executed;
            //btnDelGenre.CommandBindings.Add(command5);
            //CommandBinding command6 = new CommandBinding();
            //command6.Command = WindowCommands.DelBook;
            //command6.Executed += DelBook_Executed;
            //btnDelBook.CommandBindings.Add(command6);
        }
        private void EditBook_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                if (lstBook.Items == null)
                {
                    MessageBox.Show("Список книг пуст!");
                }
                if (lstBook.Items != null && lstBook.SelectedItem == null)
                {
                    MessageBox.Show("Не выбрана книга");
                }
                if (lstBook.Items != null && lstBook.SelectedItem != null)
                {
                    var editbook = (from book in MainWindow.dB.books
                                    where book.Title == lstBook.SelectedItem.ToString()
                                    select book).First();
                    var g = (from genre in MainWindow.dB.genres
                             where genre.Id == editbook.GenreId
                             select genre).First();
                    BookView bookEdit = new BookView();
                    bookEdit.Show();
                    bookEdit.txtGenre.Text = g.ToString();
                    bookEdit.txtGenre.IsReadOnly = true;
                    bookEdit.txtAuthor.Text = editbook.Author;
                    bookEdit.txtName.Text = editbook.Title;
                    bookEdit.txtPrice.Text = Convert.ToString(editbook.Price);
                    bookEdit.txtDate.Text = Convert.ToString(editbook.dateTime);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void EditGenre_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        /// <summary>
        /// удаление книги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelBook_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                if (lstBook.Items == null)
                {
                    MessageBox.Show("Список книг пуст!Нет данных для удаления");
                }
                if (lstBook.Items != null && lstBook.SelectedItem == null)
                {
                    MessageBox.Show(" Не выбрана книга!");
                }
                if (lstBook.Items != null && lstBook.SelectedItem != null)
                {
                    var b = (from book in MainWindow.dB.books
                             where book.Title == lstBook.SelectedItem.ToString()
                             select book).First();
                    var g = (from genre in MainWindow.dB.genres
                             where genre.Id == b.GenreId
                             select genre).First();
                    g.GetBooks.Remove(b);
                    lstBook.Items.Remove(lstBook.SelectedItem);
                    MainWindow.dB.books.Remove(b);
                    MainWindow.dB.SaveChanges();
                    MessageBox.Show("Книга удалена!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DelGenre_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                if (lstGenre.Items == null)
                {
                    MessageBox.Show("Список жанров пуст!Нет данных для удаления");
                }
                if (lstGenre.Items != null && lstGenre.SelectedItem == null)
                {
                    MessageBox.Show(" Не выбран жанр!");
                }
                if (lstGenre.Items != null && lstGenre.SelectedItem != null)
                {
                    var g = (from genre in MainWindow.dB.genres
                             where genre.Name == lstGenre.SelectedItem.ToString()
                             select genre).First();
                    if (g.GetBooks.Count == 0)
                    {
                        MainWindow.dB.genres.Remove(g);
                        MainWindow.dB.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Выбранный жанр содержит список книг. Сначала удалите все книги");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void AddBook_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                if (lstGenre.Items == null)
                {
                    MessageBox.Show("Список жанров пуст! Добавьте жанр");
                }
                if (lstGenre.Items != null && lstGenre.SelectedItem == null)
                {
                    MessageBox.Show(" Не выбран жанр!");
                }
                if (lstGenre.Items != null && lstGenre.SelectedItem != null)
                {
                    BookView book = new BookView();
                    book.Show();
                    book.txtGenre.Text = lstGenre.SelectedItem.ToString();
                    book.txtGenre.IsReadOnly = true;
                    book.txtDate.Text = DateTime.Now.ToShortDateString();
                }
            }
            catch (Exception ex)
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
            if (lstGenre.Items == null)
            {
                MessageBox.Show("Нет данных для показа");
            }
            if (lstGenre.Items != null && lstGenre.SelectedItem == null)
            {
                MessageBox.Show("Не выбран жанр");
            }
            if (lstGenre.Items != null && lstGenre.SelectedItem != null)
            {
                var g = (from genre in MainWindow.dB.genres
                         where genre.Name == lstGenre.SelectedItem.ToString()
                         select genre).First();
                var b = (from book in MainWindow.dB.books
                         where book.GenreId == g.Id
                         select book).ToList();
                foreach (var item in b)
                {
                    lstBook.Items.Add(item.Title);
                }

            }


        }

        private void LoadListGenre_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lstGenre.Items.Clear();
            if (MainWindow.dB.genres != null)
                foreach (var item in MainWindow.dB.genres)
                {
                    lstGenre.Items.Add(item.ToString());
                }
        }


    }
}
