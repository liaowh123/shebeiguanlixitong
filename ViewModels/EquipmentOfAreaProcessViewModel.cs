using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using 设备管理系统.BLL;
using 设备管理系统.Models;
using 设备管理系统.MVVM;
using 设备管理系统.Views;

namespace 设备管理系统.ViewModels
{
    internal class EquipmentOfAreaProcessViewModel : ObservableObject
    {
        private EquipmentOfAreaProcessService equipmentOfAreaProcessService = new EquipmentOfAreaProcessService();
        private AreaService areaService = new AreaService();

        private Area area;
        /// <summary>
        /// 当前选中的区域
        /// </summary>
        public Area Area
        {
            get { return area; }
            set { area = value; RaisePropertyChanged(); }
        }

        private List<Area> areas = new List<Area>();
        /// <summary>
        /// 所有区域
        /// </summary>
        public List<Area> Areas
        {
            get { return areas; }
            set { areas = value; RaisePropertyChanged(); }
        }


        private Process process;
        /// <summary>
        /// 当前选中的工序
        /// </summary>
        public Process Process
        {
            get { return process; }
            set { process = value; RaisePropertyChanged(); }
        }

        private List<Process> processs = new List<Process>();
        /// <summary>
        /// 所有工序
        /// </summary>
        public List<Process> Processs
        {
            get { return Processs; }
            set { Processs = value; RaisePropertyChanged(); }
        }

        private List<EquipmentOfAreaProcess> equipmentOfAreaProcesss = new List<EquipmentOfAreaProcess>();
        
        public List<EquipmentOfAreaProcess> EquipmentOfAreaProcesss
        {
            get { return equipmentOfAreaProcesss; }
            set { equipmentOfAreaProcesss = value; RaisePropertyChanged(); }
        }


        public ICommand LoadedCommand { get; }
        public ICommand InsertCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AreaSelectionChangedCommand { get; }
        public ICommand SelectSubjectCommand { get; }
        public ICommand DeleteSubjectCommand { get; }
        public EquipmentOfAreaProcessViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
            //InsertCommand = new DelegateCommand(OnInsertCommand);
            //UpdateCommand = new DelegateCommand<Transcript>(OnUpdateCommand);
            //DeleteCommand = new DelegateCommand<Transcript>(OnDeleteCommand);
            AreaSelectionChangedCommand = new DelegateCommand<EquipmentOfAreaProcess>(OnAreaSelectionChangedCommand);
            //SelectAreaCommand = new DelegateCommand(OnSelectAreaCommand);
            //DeleteSubjectCommand = new DelegateCommand<Detail>(OnDeleteSubjectCommand);
        }
        private void OnLoadedCommand()
        {
            Areas = areaService.GetAll();
        }

        //查询当前区域的工序
        private void OnAreaSelectionChangedCommand(EquipmentOfAreaProcess equipmentOfAreaProcess)
        {
            EquipmentOfAreaProcesss = equipmentOfAreaProcessService.Where(equipmentOfAreaProcess.AreaId);
        }
    }
}  