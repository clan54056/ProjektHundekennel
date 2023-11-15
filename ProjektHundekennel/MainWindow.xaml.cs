using ProjektHundekennel.Views;
using System.Windows;

namespace ProjektHundekennel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.NavigationService.Navigate(new FrontPageView());
        }

    }
}
