using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using 设备管理系统.BLL;
using 设备管理系统.Models;
using 设备管理系统.Views;
using 设备管理系统.DAL;
using 设备管理系统.MVVM;

namespace 设备管理系统.ViewModels
{
    //业务逻辑层
    public class LoginViewModel
    {
        public Person Person { get; set; } = new Person() { Name = "admin", Password = "12345678" };

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(OnLoginCommand); //不可以，为什么，ICommand是接口，抽象当中的抽象
            RegisterCommand = new DelegateCommand(OnRegisterCommand);
        }

        private void OnRegisterCommand()
        {
            new RegisterWindow().ShowDialog();
        }

        private void OnLoginCommand(object obj)
        {
            PersonService personService = new PersonService();
            List<Person> persons = personService.Login(Person);
            if (persons.Count > 0)
            {
                AppData.Instance.CurrentUser = persons[0];

                MainWindow mainWindow = new MainWindow();

                LoginWindow loginWindow = obj as LoginWindow;
                if (loginWindow != null)
                {
                    loginWindow.Close();
                }

                mainWindow.Show();
            }
            else
            {
                System.Windows.MessageBox.Show("用户名和密码错误");
            }
        }

        private void Button_Click()
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataSet dataSet = sqlHelper.ExecuteDataset($"SELECT  [Id] ,[Name] ,[Password]  ,[Role]  ,[InsertDate]  FROM [Person] Where Name = '{Person.Name}' And Password = '{Person.Password}'");

            //ORM数据库和数据实体的映射关系实现,理解C#特性、反射、泛型
            List<Person> Persons = sqlHelper.DataSetToList<Person>(dataSet);

            if (Persons.Count > 0)
            {
                System.Windows.MessageBox.Show($"{Person.Name},恭喜你登录成功");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                System.Windows.MessageBox.Show("用户名和密码错误");
            }
        }
    }
}
