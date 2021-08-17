using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;//JWT
using System.Security.Claims;//JWT
using Microsoft.IdentityModel.Tokens;//JWT Token
using System.Text;
using Microsoft.AspNetCore.Authorization;//授权
using System.Text.Json;
using TMS.IRepository;
using Microsoft.Extensions.Logging;
using TMS.Model.Entity.Set;
using TMS.Common.JWT;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 用户基本信息
    /// </summary>
    [ApiController]
    //[Authorize]
    [Route("UsersApi")]
    public class UsersController : Controller
    {
        private IUsersRepository dal;
        private readonly JWTService _jwt;//Jwt帮助类
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public UsersController(IUsersRepository _dal,JWTService jwt)
        {
            dal = _dal;
            _jwt = jwt;
        }

        /// <summary>
        /// 操作员列表（显示）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CarManageIndex")]
        public IActionResult CarManageIndex(string i)
        {
            try
            {
                List<OperatorManage> list = dal.Show();
                var jwt = _jwt.GetToken(i);
                return Json(jwt);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
