using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektHundekennel.Models
{
    internal class PedigreeViewModel
    {
        public string pedigree_id { get; set; }
        public string dog_name { get; set; }
        public string mother_id { get; set; }
        public string mother_name { get; set; }
        public string father_id { get; set; }
        public string father_name { get; set; }

        public string grandmother_m_id { get; set; }

        public string grandmother_m_name { get; set; }

        public string grandfather_m_id { get; set; }

        public string grandfather_m_name { get; set; }

        public string great_grandmother_m_id { get; set; }

        public string great_grandmother_m_name { get; set; }

        public string great_grandfather_m_id { get; set; }

        public string great_grandfather_m_name { get; set; }

        public string grandmother_p_id { get; set; }

        public string grandmother_p_name { get; set; }

        public string grandfather_p_id { get; set; }

        public string grandfather_p_name { get; set; }

        public string great_grandmother_p_id { get; set; }

        public string great_grandmother_p_name { get; set; }

        public string great_grandfather_p_id { get; set; }

        public string great_grandfather_p_name { get; set; }

    }
}
