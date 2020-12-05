using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// PageThree.xaml 的交互逻辑
    /// </summary>
    public partial class ItemMessage : Page
    {
        public  static  string labelNameText { get; set; }
        public ItemMessage()
        {
            InitializeComponent();
            LabelName.Content = labelNameText;


        }
        /// <summary>
        /// 点击相应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelName_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.Return();
        }
    }
}
