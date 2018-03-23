using DePostelein.Views;
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
                case "CustomerOverview":
                    rootFrame.Navigate(typeof(CustomerOverviewView));
                    break;
                case "EventOverview":
                    rootFrame.Navigate(typeof(EventOverviewView));
                    break;
                case "NewDish":
                    rootFrame.Navigate(typeof(NewDishView));
                    break;
                case "NewEvent":
                    rootFrame.Navigate(typeof(NewEventView));
                    break;
                case "NewMenu":
                    rootFrame.Navigate(typeof(NewMenuView));
                    break;
                case "Staff":
                    rootFrame.Navigate(typeof(StaffView));
                    break;
                case "NewStaff":
                    rootFrame.Navigate(typeof(NewStaffView));
                    break;
                case "Deliverer":
                    rootFrame.Navigate(typeof(DelivererOverview));
                    break;
                case "NewDeliverer":
                    rootFrame.Navigate(typeof(NewDelivererView));
                    break;
                case "EditCustomer":
                    rootFrame.Navigate(typeof(EditCustomerView));
                    break;
                case "EditDeliverer":
                    rootFrame.Navigate(typeof(EditDelivererView));
                    break;
                case "EditEvent":
                    rootFrame.Navigate(typeof(EditEventView));
                    break;
                case "EditStaff":
                    rootFrame.Navigate(typeof(EditStaffView));
                    break;
                case "Back":
                    rootFrame.GoBack();
                    break;
            }
            }
    }
}
