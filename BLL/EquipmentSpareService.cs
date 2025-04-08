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
    internal class EquipmentSpareService : IService<EquipmentSpare>
    {
        public int Delete(EquipmentSpare entity)
        {
            if (entity == null) { return -1; }

            string sql = "Delete EquipmentSpare where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", entity.Id),
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }

        public List<EquipmentSpare> GetAll()
        {
            //string sql = @"SELECT [Id],[EquipmentName],[Name],[Brand],[Specification],[AllocationNumber],[MaxNumber],[MinNumber],[ProcurementCycle],[SpareNumber],[Picture],[InsertDate] FROM [EquipmentSpare]";
            string sql = @"Select e.Id,e.EquipmentName,e.Name ,e.Brand,e.Specification,e.AllocationNumber,e.MaxNumber,e.MinNumber,e.ProcurementCycle,s.SpareNumber ,e.Picture,e.Insertdate   from EquipmentSpare e inner join Spare s on 
                        e.Name = s.Name and e.Brand = s.Brand and e.Specification = s.Specification";
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, null);
            List<EquipmentSpare> list = SqlHelper.Instance.DataSetToList<EquipmentSpare>(dataSet);
            return list;
        }

        public List<EquipmentSpare> Where(Equipment entity )
        {
            //string sql = @"SELECT [Id],[EquipmentName],[Name],[Brand],[Specification],[AllocationNumber],[MaxNumber],[MinNumber],[ProcurementCycle],[SpareNumber],[Picture],[InsertDate] FROM [EquipmentSpare] Where EquipmentSpare.EquipmentName = @EquipmentName ";
            string sql = @"WITH FilteredData AS (
    SELECT 
        t.Id,
        t.EquipmentName,
        t.Name,
        t.Brand,
        t.Specification,
        t.AllocationNumber,
        t.MaxNumber,
        t.MinNumber,
        t.ProcurementCycle,
        s.SpareNumber AS SpareNumber,  -- 来自Spare表
        t.Picture,
        t.Insertdate,
        COUNT(*) OVER (PARTITION BY t.Name, t.Brand, t.Specification) AS 组合计数
    FROM 
        EquipmentSpare t
    LEFT JOIN  -- 使用LEFT JOIN确保主表记录不会丢失
        Spare s ON t.Name = s.Name and t.Brand = s.Brand and t.Specification =s.Specification  -- 请替换为实际的关联条件
    WHERE 
        t.EquipmentName = @EquipmentName
)
SELECT 
    Id, EquipmentName, Name, Brand, Specification, AllocationNumber, 
    MaxNumber, MinNumber, ProcurementCycle, SpareNumber, Picture, Insertdate
FROM 
    FilteredData
WHERE 
    组合计数 = 1  -- 确保3、4、5列组合唯一
ORDER BY 
    Name, Brand, Specification;  -- 可选排序 ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EquipmentName", entity.Name),
            };
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, parameters);
            List<EquipmentSpare> list = SqlHelper.Instance.DataSetToList<EquipmentSpare>(dataSet);
            return list;
        }




        public int Insert(EquipmentSpare entity)
        {
            int count = -1;
            if (entity == null) { return count; }
            if (string.IsNullOrEmpty(entity.Name)) { return count; }

            entity.InsertDate = DateTime.Now;

            string sql = $"Insert Into EquipmentSpare (EquipmentName,Name,Brand,Specification,AllocationNumber,MaxNumber,MinNumber,ProcurementCycle,SpareNumber,Picture,InsertDate) Values (@EquipmentName,@Name,@Brand,@Specification,@AllocationNumber,@MaxNumber,@MinNumber,@ProcurementCycle,@SpareNumber,@Picture,@InsertDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EquipmentName", entity.EquipmentName),
                new SqlParameter("@Name", entity.Name),
                new SqlParameter("@Brand", entity.Brand),
                new SqlParameter("@Specification", entity.Specification),
                new SqlParameter("@AllocationNumber", entity.AllocationNumber),               
                new SqlParameter("@MaxNumber", entity.MaxNumber),
                new SqlParameter("@MinNumber", entity.MinNumber),
                new SqlParameter("@ProcurementCycle", entity.ProcurementCycle),
                new SqlParameter("@SpareNumber", entity.SpareNumber),
                new SqlParameter("@Picture", entity.Picture),
                new SqlParameter("@InsertDate", entity.InsertDate),
            };
            count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);

            return count;
        }

        public int Update(EquipmentSpare entity)
        {
            if (entity == null) { return -1; }

            string sql = @"Update EquipmentSpare set EquipmentName = @EquipmentName,
                                            Name = @Name,
                                            Brand = @Brand,
                                            Specification = @Specification, 
                                            AllocationNumber = @AllocationNumber,
                                            MaxNumber = @MaxNumber,
                                            MinNumber = @MinNumber,
                                            ProcurementCycle = @ProcurementCycle,
                                            SpareNumber = @SpareNumber,
                                            Picture = @Picture
                                            Where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",entity.Id),
                new SqlParameter("@EquipmentName", entity.EquipmentName),
                new SqlParameter("@Name", entity.Name),
                new SqlParameter("@Brand", entity.Brand),
                new SqlParameter("@Specification", entity.Specification),
                new SqlParameter("@AllocationNumber", entity.AllocationNumber),               
                new SqlParameter("@MaxNumber", entity.MaxNumber),
                new SqlParameter("@MinNumber", entity.MinNumber),
                new SqlParameter("@ProcurementCycle", entity.ProcurementCycle),
                new SqlParameter("@SpareNumber", entity.SpareNumber),
                new SqlParameter("@Picture", entity.Picture),
                
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }

        public List<EquipmentSpare> Search(string entity)
        {
            string sql = @"SELECT *FROM (Select e.Id,e.EquipmentName,e.Name ,e.Brand,e.Specification,e.AllocationNumber,e.MaxNumber,e.MinNumber,e.ProcurementCycle,s.SpareNumber ,e.Picture,e.Insertdate   from EquipmentSpare e inner join Spare s on 
                        e.Name = s.Name and e.Brand = s.Brand and e.Specification = s.Specification )a
                           WHERE                               
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
            List<EquipmentSpare> list = SqlHelper.Instance.DataSetToList<EquipmentSpare>(dataSet);
            return list;
        }
    }
    
}
