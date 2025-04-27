using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdareEtme.Model;

namespace IdareEtme.Repositories
{
    public interface IProductRepository
    {
        void Add (string name,decimal price,int categoryId);
        void Update (int id,string name, decimal price, int categoryId);
        void Delete(int id);
        List<Product> GetAll ();
        Product GetById (int id);

    }
}
