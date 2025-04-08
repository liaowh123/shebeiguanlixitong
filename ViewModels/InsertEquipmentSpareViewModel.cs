using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using 设备管理系统.BLL;
using 设备管理系统.Models;
using 设备管理系统.MVVM;

namespace 设备管理系统.ViewModels
{
    internal class InsertEquipmentSpareViewModel : ObservableObject
    {
        private EquipmentSpare equipmentSpare = new EquipmentSpare();
        public EquipmentSpare EquipmentSpare
        {
            get { return equipmentSpare; }
            set { equipmentSpare = value; RaisePropertyChanged(); }
        }

        private List<Equipment> equipments = new List<Equipment>();
        /// <summary>
        /// 所有设备
        /// </summary>
        public List<Equipment> Equipments
        {
            get { return equipments; }
            set { equipments = value; RaisePropertyChanged(); }
        }

        private Equipment equipment = new Equipment();
        // <summary>
        // 当前选择的设备
       // <summary>
        public Equipment Equipment
        {
            get { return equipment; }
            set { equipment = value; RaisePropertyChanged(); }
        }
        public ICommand SelectionChangedCommand { get; }

        public InsertEquipmentSpareViewModel()
        {
            SelectionChangedCommand = new DelegateCommand<Equipment>(OnSelectionChangedCommand);
        }

        private void OnSelectionChangedCommand(Equipment equipment)
        {

            //
        }


    }
             
}
