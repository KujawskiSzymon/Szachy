
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szachy.Models
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SzachyContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SzachyContext>>()))
            {
                // Look for any movies.
                if (context.Gracz.Any() && context.Klub.Any())
               {
                return;
                }
                context.Klub.AddRange(
                    new Klub
                    {
                        Liga = "Pierwsza",
                        Nazwa="Wksz Włocławek 1938"
                    },
                    new Klub
                    {
                        Liga = "Pierwsza",
                        Nazwa = "Hetman Bydgoszcz"
                    }
                    );

                context.Gracz.AddRange(
                    new Gracz
                    {
                        
                       Imie  = "Szymon",
                        Nazwisko = "Kujawski",
                        Plec = true,
                        Ranking =1600,
                        Id_Klub = 1
                    },

                    new Gracz
                    {
                       
                        Imie = "Kamil",
                        Nazwisko = "Jankowski",
                        Plec = true,
                        Ranking = 1200,
                        Id_Klub = 2
                        
                    },

                    new Gracz
                    {
                        
                        Imie = "Paulina",
                        Nazwisko = "Ciemcioch",
                        Plec = true,
                        Ranking = 1000,
                        Id_Klub = 1
                    },

                     new Gracz
                     {
                         
                         Imie = "Bartosz",
                         Nazwisko = "Bartoszyński",
                         Plec = true,
                         Ranking = 1300,
                         Id_Klub=2
                     }
                );
                context.AddRange(
                    new Mecz
                    {
                        Data = DateTime.Now,
                        Id_Bialy = 1,
                         Id_Czarny= 2,
                        Wynik = 1,
                    },
                     new Mecz
                     {
                         Data = DateTime.Now,
                         Id_Bialy = 2,
                         Id_Czarny = 3,
                         Wynik = 0,
                     },
                      new Mecz
                      {
                          Data = DateTime.Now,
                          Id_Bialy = 1,
                          Id_Czarny = 4,
                          Wynik = -1,
                      }
                    );
                context.SaveChanges();
            }
        }
    }
}
