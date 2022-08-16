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

namespace WpfAppBookStore.View
{
    /// <summary>
    /// Логика взаимодействия для GenreView.xaml
    /// </summary>
    public partial class GenreView : Window
    {
        public GenreView()
        {
            InitializeComponent();
            //CommandBinding command1 = new CommandBinding();
            //command1.Command = WindowCommands.SaveGenre;
            //command1.Executed += SaveGenre_Executed;
            //btnSave.CommandBindings.Add(command1);
            //CommandBinding command2 = new CommandBinding();
            //command2.Command = WindowCommands.CancleGenre;
            //command2.Executed += CancleGenre_Executed;
            //btnCancle.CommandBindings.Add(command2);
        }

        private void CancleGenre_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        public Genre genre = new Genre();
        private void SaveGenre_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (MainWindow.dB.genres != null)
            {
                if (txtName.Text.Length != 0)
                {
                    foreach (var item in MainWindow.dB.genres)
                    {
                        if (item.Name == txtName.Text)
                        {
                            MessageBox.Show("Такой жанр уже существует");
                            return;
                        }
                        
                    }
                            genre.Name = txtName.Text;
                            MainWindow.dB.genres.Add(genre);
                            MainWindow.dB.SaveChanges();
                       
                }

            }
            this.Close();
        }
    }
}
