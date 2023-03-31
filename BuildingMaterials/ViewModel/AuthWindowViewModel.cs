using BuildingMaterials.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BuildingMaterials.ViewModel
{
    public class AuthWindowViewModel:BaseViewModel
    {
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public void Verificate()
        {
            if(_login == null||_password==null)
            {
                MessageBox.Show("Не все поля заполнены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            using(var db = new db9Entities())
            {
                var result = db.User.FirstOrDefault(user => user.UserLogin == _login && user.UserPassword == _password);
                if(result != null)
                {
                    MessageBox.Show("Авторизация прошла успешно!", "Сообщение",MessageBoxButton.OK, MessageBoxImage.Information);
                    var mainWind = new AdminWindow();
                    mainWind.Show();

                    foreach (Window wind in Application.Current.Windows)
                    {
                        if (wind is AuthWindow)
                        {
                            wind.Close();
                        }
                    }
                }
                else MessageBox.Show("Неверный логин или пароль", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AuthGuest()
        {
            var guestWind = new GuestWindow();
            guestWind.Show();

            foreach(Window wind in Application.Current.Windows)
            {
                if(wind is AuthWindow)
                {
                    wind.Close();
                }
            }
        }

      
        
    }
}
