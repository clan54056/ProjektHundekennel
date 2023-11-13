using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektHundekennel.Views
{
    /// <summary>
    /// Lógica de interacción para PedigreeView.xaml
    /// </summary>
    public partial class PedigreeView : UserControl
    {
        private ObservableCollection<ProjektHundekennel.Models.PedigreeViewModel> familyTree;
        private string connectionString = "";
        public PedigreeView()
        {
            InitializeComponent();
            familyTree = new ObservableCollection<ProjektHundekennel.Models.PedigreeViewModel>();
            familyTreeDataGrid.ItemsSource = familyTree;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = config.GetConnectionString("MyDBConnection")!;
        }

        private string GetNullableString(SqlDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? null! : reader.GetString(reader.GetOrdinal(columnName))!;
        }

        private void HentTavleKnap(object sender, RoutedEventArgs e)
        {
            string pedigreeId = pedigreeIdTextBox.Text;

            try
            {
                IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                string? ConnectionString = config.GetConnectionString("MyDBConnection");

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM [PEDIGREEVIEW] WHERE pedigree_id = @PedigreeId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PedigreeId", pedigreeId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            familyTree.Clear(); // Clear existing data

                            while (reader.Read())
                            {
                                // Create DogViewModel and add to the collection
                                familyTree.Add(new ProjektHundekennel.Models.PedigreeViewModel
                                {
                                    pedigree_id = GetNullableString(reader, "pedigree_id"),
                                    dog_name = GetNullableString(reader, "dog_name"),
                                    mother_id = GetNullableString(reader, "mother_id"),
                                    mother_name = GetNullableString(reader, "mother_name"),
                                    father_id = GetNullableString(reader, "father_id"),
                                    father_name = GetNullableString(reader, "father_name"),
                                    grandmother_m_id = GetNullableString(reader, "grandmother_m_id"),
                                    grandmother_m_name = GetNullableString(reader, "grandmother_m_name"),
                                    grandfather_m_id = GetNullableString(reader, "grandfather_m_id"),
                                    grandfather_m_name = GetNullableString(reader, "grandfather_m_name"),
                                    great_grandmother_m_id = GetNullableString(reader, "great_grandmother_m_id"),
                                    great_grandmother_m_name = GetNullableString(reader, "great_grandmother_m_name"),
                                    great_grandfather_m_id = GetNullableString(reader, "great_grandfather_m_id"),
                                    great_grandfather_m_name = GetNullableString(reader, "great_grandfather_m_name"),
                                    grandmother_p_id = GetNullableString(reader, "grandmother_p_id"),
                                    grandmother_p_name = GetNullableString(reader, "grandmother_p_name"),
                                    grandfather_p_id = GetNullableString(reader, "grandfather_p_id"),
                                    grandfather_p_name = GetNullableString(reader, "grandfather_p_name"),
                                    great_grandmother_p_id = GetNullableString(reader, "great_grandmother_p_id"),
                                    great_grandmother_p_name = GetNullableString(reader, "great_grandmother_p_name"),
                                    great_grandfather_p_id = GetNullableString(reader, "great_grandfather_p_id"),
                                    great_grandfather_p_name = GetNullableString(reader, "great_grandfather_p_name"),
                                });
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
