using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.Redis;

namespace TMS.API.Controllers
{
    /// <summary>
    /// redis测试
    /// </summary>
    [Route("api/redis")]
    [ApiController]
    public class RedisController : Controller
    {
        private readonly IDatabase _redis;
        public RedisController(RedisHelper client)
        {
            _redis = client.GetDatabase();
        }

        [HttpGet]
        public string Get()
        {
            // 往Redis里面存入数据
            _redis.StringSet("Name", "Tom");
            // 从Redis里面取数据
            string name = _redis.StringGet("Name");
            return name;
        }
    }
}
