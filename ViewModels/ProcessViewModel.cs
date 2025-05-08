using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using 设备管理系统.BLL;
using 设备管理系统.Models;
using 设备管理系统.Helper;
using 设备管理系统.MVVM;
using 设备管理系统.Views;



namespace 设备管理系统.ViewModels
{
    internal class ProcessViewModel : ObservableObject
    {
        private ProcessService processService = new ProcessService();
        private List<Process> processs = new List<Process>();
        public List<Process> Processs
        {
            get { return processs; }
            set { processs = value; RaisePropertyChanged(); }
        }
        public ICommand LoadedCommand { get; }
        public ICommand InsertCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ProcessViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
            InsertCommand = new DelegateCommand(OnInsertCommand);
            UpdateCommand = new DelegateCommand<Process>(OnUpdateCommand);
            DeleteCommand = new DelegateCommand<Process>(OnDeleteCommand);
        }

        private void OnDeleteCommand(Process process)
        {
            if (process == null)
                return;

            MessageBox messageBox = new MessageBox($"是否要删除{process.Name}?");
            messageBox.ShowDialog();
            if (messageBox.IsOk)
            {
                var count = processService.Delete(process);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    Processs = processService.GetAll();
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }
            }
        }

        private void OnUpdateCommand(Process process)
        {
            if (process != null)
            {
                //做一份深拷贝
                var temp = CopyHelper.DeepCopy(process);
                UpdateProcessView view = new UpdateProcessView(temp);
                DialogWindow dialogWindow = new DialogWindow(view, "修改记录");
                dialogWindow.OnSubmit += (arg) =>
                {
                    var vm = arg as UpdateProcessViewModel;
                    process = vm.Process;
                    var count = processService.Update(process);
                    if (count > 0)
                    {
                        new MessageBox($"操作成功").ShowDialog();
                        Processs = processService.GetAll();
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
                Process process = new Process();
                process.Name = vm.AreaProcess.AreaName;
                var count = processService.Insert(process);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    Processs = processService.GetAll();
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
            Processs = processService.GetAll();
        }
    }
}
