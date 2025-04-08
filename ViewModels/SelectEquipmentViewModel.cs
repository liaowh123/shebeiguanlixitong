using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using 设备管理系统.BLL;
using 设备管理系统.Models;
using 设备管理系统.MVVM;

namespace 设备管理系统.ViewModels
{
    internal class SelectEquipmentViewModel : ObservableObject
    {
        private EquipmentService equipmentService = new EquipmentService();

        private Equipment equipment;
        /// <summary>
        /// 当前选中的工序
        /// </summary>
        public Equipment Equipment
        {
            get { return equipment; }
            set { equipment = value; RaisePropertyChanged(); }
        }


        private List<Equipment> equipments = new List<Equipment>();
        /// <summary>
        /// 所有工序
        /// </summary>
        public List<Equipment> Equipments
        {
            get { return equipments; }
            set { equipments = value; RaisePropertyChanged(); }
        }
        public ICommand LoadedCommand { get; }

        public SelectEquipmentViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
        }

        private void OnLoadedCommand()
        {
            Equipments = equipmentService.GetAll();
        }
    }
}

