using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ToThanhNha_2122110373.Model;

namespace ToThanhNha_2122110373.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // Giả sử bạn đang sử dụng một danh sách tạm thời thay cho cơ sở dữ liệu
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Electronics", image = "electronics.jpg" },
            new Category { Id = 2, Name = "Clothing", image = "clothing.jpg" }
        };

        // GET api/category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return Ok(categories);
        }

        // GET api/category/{id}
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        // POST api/category
        [HttpPost]
        public ActionResult<Category> CreateCategory([FromBody] Category category)
        {
            // Kiểm tra xem category có hợp lệ không
            if (category == null || string.IsNullOrEmpty(category.Name) || string.IsNullOrEmpty(category.image))
            {
                return BadRequest("Name and Image are required fields.");
            }

            // Tạo ID mới cho category
            category.Id = categories.Count + 1;

            // Thêm category vào danh sách (hoặc cơ sở dữ liệu trong thực tế)
            categories.Add(category);

            // Trả về thông tin category vừa tạo
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PUT api/category/{id}
        [HttpPut("{id}")]
        public ActionResult<Category> UpdateCategory(int id, [FromBody] Category category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
                return NotFound();

            // Cập nhật thông tin category
            existingCategory.Name = category.Name;
            existingCategory.image = category.image;

            return NoContent();
        }

        // DELETE api/category/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            categories.Remove(category);
            return NoContent();
        }
    }
}
