using HealthCare.Controllers;
using HealthCare.Models;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.EF
{

    public static class MyInitializer
    {

        public static void Seed(MyContext _context)
        {
            if (_context.Ljekari.Count() != 0)
            {
                return;
            }
            var personGenerator = new PersonNameGenerator();
            var placeGenerator = new PlaceNameGenerator();
            var muski = new Spol { Naziv = "Male" };
            var zenski = new Spol { Naziv = "Female" };
            var unknown = new Spol { Naziv = "Unknown" };
            var Ljekari = new List<Ljekar>();
            var Pacijenti = new List<Pacijent>();
            for (int i = 0; i < 5; i++)
            {
                Ljekari.Add(new Ljekar
                {
                    Ime = personGenerator.GenerateRandomMaleFirstName(),
                    Prezime = personGenerator.GenerateRandomLastName(),
                    Sifra = MyRandomExtensions.MyRandomString(5),
                    Titula = (Titula)MyRandomExtensions.RandomNumber(0, 2)
                });

            }
            for (int i = 0; i < 5; i++)
            {
                Ljekari.Add(new Ljekar
                {
                    Ime = personGenerator.GenerateRandomFemaleFirstName(),
                    Prezime = personGenerator.GenerateRandomLastName(),
                    Sifra = MyRandomExtensions.MyRandomString(5),
                    Titula = (Titula)MyRandomExtensions.RandomNumber(0, 2),
                });


            }
            for (int i = 0; i < 10; i++)
            {
                Pacijenti.Add(new Pacijent
                {
                    Ime = personGenerator.GenerateRandomMaleFirstName(),
                    Prezime = personGenerator.GenerateRandomLastName(),
                    Adresa = placeGenerator.GenerateRandomPlaceName(),
                    BrojTelefona = "+387" + MyRandomExtensions.RandomNumber(61, 66) + MyRandomExtensions.RandomNumber(100, 200) + MyRandomExtensions.RandomNumber(400, 500),
                    DatumRodjenja = DateTime.Now.AddYears(-MyRandomExtensions.RandomNumber(41, 71)),
                    Spol = muski
                }); ;


            }
            for (int i = 0; i < 10; i++)
            {
                Pacijenti.Add(new Pacijent
                {
                    Ime = personGenerator.GenerateRandomFemaleFirstName(),
                    Prezime = personGenerator.GenerateRandomLastName(),
                    Adresa = placeGenerator.GenerateRandomPlaceName(),
                    BrojTelefona = "+387" + MyRandomExtensions.RandomNumber(61, 66) + MyRandomExtensions.RandomNumber(100, 200) + MyRandomExtensions.RandomNumber(400, 500),
                    DatumRodjenja = DateTime.Now.AddYears(-MyRandomExtensions.RandomNumber(41, 71)),
                    Spol = zenski
                }); 
            }
            _context.Spol.Add(muski);
            _context.Spol.Add(zenski);
            _context.Spol.Add(unknown);
            foreach(var item in Ljekari)
            {
                _context.Ljekari.Add(item);
            }
            foreach (var item in Pacijenti)
            {
                _context.Pacijenti.Add(item);
            }
            _context.SaveChanges();
        }
    }
    public static class MyRandomExtensions
    {
        public static string MyRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static readonly Random random = new Random();

        public static int RandomNumber(int min, int max)
        {
            int x = random.Next(min, max+1);
            return x;
        }
    }
}
