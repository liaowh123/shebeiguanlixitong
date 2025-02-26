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
    public class EquipmentService : IService<Equipment>
    {
        public int Delete(Equipment entity)
        {
            if (entity == null) { return -1; }

            string sql = "Delete Equipment where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", entity.Id),
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }

        public List<Equipment> GetAll()
        {
            string sql = @"SELECT [Id] ,[Name] ,[EquipmentNumber],[AssetNumber] ,[InsertDate] ,[Comment] FROM [Equipment]";
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, null);
            List<Equipment> list = SqlHelper.Instance.DataSetToList<Equipment>(dataSet);
            return list;
        }

        public int Insert(Equipment entity)
        {
            int count = -1;
            if (entity == null) { return count; }
            if (string.IsNullOrEmpty(entity.Name)) { return count; }

            entity.InsertDate = DateTime.Now;

            string sql = $"Insert Into Equipment (Name,EquipmentNumber,AssetNumber,InsertDate,Comment) Values (@Name,@EquipmentNumber,@AssetNumber,@InsertDate,@Comment)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", entity.Name),
                new SqlParameter("@EquipmentNumber", entity.EquipmentNumber),
                new SqlParameter("@AssetNumber", entity.AssetNumber),
                new SqlParameter("@InsertDate", entity.InsertDate),
                new SqlParameter("Comment", entity.Comment),
            };
            count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);

            return count;
        }

        public int Update(Equipment entity)
        {
            if (entity == null) { return -1; }

            string sql = @"Update Equipment set Name = @Name,EquipmentNumber = @EquipmentNumber,AssetNumber = @AssetNumber,Comment = @Comment  Where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name",entity.Name),
                new SqlParameter("@EquipmentNumber", entity.EquipmentNumber),
                new SqlParameter("@AssetNumber", entity.AssetNumber),
                new SqlParameter("@Id",entity.Id),
                new SqlParameter("Comment", entity.Comment),
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }
    }
}
