using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using 设备管理系统.Models;
using 设备管理系统.MVVM;

namespace 设备管理系统.ViewModels
{
      internal class UpdateAreaViewModel : ObservableObject
      { 
         private Area area;
         public Area Area
         {
            get { return area; }
            set { area = value; RaisePropertyChanged(); }
         }
      }
}
