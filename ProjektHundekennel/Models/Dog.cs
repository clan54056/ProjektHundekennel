using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration.Json;

namespace ProjektHundekennel.Models
{
    public class Dog
    {
        int dogId; //primary key //hey //en ny kommentar

        public string pedigreeId { get; set; }
        public string tato { get; set; }
        public string name { get; set; }
        public string breeder { get; set; }

        public string father; //henfører til pedigreeId
        public string mother;

        public string dkkTitles { get; set; }
        public string titles { get; set; }

        public int count { get; set; }
        public DateTime birthDate { get; set; }
        public char sex { get; set; }
        public string colour { get; set; }
        public bool dead { get; set; }
        public string aK { get; set; }
        public bool breedingStatus { get; set; }
        public bool mentalDescribed { get; set; }
        //Image image;


        int ailments;//skal henføre til ailmentId?

        public void CreateDog(int dogId, string pedigreeId, string name, string father, string mother, DateTime birthDate)
        {
            this.dogId = dogId;
            this.pedigreeId = pedigreeId;
            this.father = father;
            this.mother = mother;
            this.birthDate = birthDate;
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
