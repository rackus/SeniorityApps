using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.ConsoleApp.DAO;

namespace EntityFramework.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AdventureWorksContext())
            {
                
                Person personToAdd = CreatePerson("Tom", "Jones", "EM");
                
                context.Person.Add(personToAdd);
                context.SaveChanges();
                var person = context.Person.First(x => x.FirstName == "Tom" && x.LastName == "Jones");
            }
        }

        static Person CreatePerson(string firstName, string lastName, string personType)
        {
            return new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                PersonType = personType,
                ModifiedDate = DateTime.Now,
                BusinessEntity = new BusinessEntity()
                {
                    ModifiedDate = DateTime.Now
                }
            };
        }
    }

}
