using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 设备管理系统.Helper
{
    public class ExportHelper
    {
        public static bool ExportToCSV(DataTable table)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    string filename = saveFileDialog.FileName;
                    StringBuilder builder = new StringBuilder();

                    //标题
                    foreach (DataColumn col in table.Columns)
                    {
                        builder.Append(col.ColumnName);
                        builder.Append(",");
                    }

                    builder.Append("\r\n");

                    //内容
                    foreach (DataRow row in table.Rows)
                    {
                        var content = new StringBuilder();
                        foreach (var col in row.ItemArray)
                        {
                            content.Append(col.ToString());
                            content.Append(",");
                        }
                        builder.Append(content.ToString());
                        builder.Append("\r\n");
                    }

                    //文件名
                    if (string.IsNullOrEmpty(filename))
                    {
                        var date = $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}";
                        filename = $"{date}.csv";
                    }
                    else
                    {
                        filename = $"{filename}.csv";
                    }

                    //写到本地
                    File.WriteAllText(filename, builder.ToString());

                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// 导出任意类型数组到CSV文件（支持中文列标题）
        /// </summary>
        /// <typeparam name="T">数组元素类型</typeparam>
        /// <param name="data">要导出的数组</param>
        /// <param name="columnHeaders">自定义列标题映射（属性名->显示名称）</param>
        /// <returns>是否导出成功</returns>
        public static bool ExportArrayToCSV<T>(T[] data, Dictionary<string, string> columnHeaders = null)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    string filename = saveFileDialog.FileName;
                    StringBuilder builder = new StringBuilder();

                    // 获取类型属性
                    PropertyInfo[] properties = typeof(T).GetProperties();

                    // 写入列标题
                    foreach (PropertyInfo prop in properties)
                    {
                        // 如果有自定义列标题映射，则使用映射值，否则使用属性名
                        string header = columnHeaders != null && columnHeaders.ContainsKey(prop.Name)
                            ? columnHeaders[prop.Name]
                            : prop.Name;

                        builder.Append(header);
                        builder.Append(",");
                    }
                    builder.Append("\r\n");

                    // 写入内容
                    foreach (T item in data)
                    {
                        var content = new StringBuilder();
                        foreach (PropertyInfo prop in properties)
                        {
                            object value = prop.GetValue(item, null);
                            content.Append(value?.ToString() ?? "");
                            content.Append(",");
                        }
                        builder.Append(content.ToString());
                        builder.Append("\r\n");
                    }

                    // 文件名处理
                    if (string.IsNullOrEmpty(filename))
                    {
                        var date = $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}";
                        filename = $"{date}.csv";
                    }
                    else if (!filename.EndsWith(".csv"))
                    {
                        filename = $"{filename}.csv";
                    }

                    // 写到本地
                    File.WriteAllText(filename, builder.ToString());

                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}