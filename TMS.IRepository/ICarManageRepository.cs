using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.BaseInfo;

namespace TMS.IRepository
{
    public interface ICarManageRepository
    {
        List<CarManage> Show();
    }
}
