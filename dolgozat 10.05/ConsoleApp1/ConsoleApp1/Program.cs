using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[] fajl = File.ReadAllLines("furdoadat.txt", Encoding.UTF8);
            List<adatok> listaAdatok = new List<adatok>();
            for (int i = 0; i < fajl.Length; i++)
            {
                listaAdatok.Add(new adatok(fajl[i]));
            }
            var masodik = listaAdatok.Where(x => !x.belep).OrderBy(x => new TimeSpan(x.ora, x.perc, x.mperc)).ToList();
            Console.WriteLine($"2. feladat: Az első vendég {masodik.First().ora}:{masodik.First().perc}:{masodik.First().mperc} órakkor lépett ki!");
            Console.WriteLine($"Az utolsó vendég {masodik.Last().ora}:{masodik.Last().perc}:{masodik.Last().mperc} órakkor lépett ki!");




            var harmadik = listaAdatok
                .Where(x => x.rAzonosito > 0)
                .GroupBy(X => X.Azonosito)
                .Count(g => g.Select(x=> x.rAzonosito).Distinct().Count() == 1 && g.Count() == 2);
            Console.WriteLine($"3.feladat:{harmadik} vendég csak egy részlegen járt! ");

            

            var otodik = listaAdatok.Where(x => (x.ora == 06) && (x.perc == 00) && (x.mperc == 00));
            foreach (var o in otodik)
            {
                
                
            }
            /*var hatodik = listaAdatok
                .Where(x=> x.rAzonosito == 2)
                .GroupBy(x => x.Azonosito)
                .Select(g => new
                { 
                    Azonosito = g.Key,
                    ido = g.Where(x=> !x.belep).Sum(x => new (x.ora, x.perc, x.mperc))-g.Where(x => new ())
                }
                
                
                )*/
            var reszleg = listaAdatok
            .Where(x => x.rAzonosito > 0)
            .GroupBy(x => x.rAzonosito)
            .Select(g => new
            {
                reszlegek = g.Key,
                latogatok = g.Select(x => x.Azonosito).Distinct().Count()
            });

            Console.WriteLine("7. feladat:");
            foreach (var section in reszleg)
            {
                Console.WriteLine($"A(z) {section.reszlegek} részleget {section.latogatok} vendég használta.");
            }


           
        }



    }
    }


