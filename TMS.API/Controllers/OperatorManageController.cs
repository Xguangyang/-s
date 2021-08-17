using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 操作员管理
    /// </summary>
    public class OperatorManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
