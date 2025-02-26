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
    public class EquipmentOfAreaProcessService : IService<EquipmentOfAreaProcess>
    {
        public int Delete(EquipmentOfAreaProcess entity)
        {
            if(entity == null) { return -1; }

            string sql = "Delete EquipmentOfAreaProcess where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", entity.Id),
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }

        public List<EquipmentOfAreaProcess> GetAll()
        {
            string sql = @"Select * From EquipmentOfAreaProcess";
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, null);
            List<EquipmentOfAreaProcess> list = SqlHelper.Instance.DataSetToList<EquipmentOfAreaProcess>(dataSet);
            return list;
        }

        /// <summary>
        /// 查询区域名称
        /// </summary>
        /// <returns></returns>
        public List<EquipmentOfAreaProcess> GetAllWithArea()
        {
            string sql = @"Select EquipmentOfAreaProcess.Id,
                                  EquipmentOfAreaProcess.AreaId,
                                  EquipmentOfAreaProcess.ProcessId, 
                                  EquipmentOfAreaProcess.EquipmentId, 
                                  EquipmentOfAreaProcess.EquipmentComment 
                                  EquipmentOfAreaProcess.Insertdate
                          From EquipmentOfAreaProcess,Area,Process
                          Where EquipmentOfAreaProcess.SubjectId = Area.Id";
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, null);
            List<EquipmentOfAreaProcess> list = SqlHelper.Instance.DataSetToList<EquipmentOfAreaProcess>(dataSet);
            return list;
        }

        /// <summary>
        /// 查询某一个区域
        /// </summary>
        /// <param name="AreaId"></param>
        /// <returns></returns>
        public List<EquipmentOfAreaProcess> Where(int AreaId)
        {
            string sql = @"Select EquipmentOfAreaProcess.Id,
                                  EquipmentOfAreaProcess.AreaId,
                                  EquipmentOfAreaProcess.ProcessId, 
                                  EquipmentOfAreaProcess.InsertDate,                                  
                          From EquipmentOfAreaProcess,Area,Process 
                          Where EquipmentOfAreaProcess.AreaId = Area.Id";
            //SqlParameter[] parameters = new SqlParameter[]
            //{
            //    new SqlParameter("@TranscriptId", AreaId),
            //};

            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, null);

            List<EquipmentOfAreaProcess> list = SqlHelper.Instance.DataSetToList<EquipmentOfAreaProcess>(dataSet);

            return list;
        }

        public int Insert(EquipmentOfAreaProcess entity)
        {
            int count = -1;
            if (entity == null) { return count; }
            if (entity.AreaId <= 0 || entity.Id <= 0) { return count; }
            //if (HasValue(entity) > 0) return 0;
            entity.InsertDate = DateTime.Now;

            string sql = $"Insert Into EquipmentOfAreaProcess (AreaId,ProcessId,EquipmentId,EquipmentComment,InsertDate) Values (@AreaId,@ProcessId,@EquipmentId,@EquipmentComment,@InsertDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AreaId", entity.AreaId),
                new SqlParameter("@ProcessId", entity.ProcessId),
                new SqlParameter("@EquipmentId", entity.EquipmentId),
                new SqlParameter("@EquipmentComment", entity.EquipmentComment),
                new SqlParameter("@InsertDate", entity.InsertDate),
            };
            count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);

            return count;
        }

        public int Update(EquipmentOfAreaProcess entity)
        {
            throw new NotImplementedException();
        }

        //private int HasValue(EquipmentOfAreaProcess entity)
        //{
        //    string sql = $"Select * From Detail Where TranscriptId = @TranscriptId And SubjectId = @SubjectId";
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@TranscriptId", entity.TranscriptId),
        //        new SqlParameter("@SubjectId", entity.SubjectId),
        //    };

        //    DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, parameters);

        //    List<EquipmentOfAreaProcess> list = SqlHelper.Instance.DataSetToList<EquipmentOfAreaProcess>(dataSet);

        //    return list.Count;
        //}
    }
}
