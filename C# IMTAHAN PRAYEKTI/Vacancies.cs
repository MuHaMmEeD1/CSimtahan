using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__IMTAHAN_PRAYEKTI
{
    public class Vacancies
    {


        public Guid Id { get; set; }
        public Guid IdMy { get; set; }
        public string Kataqorisi { get; set; }
        public string IsVaxti { get; set; }
        public string IsYeri { get; set; }
        public int Salary { get; set; }
        public int NeceIsciAxtarilir { get; set; }
        public int[] HefdeninIsGunlri { get; set; }

        public List<Worker> WorkerList { get; set; } = new List<Worker>();

        public Vacancies(Guid id,Guid idMy, string kataqorisi, string ısVaxti,string isYeri, int salary, int neceIsciAxtarilir, int[] hefdeninIsGunlri)
        {
            Id = id;
            IdMy = idMy;
            Kataqorisi = kataqorisi;
            IsVaxti = ısVaxti;
            IsYeri = isYeri;
            Salary = salary;
            NeceIsciAxtarilir = neceIsciAxtarilir;
            HefdeninIsGunlri = hefdeninIsGunlri;
        }
        public Vacancies()
        {

        }

        public void show()
        {
            Console.WriteLine($"{Kataqorisi} axtarilir");
            Console.WriteLine($"is vaxti: {IsVaxti}");
            Console.WriteLine($"is yeri: {IsYeri}");
            Console.WriteLine($"masi: {Salary}$");
            Console.Write("Hefdenin is gunleri: "); for ( int i = 0; i < HefdeninIsGunlri.Length; i++ ) { Console.Write(HefdeninIsGunlri[i]+" "); }
            Console.WriteLine($"\nNece isciye ehtiyac var: {NeceIsciAxtarilir}");
        }



    }
}
