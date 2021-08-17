using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.Set;
using TMS.IRepository;
using TMS.Model.Entity.BaseInfo;
using Dapper;

namespace TMS.Repository
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        public List<OperatorManage> Show()
        {
            using (IDbConnection conn = new MySqlConnection(DbFactory.DbConString))
            {
                return conn.Query<OperatorManage>("select * from OperatorManage").ToList();
            }
        }
    }
}
