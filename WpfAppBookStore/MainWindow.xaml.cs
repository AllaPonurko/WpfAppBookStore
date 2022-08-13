﻿using System;
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
            CommandBinding command1 = new CommandBinding();
            command1.Command = WindowCommands.UserEnter;
            command1.Executed+= UserEnter_Executed;
            btnEnter.CommandBindings.Add(command1);
        }

        private void UserEnter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if(dB.users!=null)
            {
                if (txtLogin.Text.Length != 0 && pswPass.Password.Length != 0)
                {
                    foreach (var item in dB.users)
                    {
                        if (item.Login == txtLogin.Text && item.Password == pswPass.Password)
                        {
                            ViewWindow viewWindow = new ViewWindow();
                            viewWindow.Show();
                        }
                        if (item.Login != txtLogin.Text || item.Password != pswPass.Password)
                        {
                            MessageBox.Show("Неверный логин или пароль");
                            return;
                        }
                    }
                }
                if(txtLogin.Text.Length == 0 || pswPass.Password.Length == 0)
                {
                    MessageBox.Show("Не заполнены поля логин или пароль");
                    return;
                }
            }
        }

        private void OpenUserView_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UserView user = new UserView();
            user.Show();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            txtLogin.IsEnabled = true;
            pswPass.IsEnabled = true;
        }
    }
}
