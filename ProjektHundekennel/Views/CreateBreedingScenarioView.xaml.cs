using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjektHundekennel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektHundekennel.Views
{
    /// <summary>
    /// Interaction logic for CreateBreedingScenarioView.xaml
    /// </summary>
    public partial class CreateBreedingScenarioView : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<ProjektHundekennel.Models.CreateBreedingScenarioViewModel> breedingScenarioDog1;
        private ObservableCollection<ProjektHundekennel.Models.CreateBreedingScenarioViewModel2> breedingScenarioDog2;

        //public ObservableCollection<CreateBreedingScenarioViewModel> ResultCollection
        //{
        //    get { return _resultCollection; }
        //    set
        //    {
        //        if (_resultCollection != value)
        //        {
        //            _resultCollection = value;
        //            OnPropertyChanged(nameof(ResultCollection));
        //        }
        //    }
        //}


        private string connectionString = "";
        public CreateBreedingScenarioView()
        {
            InitializeComponent();

            DataContext = this;

            breedingScenarioDog1 = new ObservableCollection<CreateBreedingScenarioViewModel>();
            Datagrid1.DataContext = breedingScenarioDog1;

            breedingScenarioDog2 = new ObservableCollection<CreateBreedingScenarioViewModel2>();
            Datagrid2.DataContext = breedingScenarioDog2;

            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = config.GetConnectionString("MyDBConnection")!;
        }

     
        
        
        
        private string _breedingScenarioDog1;
        private string _breedingScenarioDog2;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string BreedingScenarioDog1
        {
            get { return _breedingScenarioDog1; }
            set
            {
                if (_breedingScenarioDog1 != value)
                {
                    _breedingScenarioDog1 = value;
                    OnPropertyChanged(nameof(BreedingScenarioDog1));
                }
            }
        }

        public string BreedingScenarioDog2
        {
            get { return _breedingScenarioDog2; }
            set
            {
                if (_breedingScenarioDog2 != value)
                {
                    _breedingScenarioDog2 = value;
                    OnPropertyChanged(nameof(BreedingScenarioDog2));
                }
            }
        }


        protected virtual void OnPropertyChanged(string _resultCollection)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_resultCollection));
        }

        private string _pedigreeId1;
        public string pedigreeId1
        {
            get { return _pedigreeId1; }
            set
            {
                if (_pedigreeId1 != value)
                {
                    _pedigreeId1 = value;
                    OnPropertyChanged(nameof(pedigreeId1));
                }
            }
        }

        private string GetNullableString(SqlDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? null! : reader.GetString(reader.GetOrdinal(columnName))!;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pedigreeId1 = pedigreeId1TextBox.Text;
            string pedigreeId2 = pedigreeId2TextBox.Text;

            try
            {
                IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                string? ConnectionString = config.GetConnectionString("MyDBConnection");

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM [BREEDING_SCENARIO_VIEW] WHERE pedigree_id1 = @PedigreeId1 AND pedigree_id2 = @PedigreeId2";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PedigreeId1", pedigreeId1);
                        command.Parameters.AddWithValue("@PedigreeId2", pedigreeId2);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            breedingScenarioDog1.Clear(); // Clear existing data
                            breedingScenarioDog2.Clear();

                            while (reader.Read())
                            {
                                // Create DogViewModel and add to the collection
                                breedingScenarioDog1.Add(new ProjektHundekennel.Models.CreateBreedingScenarioViewModel
                                {
                                    pedigree_id1 = GetNullableString(reader, "pedigree_id1"),
                                    dog_name1 = GetNullableString(reader, "dog_name1"),
                                    mother_id1 = GetNullableString(reader, "mother_id1"),
                                    mother_name1 = GetNullableString(reader, "mother_name1"),
                                    father_id1 = GetNullableString(reader, "father_id1"),
                                    father_name1 = GetNullableString(reader, "father_name1"),
                                    grandmother_m_id1 = GetNullableString(reader, "grandmother_m_id1"),
                                    grandmother_m_name1 = GetNullableString(reader, "grandmother_m_name1"),
                                    grandfather_m_id1 = GetNullableString(reader, "grandfather_m_id1"),
                                    grandfather_m_name1 = GetNullableString(reader, "grandfather_m_name1"),
                                });
                                breedingScenarioDog2.Add(new ProjektHundekennel.Models.CreateBreedingScenarioViewModel2
                                { 
                                    pedigree_id2 = GetNullableString(reader, "pedigree_id2"),
                                    dog_name2 = GetNullableString(reader, "dog_name2"),
                                    mother_id2 = GetNullableString(reader, "mother_id2"),
                                    mother_name2 = GetNullableString(reader, "mother_name2"),
                                    father_id2 = GetNullableString(reader, "father_id2"),
                                    father_name2 = GetNullableString(reader, "father_name2"),
                                    grandmother_m_id2 = GetNullableString(reader, "grandmother_m_id2"),
                                    grandmother_m_name2 = GetNullableString(reader, "grandmother_m_name2"),
                                    grandfather_m_id2 = GetNullableString(reader, "grandfather_m_id2"),
                                    grandfather_m_name2 = GetNullableString(reader, "grandfather_m_name2"),
                                });

                                OnPropertyChanged(nameof(BreedingScenarioDog1));
                                OnPropertyChanged(nameof(BreedingScenarioDog2));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
