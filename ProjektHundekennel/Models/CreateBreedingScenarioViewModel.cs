using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektHundekennel.Models
{
    public class CreateBreedingScenarioViewModel
    {
      public string pedigree_id1 { get; set; }
      public string dog_name1 { get; set; }
      public string colour1 { get; set; }
    public string mother_id1 { get; set; }
    public string mother_name1 { get; set; }
    public string mother_colour { get; set; }
        public string father_id1 { get; set; }
    public string father_name1 { get; set; }
    public string father_colour { get; set; }
    public string grandmother_m_id1 { get; set; }
    public string grandmother_m_name1 { get; set; }
    public string grandmother_m_colour { get; set; }
    public string grandfather_m_id1 { get; set; }
    public string grandfather_m_name1 { get; set; }
    public string grandfather_m_colour { get; set; }
    
    }
}
