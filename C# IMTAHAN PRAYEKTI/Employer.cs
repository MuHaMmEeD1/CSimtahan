using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__IMTAHAN_PRAYEKTI
{
    public class Employer
    {
    
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Seher { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public List<Vacancies>Vacanciess { get; set; } = new List<Vacancies>();
        public List<Worker> Workers { get; set; } = new List<Worker>();
        public Employer(Guid ıd, string name, string surname, string seher, string phone, int age)
        {
            Id = ıd;
            Name = name;
            Surname = surname;
            Seher = seher;
            Phone = phone;
            Age = age;
            
        }
        public Employer()
        {
         
        }


        public void show()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Seher: {Seher}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"\nVacanciess {{"); for (int i = 0; i < Vacanciess.Count; i++) { Vacanciess[i].show(); }
            Console.WriteLine("}");
        }





    }
}
