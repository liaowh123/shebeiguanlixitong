using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using 设备管理系统.DAL;
using 设备管理系统.ViewModels;

namespace 设备管理系统.MVVM
{
    public class DelegateCommand<T> : ICommand
    {
        public DelegateCommand(Action<T> action)
        {
            Action = action;
        }
        public Action<T> Action { get; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action?.Invoke((T)parameter);
        }
    }

    public class DelegateCommand : ICommand
    {
        private Action Action { get; }
        private Action<object> ObjectAction { get; }
        public DelegateCommand(Action action)
        {
            Action = action;
        }

        public DelegateCommand(Action<object> objectAction)
        {
            ObjectAction = objectAction;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //判断当次单击是否可以往下执行？
            return true;
        }

        public void Execute(object parameter)
        {
            //执行真正的代码
            Action?.Invoke();
            ObjectAction?.Invoke(parameter);
        }
    }




}