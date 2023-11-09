using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjektHundekennel.Views
{
    /// <summary>
    /// Interaction logic for FrontPageView.xaml
    /// </summary>
    public partial class FrontPageView : UserControl, INotifyPropertyChanged
    {
        public FrontPageView()
        {
            InitializeComponent();
            LoadGrid();
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        private string _boundText;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string BoundText
        {
            get { return _boundText; }
            set
            {
                _boundText = value;
                OnPropertyChanged();
            }
        }

        public bool IsValid()
        {
            if (searchDog_txt.Text == string.Empty)
            {
                MessageBox.Show("Hundens id skal udfyldes", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LoadGrid()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string? ConnectionString = config.GetConnectionString("MyDBConnection");


            //using (SqlConnection con = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand cmd = new SqlCommand("select * from Dog", con);
            //    DataTable dt = new DataTable();
            //    con.Open();

            //    SqlDataReader sdr = cmd.ExecuteReader();
            //    dt.Load(sdr);
            //    con.Close();
            //    datagrid.ItemsSource = dt.DefaultView;
            //}
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from DogView", con);
                
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                await Task.Run (() => dt.Load(sdr));
            }
                datagrid.ItemsSource = dt.DefaultView;

        }
    }
        
}
