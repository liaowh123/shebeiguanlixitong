using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设备管理系统.Models
{
    public class EquipmentSpare : EntityBase
    {
        private string equipmentname;
        /// <summary>
        /// 设备名称
        /// </summary>
        public string EquipmentName
        {
            get { return equipmentname; }
            set { equipmentname = value; RaisePropertyChanged(); }
        }


        private string name;
        /// <summary>
        /// 物料名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }


        private string brand;
        /// <summary>
        /// 物料品牌
        /// </summary>
        public string Brand
        {
            get { return brand; }
            set { brand = value; RaisePropertyChanged(); }
        }


        private string specification;
        /// <summary>
        /// 物料规格
        /// </summary>
        public string Specification
        {
            get { return specification; }
            set { specification = value; RaisePropertyChanged(); }
        }


        private int allocationNumber;
        /// <summary>
        /// 配置数量
        /// </summary>
        public int AllocationNumber
        {
            get { return allocationNumber; }
            set { allocationNumber = value; RaisePropertyChanged(); }
        }


        private int maxNumber;
        /// <summary>
        /// 最大库存
        /// </summary>
        public int MaxNumber
        {
            get { return maxNumber; }
            set { maxNumber = value; RaisePropertyChanged(); }
        }


        private int minNumber;
        /// <summary>
        /// 最小库存
        /// </summary>
        public int MinNumber
        {
            get { return minNumber; }
            set { minNumber = value; RaisePropertyChanged(); }
        }


        private int procurementCycle;
        /// <summary>
        /// 采购周期 单位：天
        /// </summary>
        public int ProcurementCycle
        {
            get { return procurementCycle; }
            set { procurementCycle = value; RaisePropertyChanged(); }
        }


        private int spareNumber;
        /// <summary>
        /// 现有库存
        /// </summary>
        public int SpareNumber
        {
            get { return spareNumber; }
            set { spareNumber = value; RaisePropertyChanged(); }
        }


        private string picture;
        /// <summary>
        /// 物料图片地址
        /// </summary>
        public string Picture
        {
            get { return picture; }
            set { picture = value; RaisePropertyChanged(); }
        }

        private string note;
        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            get { return note; }
            set { note = value; RaisePropertyChanged(); }
        }
    }
}