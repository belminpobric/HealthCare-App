using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Models
{
    public class PacijentPrijem
    {
        public int Id { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public Pacijent Pacijent { get; set; }
        public int PacijentID { get; set; }
        public Ljekar Ljekar { get; set; }
        public int LjekarID { get; set; }
        public bool IsHitno { get; set; }
        public bool IsOtkazano { get; set; }
    }
}
