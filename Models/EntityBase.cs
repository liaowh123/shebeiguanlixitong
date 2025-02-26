using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设备管理系统.MVVM;

namespace 设备管理系统.Models
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class EntityBase : ObservableObject
    {
        private int id;
        /// <summary>
        /// 主键，自增
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(); }
        }


        private DateTime insertDate;
        /// <summary>
        /// 插入时间
        /// </summary>
        public DateTime InsertDate
        {
            get { return insertDate; }
            set { insertDate = value; RaisePropertyChanged(); }
        }

        private bool isChecked;
        /// <summary>
        /// 选择
        /// </summary>
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; RaisePropertyChanged(); }
        }

    }
}
