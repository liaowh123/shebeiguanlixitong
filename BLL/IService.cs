using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设备管理系统.BLL
{
    /// <summary>
    /// 泛型接口，T=表名
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T> where T : class
    {
        List<T> GetAll();
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
