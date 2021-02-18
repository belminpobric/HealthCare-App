using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Models
{
    public class Pacijent
    {
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]

        public Spol Spol { get; set; }
        public int SpolID { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
    }
}
