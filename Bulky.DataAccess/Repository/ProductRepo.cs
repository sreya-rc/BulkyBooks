using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        private ApplicationDbContext _db;

        public ProductRepo(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }

        public void Update(Product obj) // Update is in individual repository instead of generic since there is manual mapping
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);

            if (objFromDb != null)  // Whichever fields are not null (they have old values) are updated
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;

                if (obj.ImageURL != null)   // If an image URL has been entered by user, update pre-existing value
                {
                    objFromDb.ImageURL = obj.ImageURL;
                }
            }
        }
    }
}
