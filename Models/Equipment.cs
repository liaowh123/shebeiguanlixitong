using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设备管理系统.Models
{
    public class Equipment :EntityBase      
    {
        private string name;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
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


        private string assetNumber;
        /// <summary>
        /// 资产编号
        /// </summary>
        public string AssetNumber
        {
            get { return assetNumber; }
            set { assetNumber = value; RaisePropertyChanged(); }
        }


        private string comment;
        /// <summary>
        /// 备注
        /// </summary>
        public string Comment
        {
            get { return comment; }
            set { comment = value; RaisePropertyChanged(); }
        }

    }
}
