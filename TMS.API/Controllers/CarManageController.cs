using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.BaseInfo;
using Microsoft.AspNetCore.Authorization;//JWT

namespace TMS.API.Controllers
{
    /// <summary>
    /// 车辆管理
    /// </summary>
    [ApiController]
    //[Authorize]
    [Route("CarManageApi")]
    public class CarManageController : Controller
    {
        private ILogger<CarManageController> _logger;//日志
        private ICarManageRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public CarManageController(ILogger<CarManageController> logger, ICarManageRepository _dal)
        {
            _logger = logger;//日志
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CarManageIndex")]
        public IActionResult CarManageIndex()
        {
            try
            {
                List<CarManage> list = dal.Show();
                _logger.LogInformation("======{p1}======{p2}======", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff 成功"), list.Count.ToString());
                return Json(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "##{p1}## CarManageController-CarManageIndex() Exception", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss 报错啦！！！"));
                return Json("{'result':'error'}");
                throw;
            }
            
        }
    }
}
