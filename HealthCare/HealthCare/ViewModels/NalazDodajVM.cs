using HealthCare.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.ViewModels
{
    public class NalazDodajVM
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        [Display(Name = "Datum i vrijeme nalaza")]
        public DateTime DatumNalaza { get; set; }
        public PacijentPrijem PacijentPrijem { get; set; }
        [Display(Name = "Opis nalaza")]
        [Required]
        public string NalazOpis { get; set; }
    }
}
