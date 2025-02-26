using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设备管理系统.Models;

namespace 设备管理系统
{
    public class AppData
    {
        public string Name => "设备管理系统";//表达式体属性，等同于下面的写法，用于简化只读属性的定义

        //public string Name
        //{
        //    get { return "设备管理系统"; }
        //}

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public Person CurrentUser { get; set; }

        /// <summary>
        /// 单例
        /// </summary>


        public static AppData Instance = new Lazy<AppData>(() => new AppData()).Value;//单例

    }
}
