using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare.Models;
using HealthCare.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Rotativa;

namespace HealthCare.Controllers
{
    public class PrijemController : Controller
    {
        private readonly MyContext _context;
        public PrijemController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index(PrijemVM vm)
        {

            PrijemVM prijemVM = new PrijemVM
            {
                DatumDO = vm.DatumDO ?? DateTime.Today.AddDays(7),
                DatumOD = vm.DatumOD ?? _context.PacijentPrijemi.Where(x => x.DatumVrijeme <= DateTime.Today).Select(x=>x.DatumVrijeme).FirstOrDefault()
            };


            prijemVM.Rows = _context.PacijentPrijemi
                .Where(x => x.IsOtkazano == false)
                .Where(x => x.DatumVrijeme.Date >= prijemVM.DatumOD.Value.Date && x.DatumVrijeme.Date <= prijemVM.DatumDO.Value.Date)
                .Select(x => new PrijemVM.Row
                {
                    DatumVrijemePrijema = x.DatumVrijeme,
                    ImePrezimeLjekar = x.Ljekar.Ime + ' ' + x.Ljekar.Prezime + '-' + x.Ljekar.Sifra.ToString(),
                    ImePrezimePacijent = x.Pacijent.Ime + ' ' + x.Pacijent.Prezime,
                    IsHitno = x.IsHitno,
                    ID = x.Id,
                    NalazID = _context.Nalazi.Where(y => y.PacijentPrijemID == x.Id).Select(y => y.ID).FirstOrDefault()
                }).ToList();

            return View(prijemVM);
        }
        public IActionResult Dodaj()
        {
            PrijemDodajVM pmd = PripremiVM();
            return View(pmd);
        }

        private PrijemDodajVM PripremiVM()
        {
            return new PrijemDodajVM
            {
                DatumVrijeme = DateTime.Now,
                Ljekari = _context.Ljekari.Where(x => x.Titula == Models.Titula.Specijalista).Select(x => new SelectListItem
                {
                    Text = x.Ime + ' ' + x.Prezime,
                    Value = x.Id.ToString()
                }).ToList(),
                Pacijenti = _context.Pacijenti.Select(x => new SelectListItem
                {
                    Text = x.Ime + ' ' + x.Prezime,
                    Value = x.Id.ToString()
                }).ToList()
            };
        }

        public IActionResult Snimi(PrijemDodajVM pdm)
        {
            if (!ModelState.IsValid)
            {
                PrijemDodajVM pmd = PripremiVM();
                return View("Dodaj", pmd);
            }

            PacijentPrijem prijem;
            if (pdm.ID == 0)
            {
                prijem = new PacijentPrijem();
                _context.Add(prijem);
            }
            else
            {
                prijem = _context.PacijentPrijemi.Find(pdm.ID);
            }
            if (prijem != null)
            {
                prijem.DatumVrijeme = pdm.DatumVrijeme;
                prijem.IsHitno = pdm.IsHitno;
                prijem.LjekarID = pdm.LjekarID;
                prijem.PacijentID = pdm.PacijentID;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Izmijeni(int id)
        {
            PrijemDodajVM pmd = PripremiVM();

            var prijem = _context.PacijentPrijemi.Find(id);

            if (prijem != null)
            {
                pmd.DatumVrijeme = prijem.DatumVrijeme;
                pmd.IsHitno = prijem.IsHitno;
                pmd.LjekarID = prijem.LjekarID;
                pmd.PacijentID = prijem.PacijentID;

                pmd.ID = id;
            }
            return View("Dodaj", pmd);
        }
        public IActionResult Otkazi(int id)
        {

            var prijem = _context.PacijentPrijemi.Find(id);

            if (prijem != null)
            {
                prijem.IsOtkazano = true;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Nalaz(int id)
        {
            var prijem = _context.PacijentPrijemi.Where(x => x.Id == id).Include(x => x.Pacijent).FirstOrDefault();
            if (prijem != null)
            {
                var ndm = new NalazDodajVM
                {
                    DatumNalaza = DateTime.Now,
                    PacijentPrijem = prijem
                };
                return View(ndm);
            }
            return RedirectToAction("Index");

        }
        public IActionResult SnimiNalaz(NalazDodajVM ndv)
        {

            if (!ModelState.IsValid)
            {
                return View("Dodaj", ndv);
            }

            PacijentPrijem prijem;


            prijem = _context.PacijentPrijemi.Find(ndv.PacijentPrijem.Id);

            if (prijem != null)
            {
                Nalaz nalaz = new Nalaz
                {
                    DatumVrijeme = ndv.DatumNalaza,
                    PacijentPrijemID = ndv.PacijentPrijem.Id,
                    NalazOpis = ndv.NalazOpis

                };
                _context.Add(nalaz);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public IActionResult PregledajNalaz(int id)
        {
            var nalaz = _context.Nalazi.Where(x => x.ID == id)
                .Include(x => x.PacijentPrijem.Pacijent)
                .Include(x => x.PacijentPrijem.Ljekar)
                .FirstOrDefault();

            if (nalaz != null)
            {
                return PartialView(nalaz);
            }
            return NotFound();
        }
       


    }
}
