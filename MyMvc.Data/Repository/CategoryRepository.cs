using MyMvc.Data.Data;
using MyMvc.Data.Repository.IRepository;
using MyMvc.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public void update(Category category)
        {
            _db.Update(category);
        }
    }
}
