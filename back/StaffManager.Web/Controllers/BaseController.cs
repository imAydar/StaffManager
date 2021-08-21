using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManager.Web.Controllers
{
    public class BaseController : Controller
    {
        public override BadRequestObjectResult BadRequest(object value)
        {
            return base.BadRequest(value);
        }
    }
}
