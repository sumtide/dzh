using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
    /// PageTwo.xaml 的交互逻辑
    /// </summary>
    public partial class PageTwo : Page
    {
         List<Car> itemList = new List<Car>();
        public PageTwo()
        {
            InitializeComponent();
            var task = Task.Run(() => { InitItem(); });
            task.Wait();
            CarList.ItemsSource = itemList;
        }
        /// <summary>
        /// 初始化列表成员
        /// </summary>
        public async void InitItem()
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
                    Car templist = new Car()
                    {
                        location = "老化车" + e + "号",
                        number = s + "号车位",
                        mid =  await car.GetID(e),
                        com = "unknhkjlkm" ,
                        rate = "fslfmsld",
                    };
                    itemList.Add(templist);
                }
            }

        }
    }
}
