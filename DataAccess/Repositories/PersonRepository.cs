using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public  class PersonRepository: IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(PersonContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var person = await GetById (id);
                if(person == null) 
                {
                    return false;
                }
                _context.Persons.Remove(person);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<Person> GetById(int id)
        {
            var person = _context.Persons.Find(id);
            return person;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
              return _context.Persons.ToList();
        }

        public async Task<bool> Update(Person person)
        {
            try
            {
                _context.Update(person);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
