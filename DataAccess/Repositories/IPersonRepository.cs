using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public  interface IPersonRepository
    {
        Task<bool> Add(Person person);
        Task<bool> Update(Person person);   
        Task<bool> Delete(int id);
        Task<Person> GetById(int id);
        Task<IEnumerable<Person>> GetAll(); 


    }
}
