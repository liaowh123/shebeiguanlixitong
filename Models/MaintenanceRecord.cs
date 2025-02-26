using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设备管理系统.Models
{
    public class MaintenanceRecord : EntityBase
    {
        private int equipmentId;
        /// <summary>
        /// 设备Id
        /// </summary>
        public int EquipmentId
        {
            get { return equipmentId; }
            set { equipmentId = value; RaisePropertyChanged(); }
        }

        private string equipmentName;
        /// <summary>
        /// 物料名称(种类)
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


        private string matter;
        /// <summary>
        /// 维修内容
        /// </summary>
        public string Matter
        {
            get { return matter; }
            set { matter = value; RaisePropertyChanged(); }
        }


        private string spareName;
        /// <summary>
        /// 配件名称
        /// </summary>
        public string SpareName
        {
            get { return spareName; }
            set { spareName = value; RaisePropertyChanged(); }
        }


        private string time;
        /// <summary>
        /// 维修时间
        /// </summary>
        public string Time
        {
            get { return time; }
            set { time = value; RaisePropertyChanged(); }
        }


    }
}
