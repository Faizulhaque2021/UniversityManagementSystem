using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityManagementSystem.BLL.Service;
using UniversityManagementSystem.BLL.ViewModels.Request;
using UniversityManagementSystem.DLL.Models;

namespace UniversityManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ApiBaseController
    {
        public readonly ICategoryService _categoryService;
        public readonly ITestSingleTone _testSingleTone;
        public TestController(ICategoryService categoryService, ITestSingleTone testSingleTone)
        {
            _categoryService = categoryService;
            _testSingleTone = testSingleTone;
        }

        [HttpGet(template:"normalInsert/{id}")]
        public async Task<IActionResult> AddNumberNormal(int id)
        {

            return Ok(await _categoryService.AddNumber(id));
        }

        [HttpGet(template: "normalGet/{id}")]
        public async Task<IActionResult> GetNumberNormal()
        {

            return Ok(await _categoryService.GetNumber());
        }

        [HttpGet(template: "normalInsertSingle/{id}")]
        public async Task<IActionResult> AddNumberSingle(int id)
        {

            return Ok(await _categoryService.AddNumber(id));
        }

        [HttpGet(template: "normalGetSingle/{id}")]
        public async Task<IActionResult> GetNumberSingle()
        {

            return Ok(await _categoryService.GetNumber());
        }
    }
}
