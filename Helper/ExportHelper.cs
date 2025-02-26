using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 学生成绩管理系统.Helper
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
    }
}
