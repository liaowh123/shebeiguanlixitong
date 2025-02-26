using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设备管理系统.Models
{
    public class AreaProcess :EntityBase
    {
        private string areaName;
        /// <summary>
        /// 区域Id
        /// </summary>
        public string AreaName
        {
            get { return areaName; }
            set { areaName = value; RaisePropertyChanged(); }
        }


        private string processName;
        /// <summary>
        /// 工序Id
        /// </summary>
        public string ProcessName
        {
            get { return processName; }
            set { processName = value; RaisePropertyChanged(); }
        }
    }
}
