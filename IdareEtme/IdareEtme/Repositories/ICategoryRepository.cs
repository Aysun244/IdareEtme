using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdareEtme.Model;

namespace IdareEtme.Repositories
{
    public interface ICategoryRepository
    {
        void Add (string name);
        void Update (int id,string name);
        void Delete (int id);
        List<Category> GetAll ();
        Category GetById (int id);
    }
}
