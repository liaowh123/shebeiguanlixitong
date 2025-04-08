using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设备管理系统.Models;
using 设备管理系统.MVVM;

namespace 设备管理系统.ViewModels
{
    internal class UpdateEquipmentSpareViewModel : ObservableObject
    {
        private EquipmentSpare equipmentSpare;
        public EquipmentSpare EquipmentSpare
        {
            get { return equipmentSpare; }
            set { equipmentSpare = value; RaisePropertyChanged(); }
        }
    }
}
