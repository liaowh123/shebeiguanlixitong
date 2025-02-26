using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using 设备管理系统.MVVM;
using 学生成绩管理系统.Helper;
using 设备管理系统.BLL;
using 设备管理系统.Models;
using 设备管理系统.Views;

namespace 设备管理系统.ViewModels
{
    public class PersonViewModel : ObservableObject
    {
        private PersonService personService = new PersonService();
        private List<Person> persons = new List<Person>();
        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; RaisePropertyChanged(); }
        }
        public ICommand LoadedCommand { get; }
        public ICommand InsertCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public PersonViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
            InsertCommand = new DelegateCommand(OnInsertCommand);
            UpdateCommand = new DelegateCommand(OnUpdateCommand);
            DeleteCommand = new DelegateCommand<Person>(OnDeleteCommand);
        }

        private void OnDeleteCommand(Person person)
        {
            if (person == null)
                return;

            if (person.Role == 0)
            {
                new MessageBox($"不能删除管理员").ShowDialog();
                return;
            }

            MessageBox messageBox = new MessageBox($"是否要删除{person.Name}?");
            messageBox.ShowDialog();
            if (messageBox.IsOk)
            {
                var count = personService.Delete(person);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    Persons = personService.GetAll();
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }
            }
        }

        private void OnUpdateCommand(object o)
        {
            var person = (Person)o;
            if (person != null)
            {
                //做一份深拷贝
                var temp = CopyHelper.DeepCopy(person);
                UpdatePersonView updatePersonView = new UpdatePersonView(temp);
                DialogWindow dialogWindow = new DialogWindow(updatePersonView, "修改记录");
                dialogWindow.OnSubmit += (arg) =>
                {
                    var vm = arg as UpdatePersonViewModel;
                    person = vm.Person;
                    var count = personService.Update(person);
                    if (count > 0)
                    {
                        new MessageBox($"操作成功").ShowDialog();
                        Persons = personService.GetAll();
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
            Person person = new Person();
            person.Name = "新用户";
            person.Password = "12345678";
            person.Role = 1;
            person.InsertDate = DateTime.Now;
           // person.Sex = true;
            var count = personService.Insert(person);
            if (count > 0)
            {
                new MessageBox($"操作成功").ShowDialog();
                Persons = personService.GetAll();
            }
            else
            {
                new MessageBox($"操作失败").ShowDialog();
            }
        }

        private void OnLoadedCommand()
        {
            Persons = personService.GetAll();
        }
    }
}
