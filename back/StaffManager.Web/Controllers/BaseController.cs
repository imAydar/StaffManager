using Microsoft.AspNetCore.Mvc;
using StaffManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManager.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Overrided BadRequest method to have some additional logic.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override BadRequestObjectResult BadRequest(object value) =>
            base.BadRequest(PostgreCustomExceptionHandler.Handle((Exception)value));
    }
}
