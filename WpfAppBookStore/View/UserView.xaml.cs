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
                        }
                    }
                }
                if(txtName.Text.Length == 0 || txtPass.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            if ( txtPass.Text.Length <4)
            {
                MessageBox.Show("Длина пароля должна быть не менее 4-х символов");
            }
            if (txtPassControl.Text != txtPass.Text)
            {
                MessageBox.Show("Введённые пароли не совпадают");
            }
            if (txtName.Text.Length!=0&&txtPass.Text.Length>=4&&txtPassControl.Text==txtPass.Text)
            {
                user.Login = txtName.Text;
                user.Password = txtPass.Text;
                MainWindow.dB.users.Add(user);
                MainWindow.dB.SaveChanges();
            }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
