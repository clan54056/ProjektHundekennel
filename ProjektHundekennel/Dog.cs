using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjektHundekennel
{
	public class Dog
	{
		int dogId; //primary key
		string pedigreeId;
		string tato;
		string name;
		string breeder;
		string father; //henfører til pedigreeId
		string mother;
		string dkkTitles;
		string titles;
		DateTime lastVisit;
		int count;
		DateTime birthDate;
		char sex;
		string colour;
		int dead;
		string aK;
		int breedingStatus;
		int mentalDescribed;
		Image image;
		DateTime dateAdded;
		int ailments;//skal henføre til ailmentId?

		public CreateDog(int dogId, string pedigreeId, string father, string mother, DateTime birthDate)
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
