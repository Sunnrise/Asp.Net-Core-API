using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public CategoriesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            return Ok( await _serviceManager.CategoryService.GetAllCategoriesAsync(trackChanges: false));       
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneCategory([FromRoute] int id)
        {
            return Ok(await
                _serviceManager.CategoryService.GetOneCategoryByIdAsync(id, trackChanges: false));
        }
    }
}
