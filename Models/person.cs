using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设备管理系统.Models
{
    public class Person : EntityBase
    {

        private string name;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        private string password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; RaisePropertyChanged(); }
        }

        //private bool sex;
        ///// <summary>
        ///// 性别，ture=男，false=女
        ///// </summary>
        //public bool Sex
        //{
        //    get { return sex; }
        //    set { sex = value; RaisePropertyChanged(); }
        //}

        //private string city;
        ///// <summary>
        ///// 城市
        ///// </summary>
        //public string City
        //{
        //    get { return city; }
        //    set { city = value; RaisePropertyChanged(); }
        //}


        private int role;
        /// <summary>
        /// 用户角色
        /// </summary>
        public int Role
        {
            get { return role; }
            set { role = value; RaisePropertyChanged(); }
        }
    }
}
