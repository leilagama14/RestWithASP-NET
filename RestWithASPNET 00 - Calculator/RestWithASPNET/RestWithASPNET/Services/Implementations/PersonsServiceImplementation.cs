using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using RestWithASPNET.Model;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonsServiceImplementation : IPersonService
    {
        //Contador responsával por gerar um fake ID já que não estamos 
        //acessando nenhum banco de dados.
        private volatile int count;

        //Cria uma nova pessoa.
        public Person Create(Person person)
        {
            return  person;
        }

        //Deleta a partir de um ID.
        public void Delete(long id)
        {
            
        }

        //Lista de pessoas
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);

                persons.Add(person);
            }

            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Address = "Some Address " + i,
                FirstName = "Person Name " + i,
                Gender = "Female",
                Id = IncrementAndGet(),
                LastName = "Person LastName"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return  new Person
            {
                Address = "Salvador/Bahia",
                FirstName = "Leila",
                Gender = "Female",
                Id = 1,
                LastName = "Gama"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
