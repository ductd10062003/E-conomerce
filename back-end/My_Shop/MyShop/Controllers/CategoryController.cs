using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        MyShopContext db = new MyShopContext();
        [HttpGet] 
        public List<Category> GetAllCategories() => db.Categories.ToList();
        [HttpGet("categoryId/{id}")]
        public Category GetCategoryById(int id) { return db.Categories.FirstOrDefault(c => c.CategoryId == id); }
        [HttpPost("insertCategory")]
        [Authorize]
        public void InsertCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }
        
    }
}
