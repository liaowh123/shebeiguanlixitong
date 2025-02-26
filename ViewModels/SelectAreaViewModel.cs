using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using 设备管理系统.BLL;
using 设备管理系统.Models;
using 设备管理系统.MVVM;

namespace 设备管理系统.ViewModels
{
    internal class SelectAreaViewModel : ObservableObject
    {
        private AreaService areaService = new AreaService();
        private List<Area> areas = new List<Area>();
        public List<Area> Areas
        {
            get { return areas; }
            set { areas = value; RaisePropertyChanged(); }
        }
        public ICommand LoadedCommand { get; }

        public SelectAreaViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
        }

        private void OnLoadedCommand()
        {
            Areas = areaService.GetAll();
        }
    }
}
