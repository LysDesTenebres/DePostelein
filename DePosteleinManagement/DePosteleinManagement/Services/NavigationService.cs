using DePosteleinManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DePosteleinManagement.Services
{
    class NavigationService:INavigationService
    {
        public void NavigateTo(string key)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            switch (key)
            {
                case "MainView":
                    rootFrame.Navigate(typeof(MainView));
                    break;
                case "Login":
                    rootFrame.Navigate(typeof(LoginView));
                    break;
                case "Back":
                    rootFrame.GoBack();
                    break;
            }
            }
    }
}
