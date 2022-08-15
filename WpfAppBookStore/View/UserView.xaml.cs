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
using WpfAppBookStore.Auth;
using WpfAppBookStore.Commands;

namespace WpfAppBookStore.View
{
    /// <summary>
    /// Логика взаимодействия для UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView()
        {
            InitializeComponent();
            CommandBinding commandBinding1 = new CommandBinding();
            commandBinding1.Command = WindowCommands.SaveUser;
            commandBinding1.Executed += SaveUser_Executed;
            btnSaveUser.CommandBindings.Add(commandBinding1);
            CommandBinding commandBinding2 = new CommandBinding();
            commandBinding2.Command= WindowCommands.CancleUser;
            commandBinding2.Executed+= CancleUser_Executed;
        }

        private void CancleUser_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        public User user = new User();
        private void SaveUser_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            { 
                if(MainWindow.dB.users!=null)
                {
                  foreach (var item in MainWindow.dB.users)
                    {
                      if(item.Login==txtName.Text)
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                            return;
                        }
                    }
                }
                if(txtName.Text.Length == 0 || pswPass.Password.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            if (pswPass.Password.Length < 4)
            {
                MessageBox.Show("Длина пароля должна быть не менее 4-х символов");
            }
            if (pswPassControl.Password != pswPass.Password)
            {
                MessageBox.Show("Введённые пароли не совпадают");
            }
            if (txtName.Text.Length!=0&& pswPass.Password.Length >= 4&& pswPassControl.Password == pswPass.Password)
            {
                user.Login = txtName.Text;
                user.Password = pswPass.Password;
                MainWindow.dB.users.Add(user);
                MainWindow.dB.SaveChanges();
                    this.Close();
            }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.dB.users!=null)
            {
                foreach(var item in MainWindow.dB.users)
                {
                    if (item.IsAdmin == true)
                        chbIsAdmin.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
