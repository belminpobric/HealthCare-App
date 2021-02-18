using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace HealthCare.Controllers
{
    public class PDFController : Controller
    {
        private readonly MyContext _context;

        public PDFController(MyContext context)
        {
            _context = context;
        }

        public IActionResult PrijemiPDF()
        {
            PrijemVM prijemVM = new PrijemVM
            {
                Rows = _context.PacijentPrijemi.Select(x => new PrijemVM.Row
                {
                    DatumVrijemePrijema = x.DatumVrijeme,
                    ImePrezimeLjekar = x.Ljekar.Ime + ' ' + x.Ljekar.Prezime,
                    ImePrezimePacijent = x.Pacijent.Ime + ' ' + x.Pacijent.Prezime,
                    IsHitno = x.IsHitno,
                    IsOtkazano = x.IsOtkazano,
                    NalazOpis = _context.Nalazi.Where(y=>y.PacijentPrijemID==x.Id).Select(x=>x.NalazOpis).FirstOrDefault()
                }).ToList(),
                
            };
            return new ViewAsPdf("PrijemiPDF",prijemVM);
        }
       
    }
}
