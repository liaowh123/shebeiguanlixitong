using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设备管理系统.Models
{
    public class Spare : EntityBase
    {
        private int materialCode;
        /// <summary>
        /// 物料编号
        /// </summary>
        public int MaterialCode
        {
            get { return materialCode; }
            set { materialCode = value; RaisePropertyChanged(); }
        }


        private string name;
        /// <summary>
        /// 物料名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }


        private string brand;
        /// <summary>
        /// 物料品牌
        /// </summary>
        public string Brand
        {
            get { return brand; }
            set { brand = value; RaisePropertyChanged(); }
        }


        private string specification;
        /// <summary>
        /// 物料规格
        /// </summary>
        public string Specification
        {
            get { return specification; }
            set { specification = value; RaisePropertyChanged(); }
        }


        private int number;
        /// <summary>
        /// 物料数量
        /// </summary>
        public int Number
        {
            get { return number; }
            set { number = value; RaisePropertyChanged(); }
        }


        private string picture;
        /// <summary>
        /// 物料图片地址
        /// </summary>
        public string Picture
        {
            get { return picture; }
            set { picture = value; RaisePropertyChanged(); }
        }


        private int first_level;
        /// <summary>
        /// 一级分类
        /// </summary>
        public int First_level
        {
            get { return first_level; }
            set { first_level = value; RaisePropertyChanged(); }
        }


        private int second_level;
        /// <summary>
        /// 二级分类
        /// </summary>
        public int Second_level
        {
            get { return second_level; }
            set { second_level = value; RaisePropertyChanged(); }
        }


        private int third_level;
        /// <summary>
        /// 三级分类
        /// </summary>
        public int Third_level
        {
            get { return third_level; }
            set { third_level = value; RaisePropertyChanged(); }
        }



    }
}