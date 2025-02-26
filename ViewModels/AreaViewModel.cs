using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using 学生成绩管理系统.Helper;
using 设备管理系统.BLL;
using 设备管理系统.Models;
using 设备管理系统.MVVM;
using 设备管理系统.Views;

namespace 设备管理系统.ViewModels
{
    internal class AreaViewModel : ObservableObject
    {
        private AreaService areaService = new AreaService();
        private List<Area> areas = new List<Area>();
        public List<Area> Areas
        {
            get { return areas; }
            set { areas = value; RaisePropertyChanged(); }
        }
        public ICommand LoadedCommand { get; }
        public ICommand InsertCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public AreaViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
            InsertCommand = new DelegateCommand(OnInsertCommand);
            UpdateCommand = new DelegateCommand<Area>(OnUpdateCommand);
            DeleteCommand = new DelegateCommand<Area>(OnDeleteCommand);
        }

        private void OnDeleteCommand(Area area)
        {
            if (area == null)
                return;

            MessageBox messageBox = new MessageBox($"是否要删除{area.Name}?");
            messageBox.ShowDialog();
            if (messageBox.IsOk)
            {
                var count = areaService.Delete(area);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    Areas = areaService.GetAll();
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }
            }
        }

        private void OnUpdateCommand(Area area)
        {
            if (area != null)
            {
                //做一份深拷贝
                var temp = CopyHelper.DeepCopy(area);
                UpdateAreaView view = new UpdateAreaView(temp);
                DialogWindow dialogWindow = new DialogWindow(view, "修改记录");//确定，取消的按钮界面
                dialogWindow.OnSubmit += (arg) =>
                {
                    var vm = arg as UpdateAreaViewModel;
                    area = vm.Area;
                    var count = areaService.Update(area);
                    if (count > 0)
                    {
                        new MessageBox($"操作成功").ShowDialog();
                        Areas = areaService.GetAll();
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
            InsertAreaProcessView insertAreaProcessView = new InsertAreaProcessView("请输入区域");
            DialogWindow dialogWindow = new DialogWindow(insertAreaProcessView);
            dialogWindow.OnSubmit += (arg) =>
            {
                var vm = arg as InsertAreaProcessViewModel;
                Area area = new Area();
                area.Name = vm.AreaProcess.AreaName;
                var count = areaService.Insert(area);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    Areas = areaService.GetAll();
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
            Areas = areaService.GetAll();
        }
    }
}
