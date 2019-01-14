using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonsServiceImplementation : IPersonService
    {
        public MySQLContext _context;

        public PersonsServiceImplementation(MySQLContext context)
        {
            _context = context;
        }
        
        //Contador responsával por gerar um fake ID já que não estamos 
        //acessando nenhum banco de dados.
        private volatile int count;

        //Cria uma nova pessoa.
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        //Deleta a partir de um iD.
        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null) _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        //Lista de pessoas
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        private bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
