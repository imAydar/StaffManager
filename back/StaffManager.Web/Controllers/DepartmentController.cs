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

        [HttpGet]
        public async Task<IActionResult> Get()
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
        [HttpPost]
        public async Task<IActionResult> Create(Department entity)
        {
            try
            {
                var result = await service.CreateAsync(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(PostgreCustomExceptionHandler.Handle(ex));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Department entity)
        {
            try
            {
                var result = await service.UpdateAsync(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(PostgreCustomExceptionHandler.Handle(ex));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Department entity)
        {
            try
            {
                var result = await service.DeleteAsync(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message ?? ex.Message);
            }
        }
    }
}
