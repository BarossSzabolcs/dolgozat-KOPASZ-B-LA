using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class adatok
    {
        public int Azonosito { get; set; }
        public int rAzonosito { get; set; }
        public bool belep {  get; set; }
        public int ora { get; set; }
        public int perc { get; set; }
        public int mperc { get; set; }
        public adatok(string sor)
        {
            string[] sz = sor.Split(' ');
            Azonosito = int.Parse(sz[0]);
            rAzonosito = int.Parse(sz[1]);
            if (int.Parse(sz[2]) == 0)
            {
                belep = true;
            }
            ora = int.Parse(sz[3]);
            perc = int.Parse(sz[4]);
            mperc = int.Parse(sz[5]);

        }
    }
    
}
