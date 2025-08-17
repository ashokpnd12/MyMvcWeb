using MyMvc.Data.Data;
using MyMvc.Data.Repository.IRepository;
using MyMvc.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db; 
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public void update(Product product)
        {
            _db.Update(product);
        }
    }
}
