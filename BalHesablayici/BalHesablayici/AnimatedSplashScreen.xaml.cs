using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Animation;

namespace BalHesablayici
{
    public partial class AnimatedSplashScreen : PhoneApplicationPage
    {
        public AnimatedSplashScreen()
        {
            InitializeComponent();
            Storyboard flippingAnimation = this.Resources["MainAnimation"] as Storyboard;
            flippingAnimation.Begin();
        }
    }
}