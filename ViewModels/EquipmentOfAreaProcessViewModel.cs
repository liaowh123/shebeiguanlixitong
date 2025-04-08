using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using 设备管理系统.BLL;
using 设备管理系统.DAL;
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

        private EquipmentOfAreaProcess equipmentOfAreaProcess;
        /// <summary>
        /// 当前选择的区域
        /// </summary>s
        public EquipmentOfAreaProcess EquipmentOfAreaProcess
        {
            get { return equipmentOfAreaProcess; }
            set { equipmentOfAreaProcess = value; RaisePropertyChanged(); }
        }


        private List<EquipmentOfAreaProcess> equipmentOfAreaProcesss = new List<EquipmentOfAreaProcess>();
        /// <summary>
        /// 区域列表
        /// </summary>
        public List<EquipmentOfAreaProcess> EquipmentOfAreaProcesss
        {
            get { return equipmentOfAreaProcesss; }
            set { equipmentOfAreaProcesss = value; RaisePropertyChanged(); }
        }


        private List<EquipmentOfAreaProcess> equipmentOfAreaProcesss1 = new List<EquipmentOfAreaProcess>();
        /// <summary>
        /// 工序列表
        /// </summary>
        public List<EquipmentOfAreaProcess> EquipmentOfAreaProcesss1
        {
            get { return equipmentOfAreaProcesss1; }
            set { equipmentOfAreaProcesss1 = value; RaisePropertyChanged(); }
        }


        private EquipmentOfAreaProcess equipmentOfAreaProcess1 ;
        /// <summary>
        /// 当前选择的工序
        /// </summary>
        public EquipmentOfAreaProcess EquipmentOfAreaProcess1
        {
            get { return equipmentOfAreaProcess1; }
            set { equipmentOfAreaProcess1 = value; RaisePropertyChanged(); }
        }


        private List<EquipmentOfAreaProcess> equipmentOfAreaProcesss2 = new List<EquipmentOfAreaProcess>();
        /// <summary>
        /// 设备列表
        /// </summary>
        public List<EquipmentOfAreaProcess> EquipmentOfAreaProcesss2
        {
            get { return equipmentOfAreaProcesss2; }
            set { equipmentOfAreaProcesss2 = value; RaisePropertyChanged(); }
        }

        private EquipmentOfAreaProcess equipmentOfAreaProcess2;
        /// <summary>
        /// 当前选择的设备
        /// </summary>
        public EquipmentOfAreaProcess EquipmentOfAreaProcess2
        {
            get { return equipmentOfAreaProcess2; }
            set { equipmentOfAreaProcess2 = value; RaisePropertyChanged(); }
        }

        private Equipment equipment;
        /// <summary>
        /// 当前选中的设备
        /// </summary>
        public Equipment Equipment
        {
            get { return equipment; }
            set { equipment = value; RaisePropertyChanged(); }
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

        public ICommand LoadedCommand { get; }
        public ICommand InsertCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteAreaCommand { get; }
        public ICommand AreaSelectionChangedCommand { get; }
        public ICommand ProcessSelectionChangedCommand { get; }
        public ICommand SelectAreaCommand { get; }
        public ICommand SelecProcessCommand { get; }
        public ICommand SelecEquipmentCommand { get; }
        public ICommand DeleteProcessCommand { get; }
        public ICommand DeleteEquipmentCommand { get; }
        public EquipmentOfAreaProcessViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
            //InsertCommand = new DelegateCommand(OnInsertCommand);
            //UpdateCommand = new DelegateCommand<Transcript>(OnUpdateCommand);
            DeleteAreaCommand = new DelegateCommand<EquipmentOfAreaProcess>(OnDeleteAreaCommand);
            AreaSelectionChangedCommand = new DelegateCommand<EquipmentOfAreaProcess>(OnAreaSelectionChangedCommand);
            ProcessSelectionChangedCommand = new DelegateCommand<EquipmentOfAreaProcess>(OnProcessSelectionChangedCommand);
            SelectAreaCommand = new DelegateCommand(OnSelectAreaCommand);//添加区域
            SelecProcessCommand = new DelegateCommand(OnSelectProcessCommand);//添加工序
            SelecEquipmentCommand = new DelegateCommand(OnSelectEquipmentCommand);//添加设备
            DeleteProcessCommand = new DelegateCommand<EquipmentOfAreaProcess>(OnDeleteProcessCommand);
            DeleteEquipmentCommand = new DelegateCommand<EquipmentOfAreaProcess>(OnDeleteEquipmentCommand);

        }



        private void OnDeleteAreaCommand(EquipmentOfAreaProcess equipmentOfAreaProcess)
        {
            if (equipmentOfAreaProcess == null) return;

            MessageBox messageBox = new MessageBox($"是否要删除{equipmentOfAreaProcess.AreaName}?");
            messageBox.ShowDialog();
            if (messageBox.IsOk)
            {
                var count = equipmentOfAreaProcessService.Delete(equipmentOfAreaProcess);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    EquipmentOfAreaProcesss = equipmentOfAreaProcessService.GetAllWithArea();
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }
            }
        }

        private void OnLoadedCommand()
        {
            EquipmentOfAreaProcesss = equipmentOfAreaProcessService.GetAllWithArea();
        }

        //添加区域
        private void OnSelectAreaCommand()
        {
            if (equipmentOfAreaProcesss == null)
            {
                new MessageBox($"请选择区域").ShowDialog();
                return;
            }
            SelectAreaView view = new SelectAreaView();
            DialogWindow dialogWindow = new DialogWindow(view, "选择区域");
            dialogWindow.OnSubmit += (arg) =>
            {
                var vm = arg as SelectAreaViewModel;
                var areas = vm.Areas.Where(t => t.IsChecked == true).ToList();
                if (areas != null && areas.Count > 0)
                {
                    int count = 0;
                    foreach (var area in areas)
                    {
                        EquipmentOfAreaProcess equipmentOfAreaProcess = new EquipmentOfAreaProcess();
                        equipmentOfAreaProcess.AreaName = area.Name;
                        equipmentOfAreaProcess.ProcessName = "请输入工序名称（默认无）";
                        //equipmentOfAreaProcess.EquipmentId = Equipment.Id;
                        //equipmentOfAreaProcess.EquipmentName = Equipment.Name;
                        //equipmentOfAreaProcess.EquipmentComment = Equipment.Comment;                       
                        count += equipmentOfAreaProcessService.Insert(equipmentOfAreaProcess);
                    }

                    if (count > 0)
                    {
                        new MessageBox($"操作成功").ShowDialog();
                        EquipmentOfAreaProcesss = equipmentOfAreaProcessService.GetAllWithArea();
                    }
                    else
                    {
                        new MessageBox($"操作失败").ShowDialog();
                    }
                }


            };
            dialogWindow.ShowDialog();
        }

      //  查询当前区域的工序
        private void OnAreaSelectionChangedCommand(EquipmentOfAreaProcess equipmentOfAreaProcess)
        {
            if (equipmentOfAreaProcess == null) return;
            EquipmentOfAreaProcesss2 = null;
            EquipmentOfAreaProcesss1 = equipmentOfAreaProcessService.Where(equipmentOfAreaProcess.AreaName);
        }


        //添加工序
        private void OnSelectProcessCommand()
        {
            if (equipmentOfAreaProcess == null)
            {
                new MessageBox($"请选择区域").ShowDialog();
                return;
            }
            SelectProcessView view = new SelectProcessView();
            DialogWindow dialogWindow = new DialogWindow(view, "选择工序");
            dialogWindow.OnSubmit += (arg) =>
            {
                var vm = arg as SelectProcessViewModel;
                var processs = vm.Processs.Where(t => t.IsChecked == true).ToList();
                if (processs != null && processs.Count > 0)
                {
                    int count = 0;
                    foreach (var process in processs)
                    {
                        EquipmentOfAreaProcess equipmentOfAreaProcess = new EquipmentOfAreaProcess();
                        equipmentOfAreaProcess.AreaName = EquipmentOfAreaProcess.AreaName;
                        equipmentOfAreaProcess.ProcessName = process.Name;
                        //equipmentOfAreaProcess1.ProcessName = "请输入工序名称（默认无）";
                        //equipmentOfAreaProcess.EquipmentId = Equipment.Id;
                        //equipmentOfAreaProcess.EquipmentName = Equipment.Name;
                        //equipmentOfAreaProcess.EquipmentComment = Equipment.Comment;                       
                        count += equipmentOfAreaProcessService.InsertProcess(equipmentOfAreaProcess);
                    }

                    if (count > 0)
                    {
                        new MessageBox($"操作成功").ShowDialog();
                        if (equipmentOfAreaProcess == null) return;
                        EquipmentOfAreaProcesss1 = equipmentOfAreaProcessService.WhereProcess(equipmentOfAreaProcess.AreaName);
                    }
                    else
                    {
                        new MessageBox($"操作失败").ShowDialog();
                    }
                }


            };
            dialogWindow.ShowDialog();
        }

        //删除工序
        private void OnDeleteProcessCommand(EquipmentOfAreaProcess equipmentOfAreaProcess1)
        {
            if (equipmentOfAreaProcess1 == null) return;

            MessageBox messageBox = new MessageBox($"是否要删除{equipmentOfAreaProcess.ProcessName}?");
            messageBox.ShowDialog();
            if (messageBox.IsOk)
            {
                equipmentOfAreaProcess1.AreaName = EquipmentOfAreaProcess.AreaName;
                var count = equipmentOfAreaProcessService.DeleteProcess(equipmentOfAreaProcess1);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    if (equipmentOfAreaProcess == null) return;
                    EquipmentOfAreaProcesss1 = equipmentOfAreaProcessService.WhereProcess(equipmentOfAreaProcess.AreaName);
                    EquipmentOfAreaProcesss = equipmentOfAreaProcessService.GetAllWithArea();
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }
            }
        }

        //添加设备
        private void OnSelectEquipmentCommand()
        {
            if (equipmentOfAreaProcess == null)
            {
                new MessageBox($"请选择设备").ShowDialog();
                return;
            }
            SelectEquipmentView view = new SelectEquipmentView();
            DialogWindow dialogWindow = new DialogWindow(view, "选择设备");
            dialogWindow.OnSubmit += (arg) =>
            {
                var vm = arg as SelectEquipmentViewModel;
                var equipments = vm.Equipments.Where(t => t.IsChecked == true).ToList();
                if (equipments != null && equipments.Count > 0)
                {
                    int count = 0;
                    foreach (var equipment in equipments)
                    {
                        EquipmentOfAreaProcess equipmentOfAreaProcess = new EquipmentOfAreaProcess();
                        equipmentOfAreaProcess.AreaName = EquipmentOfAreaProcess.AreaName;
                        equipmentOfAreaProcess.ProcessName = EquipmentOfAreaProcess1.ProcessName;
                        //equipmentOfAreaProcess1.ProcessName = "请输入工序名称（默认无）";
                        equipmentOfAreaProcess.EquipmentNumber = equipment.EquipmentNumber;
                        equipmentOfAreaProcess.EquipmentName = equipment.Name; ;
                        equipmentOfAreaProcess.EquipmentComment = equipment.Comment;                       
                        count += equipmentOfAreaProcessService.InsertEquipment(equipmentOfAreaProcess);
                    }

                    if (count > 0)
                    {
                        new MessageBox($"操作成功").ShowDialog();
                        if (equipmentOfAreaProcess == null) return;
                        EquipmentOfAreaProcesss2 = equipmentOfAreaProcessService.WhereEquipment(equipmentOfAreaProcess.AreaName, equipmentOfAreaProcess1.ProcessName);
                    }
                    else
                    {
                        new MessageBox($"操作失败").ShowDialog();
                    }
                }


            };
            dialogWindow.ShowDialog();
        }


        //  查询当前区域工序的设备
        private void OnProcessSelectionChangedCommand(EquipmentOfAreaProcess EquipmentOfAreaProcess1)
        {
            if (equipmentOfAreaProcess == null|| equipmentOfAreaProcess1 == null) return;
            EquipmentOfAreaProcess1.AreaName = EquipmentOfAreaProcess.AreaName;
            EquipmentOfAreaProcesss2 = equipmentOfAreaProcessService.WhereEquipment(equipmentOfAreaProcess1.AreaName, equipmentOfAreaProcess1.ProcessName);
        }


        //删除设备
        private void OnDeleteEquipmentCommand(EquipmentOfAreaProcess equipmentOfAreaProcess2)
        {
            if (equipmentOfAreaProcess == null || equipmentOfAreaProcess1 == null) return;

            MessageBox messageBox = new MessageBox($"是否要删除{equipmentOfAreaProcess2.EquipmentName}?");
            messageBox.ShowDialog();
            if (messageBox.IsOk)
            {
                equipmentOfAreaProcess2.Id = EquipmentOfAreaProcess2.Id;
                equipmentOfAreaProcess2.AreaName = EquipmentOfAreaProcess.AreaName;
                equipmentOfAreaProcess2.ProcessName = EquipmentOfAreaProcess1.ProcessName;
                var count = equipmentOfAreaProcessService.DeleteEquipment(equipmentOfAreaProcess2);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    if (equipmentOfAreaProcess == null) return;
                    EquipmentOfAreaProcesss2 = equipmentOfAreaProcessService.WhereEquipment(equipmentOfAreaProcess2.AreaName, equipmentOfAreaProcess2.ProcessName);
                    EquipmentOfAreaProcesss1 = equipmentOfAreaProcessService.Where(equipmentOfAreaProcess.AreaName);
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }
            }
        }
    }
}         

