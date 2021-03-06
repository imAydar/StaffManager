using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffManager.Core.Services;
using StaffManager.Core;
using StaffManager.Data.Entities;
using StaffManager.Infrastructure.Interfaces;
using StaffManager.Infrastructure.Models;

namespace StaffManager.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService service;
        public DepartmentController(IDepartmentService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get collection of all DepartmentDtos.
        /// </summary>
        /// <returns>Collection of DepartmentDtos.</returns>
        [HttpGet]
        public ActionResult<IAsyncEnumerable<DepartmentDto>> Get()
        {
            try
            {
                return Ok(service.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        /// <summary>
        /// Create DepartmentDto.
        /// </summary>
        /// <param name="DepartmentDto">DepartmentDto to create.</param>
        /// <returns>Created DepartmentDto.</returns>
        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> Create(DepartmentDto DepartmentDto)
        {
            try
            {
                var result = await service.CreateAsync(DepartmentDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Update DepartmentDto.
        /// </summary>
        /// <param name="DepartmentDto">DepartmentDto to update.</param>
        /// <returns>Updated DepartmentDto.</returns>
        [HttpPut]
        public async Task<ActionResult<DepartmentDto>> Update(DepartmentDto DepartmentDto)
        {
            try
            {
                var result = await service.UpdateAsync(DepartmentDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Delete DepartmentDto.
        /// </summary>
        /// <param name="DepartmentDto">DepartmentDto to delete.</param>
        /// <returns>Deleted DepartmentDto.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(DepartmentDto DepartmentDto)
        {
            try
            {
                var result = await service.DeleteAsync(DepartmentDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }

    internal interface IDepartmentDtoService
    {
    }
}
