using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设备管理系统.DAL;
using 设备管理系统.Models;

namespace 设备管理系统.BLL
{
    /// <summary>
    /// Person表的增册改查
    /// </summary>
    public class PersonService : IService<Person>, ILogin<Person>
    {
        /// <summary>
        /// 登录用户
        /// </summary>
        /// <param name="Person"></param>
        /// <returns></returns>
        public List<Person> Login(Person person)
        {
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset($"SELECT  [Id] ,[Name] ,[Password] ,[Role] , [InsertDate] FROM [Person] Where Name = '{person.Name}' And Password = '{person.Password}'");

            //ORM数据库和数据实体的映射关系实现,理解C#特性、反射、泛型
            List<Person> persons = SqlHelper.Instance.DataSetToList<Person>(dataSet);

            return persons;

        }

        /// <summary>
        /// 插入Person新记录
        /// </summary>
        /// <param name="Person"></param>
        /// <returns></returns>
        public int Insert(Person person)
        {
            int count = -1;
            if (person == null) { return count; }
            if (string.IsNullOrEmpty(person.Name)) { return count; }
            if (string.IsNullOrEmpty(person.Password)) { return count; }

            person.InsertDate = DateTime.Now;

            //string sql = $"Insert Into Person (Name,Password,Sex,City,InsertDate) Values ('{Person.Name}','{Person.Password}','{Person.Sex}','{Person.City}','{Person.InsertDate}');";

            string sql = $"Insert Into Person (Name,Password,Role,InsertDate) Values (@Name,@Password,@Role,@InsertDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", person.Name),
                new SqlParameter("@Password", person.Password),
                new SqlParameter("@Role", person.Role),
                new SqlParameter("@InsertDate", person.InsertDate),
            };
            count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);

            return count;
        }

        /// <summary>
        /// 获取用户表所有数据
        /// </summary>
        /// <returns></returns>
        public List<Person> GetAll()
        {
            string sql = @"SELECT [Id]
                          ,[Name]
                          ,[Password]                        
                          ,[InsertDate]
                          ,[Role]
                          FROM [EquipmentDB].[dbo].[Person]";
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, null);
            List<Person> Persons = SqlHelper.Instance.DataSetToList<Person>(dataSet);
            return Persons;
        }

        /// <summary>
        /// 获取用户表所有数据
        /// </summary>
        /// <returns></returns>
        public List<Person> SelectByRole(int role = 1)
        {
            string sql = @"SELECT [Id]
                          ,[Name]
                          ,[Password]
                          ,[Role]
                          ,[InsertDate]                        
                          FROM [EquipmentDB].[dbo].[Person] Where Role = @Role";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Role", role),
            };
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql, parameters);
            List<Person> Persons = SqlHelper.Instance.DataSetToList<Person>(dataSet);
            return Persons;
        }

        public int Delete(Person Person)
        {
            string sql = "Delete Person where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", Person.Id),
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }

        public int Update(Person Person)
        {
            string sql = @"Update Person set Name = @Name, Password = @Password Where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name",Person.Name),
                new SqlParameter("@Password",Person.Password),
                
                new SqlParameter("@Id",Person.Id),
            };
            int count = SqlHelper.Instance.ExecuteNonQuery(sql, parameters);
            return count;
        }
    }
}
