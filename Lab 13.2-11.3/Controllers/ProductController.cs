using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using Lab_13._2_11._3.Models;
using Dapper;

namespace Lab_13._2_11._3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            IDbConnection db = new SqlConnection("Server=BW18Q13\\SQLEXPRESS;Database=CoffeeShop;user id=test;password=password");
            db.Open();
            List<string> ItemCategory = db.Query<string>("select distinct ItemCategory from ItemList order by ItemCategory desc").AsList<string>();
            db.Close();

            return View(ItemCategory);

            //return View();
        }

        public IActionResult Coffees()
        {
            IDbConnection db = new SqlConnection("Server=BW18Q13\\SQLEXPRESS;Database=CoffeeShop;user id=test;password=password");
            db.Open();
            List<string> ItemName = db.Query<string>("select distinct ItemName from ItemList order by ItemName desc").AsList<string>();
            db.Close();

            return View(ItemName);
        }

        public IActionResult ProductInfo(int ItemID)
        {
            IDbConnection db = new SqlConnection("Server=BW18Q13\\SQLEXPRESS;Database=CoffeeShop;user id=test;password=password");
            db.Open();
            Product product = db.QuerySingle<Product>($"select * from ItemList where ItemID = {ItemID}");
            db.Close();

            return View(product);
        }
    }
}
