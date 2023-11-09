using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektHundekennel.Models
{
    public class Dog
    {
        int dogId; //primary key //hey

        string pedigreeId { get; set; }
        string tato { get; set; }
        string name { get; set; }
        string breeder { get; set; }

        string father; //henfører til pedigreeId
        string mother;

        string dkkTitles { get; set; }
        string titles { get; set; }

        int count { get; set; }
        DateTime birthDate { get; set; }
        char sex { get; set; }
        string colour { get; set; }
        bool dead { get; set; }
        string aK { get; set; }
        bool breedingStatus { get; set; }
        bool mentalDescribed { get; set; }
        //Image image;


        int ailments;//skal henføre til ailmentId?

        // Udkommenteret af Casper da den mangler retur type

        //public CreateDog(int dogId, string pedigreeId, string name, string father, string mother, DateTime birthDate)
        //{
        //    this.dogId = dogId;
        //    this.pedigreeId = pedigreeId;
        //    this.father = father;
        //    this.mother = mother;
        //    this.birthDate = birthDate;
        //}

        //public void ViewDog()
        //{

        //}

        //public void UpdateDog()
        //{

        //}

        //public void DeleteDog()
        //{

        //}

    }
}
