using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace 设备管理系统.Helper
{
    /// <summary>
    /// 遮罩助手
    /// </summary>
    public class Marker
    {

        public static Marker Instance = new Lazy<Marker>(() => new Marker()).Value;

        public Grid Grid { get; private set; }

        public void Init(Grid grid)
        {
            Grid = grid;
        }

        /// <summary>
        /// 显示遮罩
        /// </summary>
        public void Show()
        {
            Grid.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// 隐藏遮罩
        /// </summary>
        public void Hide() 
        {
            Grid.Visibility = System.Windows.Visibility.Collapsed;
        }  

    }
}
