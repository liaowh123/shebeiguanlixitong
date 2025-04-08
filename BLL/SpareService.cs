using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设备管理系统.DAL;
using 设备管理系统.Models;

namespace 设备管理系统.BLL
{
    partial class SpareService : IService<Spare>
    {
        public int Delete(Spare entity)
        {
            if (entity == null) { return -1; }

            string sql = "Delete Spare where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", entity.Id),
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }

        public List<Spare> GetAll()
        {
            string sql = @"SELECT [Id] ,[MaterialCode] ,[Name] ,[Brand] ,[Specification] ,[SpareNumber] ,[Picture] ,[First_level] ,[Second_level] ,[Third_level] ,[InsertDate] FROM [Spare]";
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, null);
            List<Spare> list = SqlHelper.Instance.DataSetToList<Spare>(dataSet);
            return list;
        }

        public int Insert(Spare entity)
        {
            int count = -1;
            if (entity == null) { return count; }
            if (string.IsNullOrEmpty(entity.Name)) { return count; }

            entity.InsertDate = DateTime.Now;

            string sql = $"Insert Into Spare (MaterialCode,Name,Brand,Specification,SpareNumber,Picture,First_level,Second_level,Third_level,InsertDate) Values (@MaterialCode,@Name,@Brand,@Specification,@SpareNumber,@Picture,@First_level,@Second_level,@Third_level,@InsertDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaterialCode", entity.MaterialCode),
                new SqlParameter("@Name", entity.Name),
                new SqlParameter("@Brand", entity.Brand),
                new SqlParameter("@Specification", entity.Specification),
                new SqlParameter("@SpareNumber", entity.SpareNumber),
                new SqlParameter("@Picture", entity.Picture),
                new SqlParameter("@First_level", entity.First_level),
                new SqlParameter("@Second_level", entity.Second_level),
                new SqlParameter("@Third_level", entity.Third_level),
                new SqlParameter("@InsertDate", entity.InsertDate),
            };
            count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);

            return count;
        }

        public int Update(Spare entity)
        {
            if (entity == null) { return -1; }

            string sql = @"Update Spare set MaterialCode = @MaterialCode,Name = @Name,Brand = @Brand,Specification = @Specification,SpareNumber = @SpareNumber,First_level = @First_level,Second_level = @Second_level,Third_level = @Third_level Where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",entity.Id),
                new SqlParameter("@MaterialCode",entity.MaterialCode),
                new SqlParameter("@Name",entity.Name),
                new SqlParameter("@Brand",entity.Brand),
                new SqlParameter("@Specification",entity.Specification),
                new SqlParameter("@SpareNumber",entity.SpareNumber),
                new SqlParameter("@First_level",entity.First_level),
                new SqlParameter("@Second_level",entity.Second_level),
                new SqlParameter("@Third_level",entity.Third_level),              
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }

        public List<Spare> Search(string entity)
        {           
            string sql = @"SELECT *FROM Spare 
                           WHERE 
                                MaterialCode LIKE @SearchTerm1 OR
                                Name LIKE @SearchTerm1 OR
                                Brand LIKE @SearchTerm1 OR
                                Specification LIKE @SearchTerm1";
            // 在用户输入的 entity 前后添加 % 通配符
            string searchTermWithWildcards = $"%{entity}%";
            SqlParameter[] parameters = new SqlParameter[]
           {
                new SqlParameter("@SearchTerm1",searchTermWithWildcards),               
           };
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, parameters);
            List<Spare> list = SqlHelper.Instance.DataSetToList<Spare>(dataSet);
            return list;
        }
    }
}
