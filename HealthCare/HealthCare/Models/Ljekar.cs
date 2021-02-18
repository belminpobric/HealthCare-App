using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Models
{
    public class Ljekar
    {
        [Required(ErrorMessage ="Ovo polje je obavezno.")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ovo polje je obavezno.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public Titula Titula { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Prezime { get; set; }
        [Required(ErrorMessage ="Ovo polje je obavezno.")]
        public string Sifra { get; set; }
    }
    public enum Titula
    {
        Specijalista,
        Specijalizant,
        MedicinskaSestra
    }
}
