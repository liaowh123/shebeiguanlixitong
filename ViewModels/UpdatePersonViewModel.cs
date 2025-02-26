using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using 设备管理系统.Models;
using 设备管理系统.MVVM;

namespace 设备管理系统.ViewModels
{
    internal class UpdatePersonViewModel : ObservableObject
    {
        private Person person;
        public Person Person
        {
            get { return person; }
            set { person = value; RaisePropertyChanged(); }
        }
        public bool Girl { get; set; } = true;
        public bool Boy { get; set; } = false;

        public ICommand SexCommand { get; }

        public UpdatePersonViewModel()
        {
            SexCommand = new DelegateCommand<string>(OnSexCommand);
        }

        private void OnSexCommand(string param)
        {
            if (string.IsNullOrEmpty(param)) return;
            if (person == null) return;
           // Person.Sex = param == "男";
        }
    }
}
