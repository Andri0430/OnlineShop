using Microsoft.AspNetCore.Mvc;
using OnlineShop.Dto;
using OnlineShop.Interface;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category : ControllerBase
    {
        private readonly ICategory _categoryRepo;

        public Category(ICategory categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpPost("create")]
        public IActionResult CreateCategory([FromQuery] CategoryDto categoryDto)
        {
            var cekNamaKategori = _categoryRepo.GetAllCategories().Where(c => c.CategoryName  .ToLower() == categoryDto.CategoryName.ToLower()).FirstOrDefault();

            if (cekNamaKategori != null) return BadRequest("Nama Kategori Sudah Terdaftar");

            var newCategory = new Models.Category
            {
                CategoryName = categoryDto.CategoryName
            };

            _categoryRepo.CreateCategory(newCategory);
            return Ok("Create Success");
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryRepo.GetAllCategories());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var categoryId = _categoryRepo.GetCategoryById(id);
            if (categoryId == null) return BadRequest("Id Tidak di Temukan!!");

            return Ok(categoryId);
        }

        [HttpPut("update")]
        public IActionResult UpdadteCategory(int id, CategoryDto categoryDto)
        {
            var categoryId = _categoryRepo.GetCategoryById(id);

            if (categoryId == null) return BadRequest("Id Tidak di Temukan!!");
            
            //update nama kategori berdasarkan id yang kita input, jika id cocok
            categoryId.CategoryName = categoryDto.CategoryName;

            _categoryRepo.UpdateCategory(categoryId);
            return Ok("Update Success");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var categoryId = _categoryRepo.GetCategoryById(id);

            if (categoryId == null) return BadRequest("Id Tidak di Temukan!!");

            _categoryRepo.DeleteCategory(id);

            return Ok("Berhasil Hapus");
        }
    }
}