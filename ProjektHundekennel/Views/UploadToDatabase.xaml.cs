using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
namespace ProjektHundekennel.Views
{
	/// <summary>
	/// Interaction logic for UploadToDatabase.xaml
	/// </summary>
	public partial class UploadToDatabase : Window
	{
		public UploadToDatabase() { 
		
			InitializeComponent();
		}
		public void HandleUploadToDatabase(object sender, RoutedEventArgs e)
		{
            OpenFileDialog dlg = new OpenFileDialog();
            bool? response = dlg.ShowDialog();

            if (response == true)
            {
                string filepath = dlg.FileName;
                destination.Items.Add(filepath);
            }
            MessageBox.Show("Success!\n\nFile uploaded.");
        }
	}
}
