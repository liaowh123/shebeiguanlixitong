using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设备管理系统.Models
{
    public class EquipmentOfAreaProcess :EntityBase
    {
        private int areaId;
        /// <summary>
        /// 区域Id
        /// </summary>
        public int AreaId
        {
            get { return areaId; }
            set { areaId = value; RaisePropertyChanged(); }
        }


        private int processId;
        /// <summary>
        /// 工序Id
        /// </summary>
        public int ProcessId
        {
            get { return processId; }
            set { processId = value; RaisePropertyChanged(); }
        }


        private int equipmentId;
        /// <summary>
        /// 设备Id
        /// </summary>
        public int EquipmentId
        {
            get { return equipmentId; }
            set { equipmentId = value; RaisePropertyChanged(); }
        }


        private string equipmentComment;
        /// <summary>
        /// 设备Id
        /// </summary>
        public string EquipmentComment
        {
            get { return equipmentComment; }
            set { equipmentComment = value; RaisePropertyChanged(); }
        }

    }
}
