using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.BaseInfo;

namespace TMS.Repository
{
    public class CarManageRepository:ICarManageRepository
    {
        /// <summary>
        /// 车辆管理显示
        /// </summary>
        /// <returns></returns>
        public List<CarManage> Show()
        {
            using (IDbConnection conn = new MySqlConnection(DbFactory.DbConString))
            {
                return conn.Query<CarManage>("select * from CarManage").ToList();
            }
        }
    }
}
