using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.BaseInfo;
using TMS.Common.DB;

namespace TMS.Repository
{
    public class CarManageRepository:ICarManageRepository
    {
        /// <summary>
        /// 车辆管理显示
        /// </summary>
        /// <returns></returns>
        public List<CarManage> CarShow()
        {
            string sql = $"select * from CarManage";
            return MySqlDapper.DapperQuery<CarManage>(sql, "");
        }

        /// <summary>
        /// 新增汽车
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public bool AddCarManage(CarManage car)
        {
            string sql = "insert into CarManage values(null,@FactoryPlate,@CarPlate,@DriverName,@SubordinateCompany,@Cartype,@CarColor,@BuyDate,@OperationPlate,@InsuranceExpriration,@AnnualInspection,@UpKeepKm,@CarPicture,@UpKeepKmPicture)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @FactoryPlate = car.FactoryPlate,
                @CarPlate = car.CarPlate,
                @DriverName = car.DriverName,
                @SubordinateCompany = car.SubordinateCompany,
                @Cartype = car.Cartype,
                @CarColor = car.CarColor,
                @BuyDate = car.BuyDate,
                @OperationPlate = car.OperationPlate,
                @InsuranceExpriration = car.InsuranceExpriration,
                @AnnualInspection = car.AnnualInspection,
                @UpKeepKm = car.UpKeepKm,
                @CarPicture = car.CarPicture,
                @UpKeepKmPicture = car.UpKeepKmPicture            
            });
        }


        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="CarManageId"></param>
        /// <returns></returns>
        public bool DeleteCar(int CarManageId)
        {
            string sql = "DELETE FROM CarManage WHERE CarManageId IN (@CarManageId)";
            return MySqlDapper.DapperExcute(sql, new { @CarManageId = CarManageId });
        }


        /// <summary>
        /// 反填改职位
        /// </summary>
        /// <param name="CarManageId"></param>
        /// <returns></returns>
        public CarManage EditCarManage(int CarManageId)
        {
            string sql = $"select * from CarManage where CarManageId={CarManageId}";
            return MySqlDapper.DapperQuery<CarManage>(sql, new { @CarManageId = CarManageId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改该汽车
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool UpdateCar(CarManage car)
        {
            string sql = "UPDATE CarManage SET FactoryPlate = @FactoryPlate,CarPlate = @CarPlate,DriverName = @DriverName,SubordinateCompany =@SubordinateCompany,Cartype = @Cartype,CarColor = @CarColor,BuyDate = @BuyDate,OperationPlate = @OperationPlate,InsuranceExpriration = @InsuranceExpriration,AnnualInspection = @AnnualInspection,UpKeepKm = @UpKeepKm,CarPicture = @CarPicture,UpKeepKmPicture = @UpKeepKmPicture WHERE CarManageId=@CarManageId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @CarManageId = car.CarManageId,
                @FactoryPlate = car.FactoryPlate,
                @CarPlate = car.CarPlate,
                @DriverName = car.DriverName,
                @SubordinateCompany = car.SubordinateCompany,
                @Cartype = car.Cartype,
                @CarColor = car.CarColor,
                @BuyDate = car.BuyDate,
                @OperationPlate = car.OperationPlate,
                @InsuranceExpriration = car.InsuranceExpriration,
                @AnnualInspection = car.AnnualInspection,
                @UpKeepKm = car.UpKeepKm,
                @CarPicture = car.CarPicture,
                @UpKeepKmPicture = car.UpKeepKmPicture
            });
        }


    }
}
