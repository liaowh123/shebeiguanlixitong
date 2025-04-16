using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using 学生成绩管理系统.Helper;
using 设备管理系统.BLL;
using 设备管理系统.Models;
using 设备管理系统.MVVM;
using 设备管理系统.Views;
using static 设备管理系统.Views.InsertEquipmentSpareView;

namespace 设备管理系统.ViewModels
{
    internal class EquipmentSpareViewModel : ObservableObject
    {
        private EquipmentSpareService equipmentspareService = new EquipmentSpareService();
        private List<EquipmentSpare> equipmentspares = new List<EquipmentSpare>();
        public List<EquipmentSpare> EquipmentSpares
        {
            get { return equipmentspares; }
            set { equipmentspares = value; RaisePropertyChanged(); }
        }

        private EquipmentService equipmentService = new EquipmentService();
        private List<Equipment> equipments = new List<Equipment>();
        public List<Equipment> Equipments
        {
            get { return equipments; }
            set { equipments = value; RaisePropertyChanged(); }
        }

        private Equipment equipment = new Equipment();
        public Equipment Equipment
        {
            get { return equipment; }
            set { equipment = value; RaisePropertyChanged(); }
        }


        private EquipmentSpare equipmentSpare = new EquipmentSpare();
        public EquipmentSpare EquipmenSpare
        {
            get { return equipmentSpare; }
            set { equipmentSpare = value; RaisePropertyChanged(); }
        }

        public string SearchTerm { get; set; }    //搜索内容
        public ICommand LoadedCommand { get; }
        public ICommand InsertCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SelectionChangedCommand { get; }

        public ICommand Search { get; }
        public EquipmentSpareViewModel(EquipmentSpare equipmentSpare)
        {
            
            EquipmenSpare = equipmentSpare;
        }

        public EquipmentSpareViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
            InsertCommand = new DelegateCommand(OnInsertCommand);
            UpdateCommand = new DelegateCommand<EquipmentSpare>(OnUpdateCommand);
            DeleteCommand = new DelegateCommand<EquipmentSpare>(OnDeleteCommand);
            SelectionChangedCommand = new DelegateCommand(OnSelectionChangedCommand);
            Search = new DelegateCommand<EquipmentSpare>(OnSearch);
        }

        private void OnSelectionChangedCommand()
        {
            if (Equipment == null)
                return;
            //EquipmenSpare1.EquipmentName = Equipment.Name;
            //string equipmentName = Equipment.Name;

            EquipmentSpares = equipmentspareService.Where(Equipment);
        }
        private void OnDeleteCommand(EquipmentSpare equipmentspare)
        {
            if (equipmentspare == null)
                return;

            MessageBox messageBox = new MessageBox($"是否要删除{equipmentspare.Name}?");
            messageBox.ShowDialog();
            if (messageBox.IsOk)
            {
                var count = equipmentspareService.Delete(equipmentspare);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    EquipmentSpares = equipmentspareService.GetAll();
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }
            }
        }

        private void OnUpdateCommand(EquipmentSpare equipmentspare)
        {
            if (equipmentspare != null)
            {
                //做一份深拷贝
                var temp = CopyHelper.DeepCopy(equipmentspare);
                UpdateEquipmentSpareView view = new UpdateEquipmentSpareView(temp);
                DialogWindow dialogWindow = new DialogWindow(view, "修改记录");//确定，取消的按钮界面
                dialogWindow.OnSubmit += (arg) =>
                {
                    var vm = arg as UpdateEquipmentSpareViewModel;
                    equipmentspare.EquipmentName = vm.EquipmentSpare.EquipmentName;
                    equipmentspare.Name = vm.EquipmentSpare.Name;
                    equipmentspare.Brand = vm.EquipmentSpare.Brand;
                    equipmentspare.Specification = vm.EquipmentSpare.Specification;
                    equipmentspare.AllocationNumber = vm.EquipmentSpare.AllocationNumber;
                    equipmentspare.MaxNumber = vm.EquipmentSpare.MaxNumber;
                    equipmentspare.MinNumber = vm.EquipmentSpare.MinNumber;
                    equipmentspare.ProcurementCycle = vm.EquipmentSpare.ProcurementCycle;
                    equipmentspare.SpareNumber = vm.EquipmentSpare.SpareNumber;
                    equipmentspare.Note = vm.EquipmentSpare.Note;
                    equipmentspare.Picture = vm.EquipmentSpare.Picture;
                    var count = equipmentspareService.Update(equipmentspare);
                    if (count > 0)
                    {
                        new MessageBox($"操作成功").ShowDialog();
                        if (Equipment.Name == null )
                        {
                            EquipmentSpares = equipmentspareService.GetAll();
                            return;
                        }
                        EquipmentSpares = equipmentspareService.Where(Equipment);
                    }
                    else
                    {
                        new MessageBox($"操作失败").ShowDialog();
                    }
                };
                dialogWindow.ShowDialog();
            }
        }

        private void OnInsertCommand()
        {
            Equipments = equipmentService.GetEquipmentName();                      
            InsertEquipmentSpareView insertEquipmentSpareView = new InsertEquipmentSpareView(Equipments, "请输入备件信息");
            DialogWindow dialogWindow = new DialogWindow(insertEquipmentSpareView);        
            dialogWindow.OnSubmit += (arg) =>
            {
                var vm = arg as InsertEquipmentSpareViewModel;
                EquipmentSpare equipmentspare = new EquipmentSpare
                {
                    EquipmentName = vm.Equipment.Name,
                    Name = vm.EquipmentSpare.Name,
                    Brand = vm.EquipmentSpare.Brand,
                    Specification = vm.EquipmentSpare.Specification,
                    AllocationNumber = vm.EquipmentSpare.AllocationNumber,
                    MaxNumber = vm.EquipmentSpare.MaxNumber,
                    MinNumber = vm.EquipmentSpare.MinNumber,
                    ProcurementCycle = vm.EquipmentSpare.ProcurementCycle,
                    SpareNumber = vm.EquipmentSpare.SpareNumber,
                    Note = vm.EquipmentSpare.Note,
                };
                
                var count = equipmentspareService.Insert(equipmentspare);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    EquipmentSpares = equipmentspareService.GetAll();
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }

            };
            dialogWindow.ShowDialog();
        }

        public void OnInsertCommand1()
        {
            Equipments = equipmentService.GetEquipmentName();
            
            InsertEquipmentSpareView insertEquipmentSpareView = new InsertEquipmentSpareView(Equipments, EquipmenSpare, "请输入备件信息");
            DialogWindow dialogWindow = new DialogWindow(insertEquipmentSpareView);
            dialogWindow.OnSubmit += (arg) =>
            {
                var vm = arg as InsertEquipmentSpareViewModel;
                if (vm.EquipmentSpare.Brand == null)
                {
                    vm.EquipmentSpare.Brand = "无";
                }
                EquipmentSpare equipmentspare = new EquipmentSpare
                {
                    EquipmentName = vm.Equipment.Name,
                    Name = vm.EquipmentSpare.Name,
                    Brand = vm.EquipmentSpare.Brand,
                    Specification = vm.EquipmentSpare.Specification,
                    AllocationNumber = vm.EquipmentSpare.AllocationNumber,
                    MaxNumber = vm.EquipmentSpare.MaxNumber,
                    MinNumber = vm.EquipmentSpare.MinNumber,
                    ProcurementCycle = vm.EquipmentSpare.ProcurementCycle,
                    SpareNumber = vm.EquipmentSpare.SpareNumber,
                    Note = vm.EquipmentSpare.Note,
                };
                
                var count = equipmentspareService.Insert(equipmentspare);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    EquipmentSpares = equipmentspareService.GetAll();
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }

            };
            dialogWindow.ShowDialog();
        }

        private void OnLoadedCommand()
        {
            EquipmentSpares = equipmentspareService.GetAll();
            Equipments = equipmentService.GetEquipmentName();
        }

        private void OnSearch(EquipmentSpare equipmentSpare)
        {
            EquipmentSpares = equipmentspareService.Search(SearchTerm);
        }
    }
}
