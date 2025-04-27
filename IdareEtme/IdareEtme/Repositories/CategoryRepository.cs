using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IdareEtme.Model;
using Microsoft.Data.SqlClient;

namespace IdareEtme.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        const string connStr = "Server=.\\SQLEXPRESS;Database=IdareEtme;Trusted_Connection=True;TrustServerCertificate=True;";
        SqlConnection _conn => new SqlConnection(connStr);

        public void Add(string name)
        {
            using (_conn)
            {
                var exist = _conn.QueryFirstOrDefault<Category>("SELECT * FROM Categories WHERE Name = @Name", new { Name = name });
                if (exist != null)
                    throw new Exception("Bu adda artıq bir kateqoriya var!");

                _conn.Execute("INSERT INTO Categories (Name) VALUES (@Name)", new { Name = name });
            }
        }
        public void Update(int id, string name)
        {
            using (_conn)
            {
                _conn.Execute("UPDATE Categories SET Name = @Name WHERE Id = @Id",new { Id = id, Name = name });
            }
        }
        public void Delete(int id)
        {
            using (_conn)
            {
                var product = _conn.QueryFirstOrDefault<Product>("SELECT * FROM Products WHERE CategoryId = @ CategoryId", new { CategoryId = id });
                if (product != null)
                    throw new Exception("Bu kateqoriya silinə bilməz, çünki məhsullar tərəfindən istifadə olunur.");
                _conn.Execute($"DELETE FROM Categories WHERE Id=@id", new { Id =id });
            }
        }
        public List<Category> GetAll()
        {
            using (_conn)
            {
                var list = _conn.Query<Category>("SELECT * FROM Products").ToList();
                return list;
            }
        }
        public Category GetById(int id)
        {
            using (_conn)
            {
                var category = _conn.QueryFirstOrDefault<Category>("SELECT * FROM Categories WHERE Id = @id", new { Id = id });
                return category;
            }
        }
    }
}

