using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Dto;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category : ControllerBase
    {
        private readonly OnlineShopContext _onlineShopContext;
        public Category(OnlineShopContext onlineShopContext)
        {
            _onlineShopContext = onlineShopContext;
        }

        [HttpPost("create")]
        public IActionResult CreateCategory([FromQuery] CategoryDto categoryDto)
        {
            var cekNamaKategori = _onlineShopContext.Categories.Where(c => c.CategoryName.ToLower() == categoryDto.CategoryName.ToLower()).FirstOrDefault();

            if (cekNamaKategori != null) return BadRequest("Nama Kategori Sudah Terdaftar");

            var newCategory = new Models.Category
            {
                CategoryName = categoryDto.CategoryName
            };

            _onlineShopContext.Categories.Add(newCategory);
            _onlineShopContext.SaveChanges();

            return Ok("Create Success");
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_onlineShopContext.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var categoryId = _onlineShopContext.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (categoryId == null) return BadRequest("Id Tidak di Temukan!!");

            return Ok(categoryId);
        }

        [HttpPut("update")]
        public IActionResult UpdadteCategory(int id, CategoryDto categoryDto)
        {
            var categoryId = _onlineShopContext.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (categoryId == null) return BadRequest("Id Tidak di Temukan!!");
            
            //update nama kategori berdasarkan id yang kita input, jika id cocok
            categoryId.CategoryName = categoryDto.CategoryName;

            _onlineShopContext.Categories.Update(categoryId);
            _onlineShopContext.SaveChanges();

            return Ok("Update Success");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var categoryId = _onlineShopContext.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (categoryId == null) return BadRequest("Id Tidak di Temukan!!");

            _onlineShopContext.Categories.Remove(categoryId);
            _onlineShopContext.SaveChanges();

            return Ok("Berhasil Hapus");
        }
    }
}