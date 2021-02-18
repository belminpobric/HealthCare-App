using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.ViewModels
{
    public class PrijemDodajVM
    {
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        [Display(Name ="Datum i vrijeme")]
        public DateTime DatumVrijeme { get; set; }
        public List<SelectListItem> Ljekari { get; set; }
        [Display(Name = "Ljekar")]
        [Required]
        public int LjekarID { get; set; }
        public List<SelectListItem> Pacijenti { get; set; }
        [Display(Name = "Pacijent")]
        [Required]
        public int PacijentID { get; set; }
        [Display(Name = "Hitno")]

        public bool IsHitno { get; set; }
        public int ID { get; set; }
    }
}
