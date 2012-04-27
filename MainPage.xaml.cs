using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PhysicsCS
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void FormulasButton_Click(object sender, RoutedEventArgs e)
        {
            /*** Debug Messages ***/
            System.Console.WriteLine("FormulasButton_Click");
            /*** End ***/

            NavigationService.Navigate(new Uri("/FormulasPivotPage.xaml", UriKind.Relative));
        }

        private void UnitsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/UnitsPivotPage.xaml", UriKind.Relative));
        }

        private void QuickReviewButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/QuickReviewPivotPage.xaml", UriKind.Relative));
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpPage.xaml", UriKind.Relative));
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }
    }
}