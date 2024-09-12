using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagementSystem.BLL.Service;
using UniversityManagementSystem.BLL.ViewModels.Request;
using UniversityManagementSystem.DLL.Models;

namespace UniversityManagementSystem.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CategoryController : ApiBaseController
    {
        
        public readonly ICategoryService _categoryService;
        public readonly ITestService _testService;
        public CategoryController(ICategoryService categoryService, ITestService testService)
        {
            _categoryService = categoryService;
            _testService = testService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(await _categoryService.GetAll());
        }

        [HttpGet(template: "id")]
        public async Task<IActionResult> GetAData(int id)
        {
            return Ok(await _categoryService.GetAData(id));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CategoryInsertViewModel request)
        {
            var category = new Category()
            {
                Name = request.Name,
            };

            return Ok(await _categoryService.AddCategory(category));

            //return NotFound("Inser Error");

        }

        [HttpPut(template: "id")]
        public async Task<IActionResult> Update(int id, CategoryInsertViewModel request)
        {
            return Ok(await _categoryService.UpdateCategory(id, request));
        }

        [HttpDelete(template: "id")]

        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _categoryService.DeleteCategory(id));
        }
    }
}
