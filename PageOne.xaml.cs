using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dzh
{
    /// <summary>
    /// PageOne.xaml 的交互逻辑
    /// </summary>
    public partial class PageOne : Page
    {
        public PageOne()
        {
            InitializeComponent();
            InitItem();
        }
        #region 辅助方法
        /// <summary>
        /// 初始化ArrayView节点
        /// </summary>
        private async void InitItem()
        {
            Car car = new Car();
            List<int> fnumber = new List<int>();
            fnumber.AddRange(await car.GetFItem());
            foreach (var e in fnumber)
            {
                List<int> cnumber = new List<int>();
                cnumber.AddRange(await car.GetCItem(e));
                foreach (var s in cnumber)
                {
                    //实例化物体
                    ArrayView arrayView = new ArrayView();
                    arrayView.Style = FindResource("CommonItem") as Style;
                    arrayView.Number = await car.GetID(e);
                    arrayView.Icon = new BitmapImage(new Uri("images/ss.png", UriKind.Relative));
                    arrayView.Text = "老化车" + e + " " + s + "号表位";
                    arrayView.Selected += ArrayItem_Selected;
                    ArrayViewPanel.Items.Add(arrayView);
                }
            }
        }
        #endregion

        private void ArrayItem_Selected(object sender, RoutedEventArgs e)
        {
            ArrayView temp = (ArrayView)sender;
            Car car = new Car();
            MainWindow window = (MainWindow)Window.GetWindow(this);
            car.ShowMessageEvent += new Car.ShowMessage(window.OpenMessage);
            car.SendEvent(temp.Text);


        }
    }
}
