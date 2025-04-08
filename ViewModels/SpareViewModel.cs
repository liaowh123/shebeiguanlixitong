using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using 学生成绩管理系统.Helper;
using 设备管理系统.BLL;
using 设备管理系统.Models;
using 设备管理系统.MVVM;
using 设备管理系统.Views;

namespace 设备管理系统.ViewModels
{
    internal class SpareViewModel : ObservableObject
    {
        private SpareService spareService = new SpareService();
        private EquipmentSpareService equipmentSpareService = new EquipmentSpareService();
        private List<Spare> spares = new List<Spare>();
        public List<Spare> Spares
        {
            get { return spares; }
            set { spares = value; RaisePropertyChanged(); }
        }

        public EquipmentSpare EquipmentSpare { get; set; } = new EquipmentSpare();
        public string  SearchTerm { get; set; } //搜索内容

        public ICommand LoadedCommand { get; }
        public ICommand InsertCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public ICommand AddToEquipmentSpare { get; }
        public ICommand Search { get; }

        public SpareViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
            InsertCommand = new DelegateCommand(OnInsertCommand);
            UpdateCommand = new DelegateCommand<Spare>(OnUpdateCommand);
            DeleteCommand = new DelegateCommand<Spare>(OnDeleteCommand);
            AddToEquipmentSpare = new DelegateCommand<Spare>(OnAddToEquipmentSpare);
            Search = new DelegateCommand<Spare>(OnSearch);
        }

        private void OnDeleteCommand(Spare spare)
        {
            if (spare == null)
                return;

            MessageBox messageBox = new MessageBox($"是否要删除{spare.Name}?");
            messageBox.ShowDialog();
            if (messageBox.IsOk)
            {
                var count = spareService.Delete(spare);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    Spares = spareService.GetAll();
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }
            }
        }

        private void OnUpdateCommand(Spare spare)
        {
            if (spare != null)
            {
                int count1 = 0;
                //做一份深拷贝
                var temp = CopyHelper.DeepCopy(spare);
                UpdateSpareView view = new UpdateSpareView(temp);
                DialogWindow dialogWindow = new DialogWindow(view, "修改记录");//确定，取消的按钮界面
                dialogWindow.OnSubmit += (arg) =>
                {
                    var vm = arg as UpdateSpareViewModel;
                    spare.MaterialCode = vm.Spare.MaterialCode;
                    spare.Name = vm.Spare.Name;
                    spare.Brand = vm.Spare.Brand;
                    spare.Specification = vm.Spare.Specification;
                    spare.SpareNumber = vm.Spare.SpareNumber;
                    spare.First_level = vm.Spare.First_level;
                    spare.Second_level = vm.Spare.Second_level;
                    spare.Third_level = vm.Spare.Third_level;
                    //EquipmentSpare.Name = vm.Spare.Name;
                    //EquipmentSpare.Brand = vm.Spare.Brand;
                    //EquipmentSpare.Specification = vm.Spare.Specification;
                    //EquipmentSpare.SpareNumber = vm.Spare.Number;

                    var count = spareService.Update(spare);
                    if (count > 0)
                    {
                        new MessageBox($"操作成功").ShowDialog();
                        Spares = spareService.GetAll();

                    }
                    else
                    {
                        new MessageBox($"操作失败").ShowDialog();
                    }
                };
                dialogWindow.ShowDialog();

                //count1 = equipmentSpareService.Update(EquipmentSpare );
            }
        }

        private void OnInsertCommand()
        {
            InsertSpareView insertSpareView = new InsertSpareView("请输入备件信息");
            DialogWindow dialogWindow = new DialogWindow(insertSpareView);
            dialogWindow.OnSubmit += (arg) =>
            {
                var vm = arg as InsertSpareViewModel;
                Spare spare = new Spare
                {
                    MaterialCode = vm.Spare.MaterialCode,
                    Name = vm.Spare.Name,
                    Brand = vm.Spare.Brand,
                    Specification = vm.Spare.Specification,
                    SpareNumber = vm.Spare.SpareNumber,
                    Picture = vm.Spare.Picture,
                    First_level = vm.Spare.First_level,
                    Second_level = vm.Spare.Second_level,
                    Third_level = vm.Spare.Third_level,
                };                              
                var count = spareService.Insert(spare);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    Spares = spareService.GetAll();
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
            Spares = spareService.GetAll();
        }

        private void OnAddToEquipmentSpare(Spare spare)
        {
            EquipmentSpare.Name = spare.Name;
            EquipmentSpare.Brand = spare.Brand;
            EquipmentSpare.Specification = spare.Specification;
            EquipmentSpareViewModel equipmentSpareViewModel = new EquipmentSpareViewModel(EquipmentSpare);
            equipmentSpareViewModel.OnInsertCommand1() ;
        }

        private void OnSearch(Spare spare)
        {
            Spares = spareService.Search(SearchTerm);
        }

    }
}
