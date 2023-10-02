using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace C__IMTAHAN_PRAYEKTI
{
    public class Worker
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Seher { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public CV cV { get; set; }

        public Worker(Guid ıd, string name, string surname, string seher, string phone, int age, CV cV)
        {
            Id = ıd;
            Name = name;
            Surname = surname;
            Seher = seher;
            Phone = phone;
            Age = age;
            this.cV = cV;
        }
       
        public Worker() { }

        public void show()
        {

            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Seher: {Seher}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine("\nCV{ ");
            cV.show();
            Console.WriteLine("}\n");
        }



    }
}
