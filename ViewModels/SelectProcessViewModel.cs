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
    internal class SelectProcessViewModel : ObservableObject
    {
        private ProcessService processService = new ProcessService();
        private List<Process> processs = new List<Process>();
        public List<Process> Processs
        {
            get { return processs; }
            set { processs = value; RaisePropertyChanged(); }
        }
        public ICommand LoadedCommand { get; }

        public SelectProcessViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
        }

        private void OnLoadedCommand()
        {
            Processs = processService.GetAll();
        }
    }
}
