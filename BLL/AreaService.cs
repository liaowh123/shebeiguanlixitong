using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using 设备管理系统.DAL;
using 设备管理系统.Models;

namespace 设备管理系统.BLL
{
    public class AreaService : IService<Area>
    {
        public int Delete(Area entity)
        {
            if (entity == null) { return -1; }

            string sql = "Delete Area where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", entity.Id),
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }

        public List<Area> GetAll()
        {
            string sql = @"SELECT [Id] ,[Name] ,[InsertDate] FROM [Area]";
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, null);
            List<Area> list = SqlHelper.Instance.DataSetToList<Area>(dataSet);
            return list;
        }

        public int Insert(Area entity)
        {
            int count = -1;
            if (entity == null) { return count; }
            if (string.IsNullOrEmpty(entity.Name)) { return count; }

            entity.InsertDate = DateTime.Now;

            string sql = $"Insert Into Area (Name,InsertDate) Values (@Name,@InsertDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", entity.Name),
                new SqlParameter("@InsertDate", entity.InsertDate),
            };
            count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);

            return count;
        }

        public int Update(Area entity)
        {
            if (entity == null) { return -1; }

            string sql = @"Update Area set Name = @Name Where Id = @Id";
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
