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
    public class ProcessService : IService<Process>
    {
        public int Delete(Process entity)
        {
            if (entity == null) { return -1; }

            string sql = "Delete Process where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", entity.Id),
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }

        public List<Process> GetAll()
        {
            string sql = @"SELECT [Id] ,[Name] ,[InsertDate] FROM [Process]";
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, null);
            List<Process> list = SqlHelper.Instance.DataSetToList<Process>(dataSet);
            return list;
        }

        public int Insert(Process entity)
        {
            int count = -1;
            if (entity == null) { return count; }
            if (string.IsNullOrEmpty(entity.Name)) { return count; }

            entity.InsertDate = DateTime.Now;

            string sql = $"Insert Into Process (Name,InsertDate) Values (@Name,@InsertDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", entity.Name),
                new SqlParameter("@InsertDate", entity.InsertDate),
            };
            count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);

            return count;
        }

        public int Update(Process entity)
        {
            if (entity == null) { return -1; }

            string sql = @"Update Process set Name = @Name Where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name",entity.Name),
                new SqlParameter("@Id",entity.Id),
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }
    }
}
