using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithASPNET.Business;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonsBusinessImpl : IPersonBusiness
    {
        public IPersonRepository _repository;

        public PersonsBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }

        //Contador responsával por gerar um fake ID já que não estamos 
        //acessando nenhum banco de dados.
        private volatile int count;

        //Cria uma nova pessoa.
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        //Deleta a partir de um iD.
        public void Delete(long id)
        {
            _repository.Delete(id);

        }

        //Lista de pessoas
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

    }
}
