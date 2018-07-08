using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Collections.ObjectModel;
using BalHesablayici.Models;

namespace BalHesablayici
{
    public partial class FirstGroup : PhoneApplicationPage
    {
        int a, a1, a2,
            b, b1, b2,
            c, c1, c2,
            d, d1,
            f, f1;

        public FirstGroup()
        {
            InitializeComponent();

            
        }

        public int RezultatZakritix(int prav,int neprav)
        {
            if (prav == 0)
            {
                return 0;
            }
            else if (prav * 4 - neprav <= 0)
            {
                return 0;
            }
            else
            {
                return prav * 4 - neprav;
            }
        }

        public int RezultatOtkritix(int prav, int neprav,int otkritie)
        {
            if (prav == 0)
            {
                return 0;
            }
            else if ((prav+otkritie) * 4 - neprav <= 0)
            {
                return 0;
            }
            else
            {
                return (prav+otkritie) * 4 - neprav;
            }
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (riy1.Text == "" || riy2.Text == "" || riy3.Text == "" || fiz1.Text == "" || fiz2.Text == "" || fiz3.Text == "" || xim1.Text == "" || xim2.Text == "" || xim3.Text == "" || rus1.Text == "" || rus2.Text == "" || eng1.Text == "" || eng2.Text == "")
            {
                MessageBox.Show("Bütün informasiyanı daxil edin");
                return;
            }

            a = Convert.ToInt32(riy1.Text);
            a1 = Convert.ToInt32(riy2.Text);
            a2 = Convert.ToInt32(riy3.Text);
            b = Convert.ToInt32(fiz1.Text);
            b1 = Convert.ToInt32(fiz2.Text);
            b2 = Convert.ToInt32(fiz3.Text);
            c = Convert.ToInt32(xim1.Text);
            c1 = Convert.ToInt32(xim2.Text);
            c2 = Convert.ToInt32(xim3.Text);
            d = Convert.ToInt32(rus1.Text);
            d1 = Convert.ToInt32(rus2.Text);
            f = Convert.ToInt32(eng1.Text);
            f1 = Convert.ToInt32(eng2.Text);

            if (a + a1 + a2 > 25 || b + b1 + b2 > 25 || c + c1 + c2 > 25 || d + d1 > 25 || f + f1 > 25)
            {
                MessageBox.Show("Informasiya səhv daxil olunub");
                return;
            }

            result.Text = (RezultatOtkritix(a, a1, a2)*2 + RezultatOtkritix(b, b1, b2)*2 + RezultatOtkritix(c, c1, c2) + RezultatZakritix(d, d1) + RezultatZakritix(f, f1)).ToString();
            nisb_Riy.Text = RezultatOtkritix(a, a1, a2).ToString();
            nisb_Fiz.Text = RezultatOtkritix(b, b1, b2).ToString();
            nisb_Kim.Text = RezultatOtkritix(c, c1, c2).ToString();
            nisb_Rus.Text = RezultatZakritix(d, d1).ToString();
            nisb_Angl.Text = RezultatZakritix(f, f1).ToString();

            ObservableCollection<LineData> LineDataCollection = new ObservableCollection<LineData>()
            {
                new LineData { Category = "E1", Line1 = RezultatOtkritix(a, a1, a2)*2},
                new LineData { Category = "E2", Line1 = RezultatOtkritix(b, b1, b2)*2},
                new LineData { Category = "E3", Line1 = RezultatOtkritix(c, c1, c2)},
                new LineData { Category = "E4", Line1 = RezultatZakritix(d, d1)},
                new LineData { Category = "E5", Line1 = RezultatZakritix(f, f1)}
            };
            MixedChart.DataSource = LineDataCollection;
            second.IsEnabled = true;
        }
        private void again_Click(object sender, RoutedEventArgs e)
        {
            riy1.Text = "";
            riy2.Text = "";
            riy3.Text = "";
            fiz1.Text = "";
            fiz2.Text = "";
            fiz3.Text = "";
            xim1.Text = "";
            xim2.Text = "";
            xim3.Text = "";
            rus1.Text = "";
            rus2.Text = "";
            eng1.Text = "";
            eng2.Text = "";
        }
        private void EnterBoxToFour(object sender, TextChangedEventArgs e)
        {
            int tt = 0;
            TextBox tb = (TextBox)sender;
            try
            {
                tt = Convert.ToInt32(tb.Text);
            }
            catch { }

            if (tt > 4)
            {
                tb.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                tb.Background = new SolidColorBrush(Colors.White);
            }
        }
        private void EnterBoxToTwentyOne(object sender, TextChangedEventArgs e)
        {
            int tt = 0;
            TextBox tb = (TextBox)sender;
            try
            {
                tt = Convert.ToInt32(tb.Text);
            }
            catch { }

            if (tt > 21)
            {
                tb.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                tb.Background = new SolidColorBrush(Colors.White);
            }
        }
        private void EnterBoxToTwentyFive(object sender, TextChangedEventArgs e)
        {
            int tt = 0;
            TextBox tb = (TextBox)sender;
            try
            {
                tt = Convert.ToInt32(tb.Text);
            }
            catch { }

            if (tt > 25)
            {
                tb.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                tb.Background = new SolidColorBrush(Colors.White);
            }
        }

    }
}