using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using 设备管理系统.Models;
using System.Configuration;

namespace 设备管理系统.DAL
{
    /// <summary>
    /// SQL Server 数据库操作类
    /// </summary>
    public class SqlHelper
    {
        /// <summary>
        /// 单例
        /// </summary>

        public static SqlHelper Instance = new Lazy<SqlHelper>(() => new SqlHelper()).Value;
        public string ConnectionString { get; }
        public SqlConnection SqlConnection { get; }
        public SqlHelper()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["EquipmentDBConnectionString"].ConnectionString;
            SqlConnection = new SqlConnection(ConnectionString);
        }

        public DataSet ExecuteDataset(string commandText, params SqlParameter[] parameters)
        {
            return ExecuteDataset(SqlConnection, CommandType.Text, commandText, parameters);
        }

        public DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] parameters)
        {
            if (connection == null) throw new ArgumentNullException("SqlConnection不能为空");
            SqlCommand sqlCommand = connection.CreateCommand();
            PrepareCommand(sqlCommand, commandType, commandText, parameters);
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
            {
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return dataSet;
            }
        }

        //预处理      

        private void PrepareCommand(SqlCommand sqlCommand, CommandType commandType, string commandText, SqlParameter[] parameters = null)
        {
            if (SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();
            }
            sqlCommand.CommandText = commandText;
            sqlCommand.CommandType = CommandType.Text;

            if (parameters != null && parameters.Length > 0)
            {
                AttchParameters(sqlCommand, parameters);
            }
        }

        private void AttchParameters(SqlCommand sqlCommand, SqlParameter[] parameters)
        {
            if (sqlCommand == null) throw new ArgumentNullException("SqlCommand不能为空");
            if (parameters == null) throw new ArgumentNullException("parameters");

            foreach (var item in parameters)
            {
                if (item != null)
                {
                    if (item.Value == null)
                    {
                        item.Value = DBNull.Value;
                    }

                    sqlCommand.Parameters.Add(item);
                }
            }
        }

        //DataSet转换为List<T>数组

        public List<T> DataSetToList<T>(DataSet dataSet, int index = 0)
        {
            List<T> list = new List<T>(); //初始化了一个空的返回数组

            //断言
            if (dataSet == null || dataSet.Tables.Count <= 0)
            {
                return list;
            }

            if (index > dataSet.Tables.Count - 1)
            {
                return list;
            }

            if (index < 0)
            {
                return list;
            }



            //开始转换成List<T>数组
            DataTable dataTable = dataSet.Tables[index];
            for (int j = 0; j < dataTable.Rows.Count; j++)
            {
                T t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertyInfos = t.GetType().GetProperties();
                foreach (var p in propertyInfos)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        if (p.Name.Equals(dataTable.Columns[i].ColumnName))
                        {
                            if (dataTable.Rows[j][i] != DBNull.Value)
                            {
                                //将当前行的当前列的值转换给t.p
                                try
                                {
                                    p.SetValue(t, Convert.ChangeType(dataTable.Rows[j][i], p.PropertyType), null);
                                }
                                catch
                                {

                                }
                            }
                            else
                            {

                            }
                        }
                    }
                }
                list.Add(t);
            }

            return list;
        }

        //执行Sql语句（Insert Update Delete）
        public int ExecuteNonQuery(string commandText, params SqlParameter[] parameters)
        {
            if (SqlConnection == null) throw new ArgumentNullException("SqlConnection不能为空");
            SqlCommand sqlCommand = SqlConnection.CreateCommand();
            PrepareCommand(sqlCommand, CommandType.Text, commandText, parameters);
            int count = sqlCommand.ExecuteNonQuery();
            return count;
        }
    }
}
