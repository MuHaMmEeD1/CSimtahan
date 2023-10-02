using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__IMTAHAN_PRAYEKTI
{
    public class CV
    {

        public string Ixtisas { get; set; }
        public string OMekdeb { get; set; }
        public int UniBal { get; set; }
        public List<string> Bacatiqlar { get; set; } 
        public string Mekan { get; set; }
        public List<string> Lengivics { get; set; } 
        public bool Diplom { get; set; }

        public CV(string ıxtisas, string oMekdeb, int uniBal, List<string> bacatiqlar, string mekan, List<string> lengivics, bool diplom)
        {
            Ixtisas = ıxtisas;
            OMekdeb = oMekdeb;
            UniBal = uniBal;
            Bacatiqlar = bacatiqlar;
            Mekan = mekan;
            Lengivics = lengivics;
            Diplom = diplom;
        }

        public CV() { }

        public void show()
        {
            Console.WriteLine($"Ixtisas: {Ixtisas}");
            Console.WriteLine($"Oxduqu Mekdeb: {OMekdeb}");
            Console.WriteLine($"Unversite Bali: {UniBal}");
            Console.Write($"Bacatiqlar: "); for (int i = 0; i < Bacatiqlar.Count; i++) {Console.Write($" {Bacatiqlar[i]}");}
            Console.WriteLine($"\nYasadiqi Yer: {Mekan}");
            Console.Write($"Lengivics: "); for (int i = 0; i < Lengivics.Count; i++) { Console.Write($" {Lengivics[i]}"); }
            Console.WriteLine($"Diplom: {Diplom}");
        }


    }
}
