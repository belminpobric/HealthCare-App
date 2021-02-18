using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Models
{
    public class Nalaz
    {
        public int ID { get; set; }
        public string NalazOpis { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public PacijentPrijem PacijentPrijem { get; set; }
        public int PacijentPrijemID { get; set; }
    }
}
