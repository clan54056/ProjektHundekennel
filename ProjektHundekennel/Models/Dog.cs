using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing;

namespace ProjektHundekennel.Models
{
    public class Dog
    {

        List<Dog> dogs = new List<Dog>();

        public int DogId { get; set; }

        public string PedigreeId { get; set; }
        public string? Tato { get; set; }
        public string? Name { get; set; }
        public string? Breeder { get; set; }

        public string father; //henfører til pedigreeId ??
        public string mother;

        public string? DkkTitles { get; set; }
        public string? Titles { get; set; }

        public int? Count { get; set; }
        public DateTime? Born { get; set; }
        public char? Sex { get; set; }
        public string? Colour { get; set; }
        public bool? Dead { get; set; }
        public string? AK { get; set; }
        public bool? BreedingStatus { get; set; }
        public bool? MentalDescribed { get; set; }

        public byte? Image { get; set; }


        int ailments;//skal henføre til ailmentId?

        public void CreateDog(Dog dogToBeCreated)
        {
			IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

			string? ConnectionString = config.GetConnectionString("MyDBConnection");

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Dog (PedigreeId, Tato, Name, Breeder, Father, Mother, DKKTitles, Titles, Count, Born, Sex, Colour, Dead, AK, BreedingStatus, MentalDescribed, Image)" +

                    "VALUES(@PedigreeId, @Tato, @Name, @Breeder, @Father, @Mother, @DKKTitles, @Titles, @Count, @Born, @Sex, @Colour, @Dead, @AK, @BreedingStatus, @MentalDescribed, @Image)" +
                    "SELECT @@IDENTITY", con);

                cmd.Parameters.Add("@PedigreeId", SqlDbType.NVarChar).Value = dogToBeCreated.PedigreeId;



				cmd.Parameters.Add("@Tato", SqlDbType.NVarChar).Value = dogToBeCreated.Tato;


				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dogToBeCreated.Name;


				cmd.Parameters.Add("@Breeder", SqlDbType.NVarChar).Value = dogToBeCreated.Breeder;


					cmd.Parameters.Add("@Father", SqlDbType.NVarChar).Value = dogToBeCreated.father;


					cmd.Parameters.Add("@Mother", SqlDbType.NVarChar).Value = dogToBeCreated.mother;


					cmd.Parameters.Add("@DKKTitles", SqlDbType.NVarChar).Value = dogToBeCreated.DkkTitles;


					cmd.Parameters.Add("@Titles", SqlDbType.NVarChar).Value = dogToBeCreated.Titles; 


					cmd.Parameters.Add("@Count", SqlDbType.Int).Value = dogToBeCreated.Count;


					cmd.Parameters.Add("@Born", SqlDbType.DateTime2).Value = dogToBeCreated.Born;


					cmd.Parameters.Add("@Sex", SqlDbType.Char).Value = dogToBeCreated.Sex;


					cmd.Parameters.Add("@Colour", SqlDbType.NVarChar).Value = dogToBeCreated.Colour;


					cmd.Parameters.Add("@Dead", SqlDbType.Bit).Value = dogToBeCreated.Dead;


					cmd.Parameters.Add("@AK", SqlDbType.NVarChar).Value = dogToBeCreated.AK;


					cmd.Parameters.Add("@BreedingStatus", SqlDbType.Bit).Value = dogToBeCreated.BreedingStatus;


					cmd.Parameters.Add("@MentalDescribed", SqlDbType.Bit).Value = dogToBeCreated.MentalDescribed;


					cmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = dogToBeCreated.Image;

			}

		}

        public void ViewDog()
        {

        }

        public void UpdateDog()
        {

        }

        public void DeleteDog()
        {

        }

    }
}
