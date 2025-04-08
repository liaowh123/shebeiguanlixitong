using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows;
using 设备管理系统.DAL;
using 设备管理系统.Models;

namespace 设备管理系统.BLL
{   
    public class EquipmentOfAreaProcessService : IService<EquipmentOfAreaProcess>
    {
        public int Delete(EquipmentOfAreaProcess entity)
        {
            if(entity == null) { return -1; }

            string sql = "Delete EquipmentOfAreaProcess where AreaName = @AreaName";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AreaName", entity.AreaName),
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }

        public int DeleteProcess(EquipmentOfAreaProcess entity)
        {
            if (entity == null) { return -1; }

            string sql = "Delete EquipmentOfAreaProcess where ProcessName = @ProcessName  and AreaName = @AreaName";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AreaName", entity.AreaName),
                new SqlParameter("@ProcessName", entity.ProcessName),
                
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;

        }


        public int DeleteEquipment(EquipmentOfAreaProcess entity)
        {
            if (entity == null ) { return -1; }

            string sql = "Delete EquipmentOfAreaProcess where Id = @Id ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", entity.Id),
                //new SqlParameter("@AreaName", entity.AreaName),
                //new SqlParameter("@ProcessName", entity.ProcessName),
                //new SqlParameter("@EquipmentName", entity.EquipmentName),
                //new SqlParameter("@EquipmentNumber", entity.EquipmentNumber),
                
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;

        }



        public List<EquipmentOfAreaProcess> GetAll()
        {
            string sql = @"Select  * From EquipmentOfAreaProcess";
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


            string sql = @"Select DISTINCT
                          EquipmentOfAreaProcess.AreaName                               
                          From EquipmentOfAreaProcess";
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, null);
            List<EquipmentOfAreaProcess> list = SqlHelper.Instance.DataSetToList<EquipmentOfAreaProcess>(dataSet);
            return list;
        }

        /// <summary>
        /// 查询某一个区域
        /// </summary>
        /// <param name="AreaId"></param>
        /// <returns></returns>
        public List<EquipmentOfAreaProcess> Where(string AreaName)
        {
            //string sql = @"Select EquipmentOfAreaProcess.Id,
            //                EquipmentOfAreaProcess.AreaName,
            //                EquipmentOfAreaProcess.ProcessName,   
            //                EquipmentOfAreaProcess.EquipmentNumber, 
            //                EquipmentOfAreaProcess.EquipmentName,
            //                EquipmentOfAreaProcess.EquipmentComment                            
            //              From EquipmentOfAreaProcess 
            //              Where EquipmentOfAreaProcess.AreaName = @AreaName ";
            string sql = @"Select DISTINCT
                          EquipmentOfAreaProcess.ProcessName                               
                          From EquipmentOfAreaProcess
                          Where EquipmentOfAreaProcess.AreaName = @AreaName ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AreaName", AreaName),
                
            };

            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, parameters);

            List<EquipmentOfAreaProcess> list = SqlHelper.Instance.DataSetToList<EquipmentOfAreaProcess>(dataSet);

            return list;
        }

        /// <summary>
        /// 查询某一个区域内的工序
        /// </summary>
        /// <param name="AreaId"></param>
        /// <returns></returns>
        public List<EquipmentOfAreaProcess> WhereProcess(string AreaName)
        {
            //string sql = @"Select EquipmentOfAreaProcess.Id,
            //                EquipmentOfAreaProcess.AreaName,
            //                EquipmentOfAreaProcess.ProcessName,   
            //                EquipmentOfAreaProcess.EquipmentNumber, 
            //                EquipmentOfAreaProcess.EquipmentName,
            //                EquipmentOfAreaProcess.EquipmentComment                            
            //              From EquipmentOfAreaProcess 
            //              Where EquipmentOfAreaProcess.AreaName = @AreaName  ";

            string sql = @"Select DISTINCT
                          EquipmentOfAreaProcess.ProcessName                               
                          From EquipmentOfAreaProcess
                          Where EquipmentOfAreaProcess.AreaName = @AreaName ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AreaName", AreaName),

            };

            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, parameters);

            List<EquipmentOfAreaProcess> list = SqlHelper.Instance.DataSetToList<EquipmentOfAreaProcess>(dataSet);

            return list;
        }




        /// <summary>
        /// 查询某一个区域工序内的设备
        /// </summary>
        /// <param name="AreaId"></param>
        /// <returns></returns>
        public List<EquipmentOfAreaProcess> WhereEquipment(string AreaName,string ProcessName)
        {
            string sql = @"Select EquipmentOfAreaProcess.Id,
                            EquipmentOfAreaProcess.AreaName,
                            EquipmentOfAreaProcess.ProcessName,   
                            EquipmentOfAreaProcess.EquipmentNumber, 
                            EquipmentOfAreaProcess.EquipmentName,
                            EquipmentOfAreaProcess.EquipmentComment                            
                          From EquipmentOfAreaProcess 
                          Where EquipmentOfAreaProcess.AreaName = @AreaName and ProcessName = @ProcessName ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AreaName", AreaName),
                new SqlParameter("@ProcessName", ProcessName),
            };

            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, parameters);

            List<EquipmentOfAreaProcess> list = SqlHelper.Instance.DataSetToList<EquipmentOfAreaProcess>(dataSet);

            return list;
        }


        public int Insert(EquipmentOfAreaProcess entity)
        {
            int count = -1;
            if (entity == null) { return count; }
            if (entity.AreaName == null ) { return count; }
            //if (HasValue(entity) > 0) return 0;
            entity.InsertDate = DateTime.Now;

            string sql = $"Insert Into EquipmentOfAreaProcess (AreaName,ProcessName,EquipmentNumber,EquipmentName,EquipmentComment,InsertDate) Values (@AreaName,@ProcessName,@EquipmentNumber,@EquipmentName,@EquipmentComment,@InsertDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AreaName", entity.AreaName),
                new SqlParameter("@ProcessName", entity.ProcessName),
                new SqlParameter("@EquipmentNumber", entity.EquipmentNumber),
                new SqlParameter("@EquipmentName", entity.EquipmentName),
                new SqlParameter("@EquipmentComment", entity.EquipmentComment),
                new SqlParameter("@InsertDate", entity.InsertDate),
            };
            count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);

            return count;
        }

        public int InsertProcess(EquipmentOfAreaProcess entity)
        {
            int count = -1;
            if (entity == null) { return count; }
            if (entity.ProcessName == null) { return count; }
            //if (HasValue(entity) > 0) return 0;
            entity.InsertDate = DateTime.Now;

            string sql = $"Insert Into EquipmentOfAreaProcess (AreaName,ProcessName,EquipmentNumber,EquipmentName,EquipmentComment,InsertDate) Values (@AreaName,@ProcessName,@EquipmentNumber,@EquipmentName,@EquipmentComment,@InsertDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AreaName", entity.AreaName),
                new SqlParameter("@ProcessName", entity.ProcessName),
                new SqlParameter("@EquipmentNumber", entity.EquipmentNumber),
                new SqlParameter("@EquipmentName", entity.EquipmentName),
                new SqlParameter("@EquipmentComment", entity.EquipmentComment),
                new SqlParameter("@InsertDate", entity.InsertDate),
            };
            count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);

            return count;
        }

        public int InsertEquipment(EquipmentOfAreaProcess entity)
        {
            int count = -1;
            if (entity == null) { return count; }
            if ((entity.AreaName == null)|| (entity.ProcessName == null)) { return count; }
            //if (HasValue(entity) > 0) return 0;
            entity.InsertDate = DateTime.Now;

            string sql = $"Insert Into EquipmentOfAreaProcess (AreaName,ProcessName,EquipmentNumber,EquipmentName,EquipmentComment,InsertDate) Values (@AreaName,@ProcessName,@EquipmentNumber,@EquipmentName,@EquipmentComment,@InsertDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AreaName", entity.AreaName),
                new SqlParameter("@ProcessName", entity.ProcessName),
                new SqlParameter("@EquipmentNumber", entity.EquipmentNumber),
                new SqlParameter("@EquipmentName", entity.EquipmentName),
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
