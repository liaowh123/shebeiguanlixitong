using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设备管理系统.BLL
{
    public interface ILogin<T> where T : class
    {
        List<T> Login(T entity);
    }
}
