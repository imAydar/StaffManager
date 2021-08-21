using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffManager.Core.Services;
using StaffManager.Core;
using StaffManager.Data.Entities;

namespace StaffManager.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService service;
        public DepartmentController(IDepartmentService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get collection of all departments.
        /// </summary>
        /// <returns>Collection of departments.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> Get()
        {
            try
            {
                return Ok(await service.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(PostgreCustomExceptionHandler.Handle(ex));
            }
        }
        
        /// <summary>
        /// Create department.
        /// </summary>
        /// <param name="department">Department to create.</param>
        /// <returns>Created department.</returns>
        [HttpPost]
        public async Task<ActionResult<Department>> Create(Department department)
        {
            try
            {
                var result = await service.CreateAsync(department);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(PostgreCustomExceptionHandler.Handle(ex));
            }
        }

        /// <summary>
        /// Update department.
        /// </summary>
        /// <param name="department">Department to update.</param>
        /// <returns>Updated department.</returns>
        [HttpPut]
        public async Task<ActionResult<Department>> Update(Department department)
        {
            try
            {
                var result = await service.UpdateAsync(department);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(PostgreCustomExceptionHandler.Handle(ex));
            }
        }

        /// <summary>
        /// Delete department.
        /// </summary>
        /// <param name="department">Department to delete.</param>
        /// <returns>Deleted department.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(Department department)
        {
            try
            {
                var result = await service.DeleteAsync(department);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message ?? ex.Message);
            }
        }
    }
}
