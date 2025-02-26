using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using 设备管理系统.MVVM;
using 设备管理系统.Models;
using 设备管理系统.BLL;

namespace 设备管理系统.ViewModels
{
    public class RegisterViewModel
    {
        public Person person { get; set; } = new Person();
        public bool Girl { get; set; } = true;
        public bool Boy { get; set; } = false;

        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new DelegateCommand(OnRegisterCommand);
        }

        //注册新用户
        private void OnRegisterCommand()
        {
            person.Role = 1;



            //写入数据库
            PersonService personService = new PersonService();
            int count = personService.Insert(person);

            if (count == -1)
            {
                MessageBox.Show($"必填项不能为空");
            }
            else if (count == 0)
            {
                MessageBox.Show($"注册失败");
            }
            else
            {
                MessageBox.Show($"{person.Name},恭喜你注册成功");
            }
        }
    }
}
