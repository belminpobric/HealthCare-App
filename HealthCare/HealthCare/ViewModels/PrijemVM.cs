using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.ViewModels
{
    public class PrijemVM
    {
        [DataType(DataType.Date)]
        public DateTime? DatumOD { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DatumDO { get; set; }

        public List<Row> Rows { get; set; }
        public class Row
        {
            public string ImePrezimePacijent { get; set; }
            public DateTime DatumVrijemePrijema { get; set; }
            public string ImePrezimeLjekar { get; set; }
            public bool IsHitno { get; set; }
            public bool IsOtkazano { get; set; }
            public int ID { get; set; }
            public int NalazID { get; set; }
            public string NalazOpis { get; set; }
        }
    }
}
