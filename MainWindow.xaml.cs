using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.Windows.Controls.Ribbon;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media;

namespace dzh
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitItem();
        }
        /// <summary>
        /// Ribbon切换tag触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tab =Ribbon.SelectedItem as RibbonTab;
            if (tab.Header.ToString() == "老化任务")
            {        
                PageContral.Navigate(new Uri("ListViews.xaml", UriKind.Relative));
            }
            if (tab.Header.ToString() == "实时数据")
            {
                PageContral.Navigate(new Uri("ArrayViews.xaml", UriKind.Relative));
            }
            if (tab.Header.ToString() == "记录统计")
            {
                PageContral.Navigate(new Uri("RecordView.xaml", UriKind.Relative));
            }
        }
        /// <summary>
        /// Ribbon加载时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ribbon_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(64);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            system_time.Text = DateTime.Now.ToString("HH:mm:ss yyyy-MM-dd");
        }
        /// <summary>
        /// 打开增加车位窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            OperationView addtable = new OperationView();
            addtable.ShowDialog();
        }
        /// <summary>
        /// 选中TreeViewItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewWithIcons index = (TreeViewWithIcons)sender;
            index.Icon = new BitmapImage(new Uri("images/tower4.jpg", UriKind.Relative));
            if (index.Parent.GetType().Name == "TreeViewWithIcons")
            {
                TreeViewWithIcons temp=(TreeViewWithIcons)index.Parent;
                txt_current_select.Text= "当前选择的是:" + temp.HeaderText + " "+ index.HeaderText;
            }
        }
        /// <summary>
        /// 不选中TreeViewItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeItem_Unselected(object sender, RoutedEventArgs e)
        {
            TreeViewWithIcons index = (TreeViewWithIcons)sender;
            index.Icon = new BitmapImage(new Uri("images/powerTower2.png", UriKind.Relative));
        }
        #region  辅助方法
        /// <summary>
        ///初始化TreeView
        /// </summary>
        private async void InitItem()
        {
            Car car = new Car();
            List<int> fnumber = new List<int>();
            fnumber.AddRange(await car.GetFItem());
            foreach (var e in fnumber)
            {
                //实例化父节点
                TreeViewWithIcons fnode = new TreeViewWithIcons();
                fnode.Selected += TreeItem_Selected;
                fnode.Unselected += TreeItem_Unselected;
                fnode.HeaderText = "老化车" + e + "号";
                fnode.Icon = new BitmapImage(new Uri("images/powerTower2.png", UriKind.Relative));
                TreeView.Items.Add(fnode);
                //遍历子节点信息
                List<int> cnumber = new List<int>();
                cnumber.AddRange(await car.GetCItem(e));
                //实例化子节点
                foreach (var s in cnumber)
                {
                    TreeViewWithIcons cnode = new TreeViewWithIcons();
                    cnode.HeaderText = s + "号表位";
                    cnode.Icon = new BitmapImage(new Uri("Images/powerTower2.png", UriKind.Relative));
                    cnode.ContextMenu = FindResource("ItemMenu") as ContextMenu;
                    cnode.Selected += TreeItem_Selected;
                    cnode.Unselected += TreeItem_Unselected;
                    fnode.Items.Add(cnode);
                    if (e == 1 && s == 1)
                    {
                        cnode.IsSelected = true;
                    }
                }
            }
        }
        /// <summary>
        /// 接收事件的响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OpenMessage(object sender,MessageEventArgs e)
        {
            ItemMessage.labelNameText = e.Message;
            PageContral.Navigate(new Uri("ItemMessage.xaml", UriKind.Relative));
        }
        /// <summary>
        /// 返回导航首页
        /// </summary>
        public void Return()
        {
            PageContral.Navigate(new Uri("ArrayViews.xaml", UriKind.Relative));
        }
        #endregion

    }
}