using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设备管理系统.Models
{
    public class EquipmentOfAreaProcess :EntityBase
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


        private string equipmentNumber;
        /// <summary>
        /// 设备编号
        /// </summary>
        public string EquipmentNumber
        {
            get { return equipmentNumber; }
            set { equipmentNumber = value; RaisePropertyChanged(); }
        }

        private string equipmentName;
        /// <summary>
        /// 姓名(种类)
        /// </summary>
        public string EquipmentName
        {
            get { return equipmentName; }
            set { equipmentName = value; RaisePropertyChanged(); }
        }


        private string equipmentComment;
        /// <summary>
        /// 设备备注
        /// </summary>
        public string EquipmentComment
        {
            get { return equipmentComment; }
            set { equipmentComment = value; RaisePropertyChanged(); }
        }

    }
}
