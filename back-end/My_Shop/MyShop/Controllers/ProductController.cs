using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using System.Linq;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        MyShopContext db = new MyShopContext();

        [HttpGet]
        public List<Product> GetAllProducts() => 
            db.Products.Where(p => p.Active == 1).ToList();

        [HttpGet("search/{productName}")]
        public List<Product> GetProductsByName(string productName) 
            => db.Products.Where(p => p.ProductName.Contains(productName)).ToList();
        [HttpGet("productId")]
        public Product GetProductsByID(int productId)
            => db.Products.FirstOrDefault(p => p.ProductId == productId);


        [HttpPost("page")]
        public List<Product> GetProductsByCategoryIDs(Paging page)
        {
            int pageNumber = page.PageIndex ?? 1 - 1; 
            int pageSize = page.NumberOfPage ?? 1; 

            if(page.CategoryIds.Count == 0)
            {
                var _products = db.Products
                .Where(p => p.ProductName.Contains(page.searchName) && p.Active != 0)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
                return _products;
            }

            var products = db.Products
                .Where(p => p.ProductName.Contains(page.searchName) && p.Active != 0
                            && (p.CategoryId.HasValue && page.CategoryIds.Contains(p.CategoryId.Value)))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return products;
        }


        [HttpPost("numberOfPage")]
        public double GetProductsnumberOfPage(Paging page)
        {
            int pageNumber = page.PageIndex ?? 1 - 1;
            int pageSize = page.NumberOfPage ?? 1;

            if (page.CategoryIds.Count == 0)
            {
                var _products = db.Products
                .Where(p => p.ProductName.Contains(page.searchName) && p.Active != 0)
                .ToList();
                return Math.Ceiling((_products.Count * 1.0 / page.NumberOfPage ?? 1));
            }

            var products = db.Products
                .Where(p => p.ProductName.Contains(page.searchName) && p.Active != 0
                            && (p.CategoryId.HasValue && page.CategoryIds.Contains(p.CategoryId.Value)))
                .ToList();
            return Math.Ceiling(products.Count * 1.0 / page.NumberOfPage ?? 1);
        }

        [HttpPost]
        public bool InsertProduct(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
            return true;
        }
    }
}
