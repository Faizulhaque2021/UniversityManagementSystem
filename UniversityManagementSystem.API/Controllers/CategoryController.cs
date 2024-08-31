using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagementSystem.API.ViewModels.Request;
using UniversityManagementSystem.DLL.DbContext;
using UniversityManagementSystem.DLL.Models;

namespace UniversityManagementSystem.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CategoryController : ApiBaseController
    {
        private readonly ApplicationDbContext _dbcontext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = await _dbcontext.categories.AsQueryable().ToListAsync();
            return Ok(categories);
        }

        [HttpGet(template: "id")]
        public async Task<IActionResult> GetAData(int id)
        {
            var categories = await _dbcontext.categories.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CategoryInsertViewModel request)
        {
            var category = new Category()
            {
                Name = request.Name,
            };

            _dbcontext.categories.Add(category);

            if (await _dbcontext.SaveChangesAsync() > 0)
            {
                return Ok(category);
            }

            return NotFound("Inser Error");

        }

        [HttpPut(template: "id")]
        public async Task<IActionResult> Update(int id, CategoryInsertViewModel request)
        {
            var category = await _dbcontext.categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            category.Name = request.Name;
            _dbcontext.categories.Update(category);

            if (await _dbcontext.SaveChangesAsync() > 0)
            {
                return Ok(category);
            }
            return NotFound("Update Error");

        }

        [HttpDelete(template: "id")]

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _dbcontext.categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound("Data Not Found");
            }

            _dbcontext.categories.Remove(category);

            if (await _dbcontext.SaveChangesAsync() > 0)
            {
                return Ok("Data Delete Successfully");
            }

            return NotFound("Delete Error");
        }
    }
}
