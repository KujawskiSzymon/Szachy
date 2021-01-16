using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Szachy.Models;
using Szachy.Models.ViewModels;

namespace Szachy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SzachyContext dbContext;

        public HomeController(ILogger<HomeController> logger, SzachyContext appContext)
        {
            _logger = logger;
            dbContext = appContext;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gracz gracz)
        {
            if (ModelState.IsValid)
            {
                dbContext.Gracz.Add(gracz);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gracz);
        }

        public IActionResult CreateKlub()
        {
            return View();
        }

        public IActionResult AddClub(int Id)
        {
            GraczDoKlubu gk = new GraczDoKlubu();
            gk.giki = new GraczIdKlubId();
            gk.k = dbContext.Klub.ToList();
            gk.giki.idGracz = Id;
            gk.giki.idKlub = 0;
            return View(gk);
        }

        public async Task<IActionResult> GraczDoKlubu(int Id, int Idk)
        {
            var gracz = await dbContext.Gracz.FirstOrDefaultAsync(x => x.Id == Id);
            gracz.Id_Klub = Idk;
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditKlub(int? id)
        {
            
            List<Gracz> graczewKlubie = new List<Gracz>();
            List<Gracz> gracze =  await dbContext.Gracz.ToListAsync();
            foreach(var gracz in gracze)
            {
                if (gracz.Id_Klub == id)
                {
                    graczewKlubie.Add(gracz);
                }
            }
            return View(graczewKlubie);
        }

        public IActionResult CreateMecz()
        {
            return View();
        }

        public async Task<IActionResult> PlayerClubDelete(int Id)
        {
            var gracz = await dbContext.Gracz.FirstOrDefaultAsync(x => x.Id_Klub == Id);
            gracz.Id_Klub = 0;
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Klub));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMecz(Mecz mecz)
        { 
            if (mecz.Id_Bialy == mecz.Id_Czarny || mecz.Wynik < -1 || mecz.Wynik > 1 || mecz.Id_Bialy <1 || mecz.Id_Czarny <1)
            {
                
                ModelState.AddModelError("error", "Podane błędne dane");
                return View();
            }
            mecz.Data = DateTime.Now;
            if (ModelState.IsValid)
            {
                dbContext.Mecz.Add(mecz);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Mecz));
            }
            return View(mecz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateKlub(Klub klub)
        {
            if (ModelState.IsValid)
            {
                dbContext.Klub.Add(klub);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Klub));
            }
            return View(klub);
        }

        public async Task<IActionResult> Index()
        {
            var gracze = await dbContext.Gracz.ToListAsync();
            return View(gracze);
        }
        public async Task<IActionResult> Klub()
        {
            var kluby = await dbContext.Klub.ToListAsync();
            return View(kluby);
        }
        public async Task<IActionResult> Mecz()
        {
            List<GraczMecz> gms = new List<GraczMecz>(); 
            var mecze = await dbContext.Mecz.ToListAsync();
            foreach (var k in mecze){
                GraczMecz gm = new GraczMecz();
                var graczB = await dbContext.Gracz.SingleOrDefaultAsync(x => x.Id == k.Id_Bialy);
                var graczC = await dbContext.Gracz.SingleOrDefaultAsync(x => x.Id == k.Id_Czarny);
                gm.GraczANazwisko = graczB.Nazwisko;
                gm.GraczAImie = graczB.Imie;
                gm.GraczBNazwisko = graczC.Nazwisko;
                gm.GraczBImie = graczC.Imie;
                gm.Mecz = k;
                
                if (k.Wynik == -1)
                    gm.wynik = "Czarne";
                else if (k.Wynik == 0)
                    gm.wynik = "Remis";
               else
                    gm.wynik = "Białe";
                gms.Add(gm);
            }
            return View(gms);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var gracz = await dbContext.Gracz.SingleOrDefaultAsync(x=>x.Id==id);
           var nazwa = await dbContext.Klub.SingleOrDefaultAsync(x => x.Id == gracz.Id_Klub);
            if (nazwa == null)
            {
                nazwa = new Klub() { Nazwa = "Brak" };
            }
           
            Graczklub gk = new Graczklub()
            {
                Gracz = gracz,
                Klub = nazwa.Nazwa
            };
            return View(gk);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
