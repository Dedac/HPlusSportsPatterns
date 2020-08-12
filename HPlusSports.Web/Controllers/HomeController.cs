using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HPlusSports.DAL;
using Microsoft.EntityFrameworkCore;

namespace HPlusSports.Web.Controllers
{
    public class HomeController : Controller
    {
        HPlusSportsSqliteContext _context;
        HPlusSportsContext _sqlContext;
        public HomeController(HPlusSportsSqliteContext context, HPlusSportsContext sqlContext){
            _context = context;
            _sqlContext = sqlContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Go()
        {
            //await _context.Customer.AddRangeAsync(_sqlContext.Customer.ToList());
            // await _context.Product.AddRangeAsync(_sqlContext.Product.ToList());
            // await _context.PerishableProduct.AddRangeAsync(_sqlContext.PerishableProduct.ToList());
            // await _context.SalesGroup.AddRangeAsync(_sqlContext.SalesGroup.ToList());
            // await _context.Salesperson.AddRangeAsync(_sqlContext.Salesperson.ToList());
            // await _context.Order.AddRangeAsync(_sqlContext.Order.ToList());
            // await _context.OrderItem.AddRangeAsync(_sqlContext.OrderItem.ToList());
            // await _context.SaveChangesAsync();
            return View("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
