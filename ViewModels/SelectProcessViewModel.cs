﻿using System;
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
