using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Lab_13._2_11._3.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public long id { get; set; }
        
        public string Category { get; set; }
        public string Description { get; set; }

        public string Name { get; set; }
        public Decimal Price { get; set; }

        public static Product Create(string _name, Decimal _price)
        {
            //create the new Product instance
            Product prod = new Product() { Name = _name, Price = _price };

            //save it to the database
            IDbConnection db = new SqlConnection("Server=BW18Q13\\SQLEXPRESS;Database=devbuildjoin;user id=test;password=password");
            long _id = db.Insert<Product>(prod);

            //set the id column of the instance
            prod.id = _id;

            //return the instance
            return prod;
        }
        public static Product Read(long _id)
        {
            IDbConnection db = new SqlConnection("Server=BW18Q13\\SQLEXPRESS;Database=devbuildjoin;user id=test;password=password");
            Product prod = db.Get<Product>(_id);
            return prod;
        }
        public static List<Product> Read()
        {
            IDbConnection db = new SqlConnection("Server=BW18Q13\\SQLEXPRESS;Database=devbuildjoin;user id=test;password=password");
            List<Product> prods = db.GetAll<Product>().ToList();
            return prods;
        }
        public static void Delete(long _id)
        {
            IDbConnection db = new SqlConnection("Server=BW18Q13\\SQLEXPRESS;Database=devbuildjoin;user id=test;password=password");
            db.Delete(new Product() { id = _id });

        }
        public void Save()
        {
            IDbConnection db = new SqlConnection("Server=BW18Q13\\SQLEXPRESS;Database=devbuildjoin;user id=test;password=password");
            db.Update(this);
        }
    }
}
