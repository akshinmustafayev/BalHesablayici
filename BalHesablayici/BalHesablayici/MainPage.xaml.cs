using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BalHesablayici.Resources;
using System.Threading;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using Microsoft.Phone.Tasks;

namespace BalHesablayici
{
    public partial class MainPage : PhoneApplicationPage
    {
        BackgroundWorker backroungWorker;
        Popup myPopup;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            myPopup = new Popup() { IsOpen = true, Child = new AnimatedSplashScreen() };
            backroungWorker = new BackgroundWorker();
            RunBackgroundWorker();
        }

        private void RunBackgroundWorker()
        {
            backroungWorker.DoWork += ((s, args) =>
            {
                Thread.Sleep(4000);
            });

            backroungWorker.RunWorkerCompleted += ((s, args) =>
            {
                this.Dispatcher.BeginInvoke(() =>
                {
                    this.myPopup.IsOpen = false;
                }
            );
            });
            backroungWorker.RunWorkerAsync();
        }

        private void ChooseItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ChooseItemsList.SelectedIndex)
            {
                case 0:
                    NavigationService.Navigate(new Uri("/FirstGroup.xaml", UriKind.RelativeOrAbsolute));
                    ChooseItemsList.SelectedIndex = -1;
                    break;
                case 1:
                    NavigationService.Navigate(new Uri("/SecondGroup.xaml", UriKind.RelativeOrAbsolute));
                    ChooseItemsList.SelectedIndex = -1;
                    break;
                case 2:
                    NavigationService.Navigate(new Uri("/ThirdGroup.xaml", UriKind.RelativeOrAbsolute));
                    ChooseItemsList.SelectedIndex = -1;
                    break;
                case 3:
                    NavigationService.Navigate(new Uri("/FourthGroup.xaml", UriKind.RelativeOrAbsolute));
                    ChooseItemsList.SelectedIndex = -1;
                    break;
                case 4:
                    NavigationService.Navigate(new Uri("/RssPage.xaml", UriKind.RelativeOrAbsolute));
                    ChooseItemsList.SelectedIndex = -1;
                    break;
                case 5:
                    NavigationService.Navigate(new Uri("/AboutProgram.xaml", UriKind.RelativeOrAbsolute));
                    ChooseItemsList.SelectedIndex = -1;
                    break;
                case 6:
                    WebBrowserTask task = new WebBrowserTask();
                    task.Uri = new Uri("https://www.facebook.com/pages/Avin/784652694930955");
                    task.Show();
                    break;
                case 7:
                    MarketplaceReviewTask marketplace = new MarketplaceReviewTask();
                    marketplace.Show();
                    break;
            }
        }

    }
}