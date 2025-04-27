using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IdareEtme.Model;
using Microsoft.Data.SqlClient;

namespace IdareEtme.Repositories
{
    public class ProductRepository : IProductRepository
    {
        const string connStr = "Server=.\\SQLEXPRESS;Database=IdareEtme;Trusted_Connection=True;TrustServerCertificate=True;";
        SqlConnection _conn => new SqlConnection(connStr);

        public void Add(string name, decimal price, int categoryId)
        {
            using (_conn)
            {
                _conn.Execute("INSERT INTO Products (Name, Price, CategoryId) VALUES (@Name, @Price, @CategoryId)", new { Name = name, Price = price, CategoryId = categoryId });
            }
        }
        public void Update(int id, string name, decimal price, int categoryId)
        {
            using (_conn)
            {
                _conn.Execute("UPDATE Products SET Name = @Name, Price = @Price, CategoryId = @CategoryId WHERE Id = @Id",new { Id = id, Name = name, Price = price, CategoryId = categoryId });
            }
        }
        public void Delete(int id)
        {
            using (_conn)
            {
                _conn.Execute($"DELETE FROM Products WHERE Id=@id", new {Id= id });
            }
        }
        public List<Product> GetAll()
        {
            using (_conn)
            {
                var list = _conn.Query<Product>("SELECT * FROM Products").ToList();
                return list;
            }
        }
        public Product GetById(int id)
        {
            using (_conn)
            {
                var product = _conn.QueryFirstOrDefault<Product>("SELECT * FROM Categories WHERE Id = @id", new { Id = id });
                return product;
            }
        }
    }
}
