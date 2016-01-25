using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Where(p => p.Company.Name == "Samsung");
                foreach (Phone p in phones)
                    Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);

                var phones2 = db.Phones.OrderBy(p => p.Name);
                Console.WriteLine("phones2:");
                foreach (Phone p in phones2)
                    Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);
                var phones3 = from p in db.Phones
                             orderby p.Name
                             select p;
                Console.WriteLine("phones3:");
                foreach (Phone p in phones3)
                    Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);

                var phones4 = db.Phones.OrderByDescending(p => p.Name);
                Console.WriteLine("phones4:");
                foreach (Phone p in phones4)
                    Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);
                var phones5 = db.Phones
                    .Select(p => new { Name = p.Name, Company = p.Company.Name, Price = p.Price })
                    .OrderBy(p => p.Price)
                    .ThenBy(p => p.Company);
                Console.WriteLine("phones5:");
                foreach (var p in phones5)
                    Console.WriteLine("{0}.{1} - {2}", p.Company, p.Name, p.Price);
            }
            Console.ReadLine();
        }
    }
}
