﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设备管理系统.Models;
using 设备管理系统.MVVM;

namespace 设备管理系统.ViewModels
{
    internal class InsertEquipmentViewModel : ObservableObject
    {
        public Equipment Equipment { get; set; } = new Equipment();
    }
}
