using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace dzh
{
    class TreeViewWithIcons:TreeViewItem
    {
        #region 字段
        ImageSource iconSource;
        TextBlock textBlock;
        Image icon;
        #endregion

        #region 属性
        public TreeViewWithIcons()
        {
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            Header = stack;
            icon = new Image();
            icon.VerticalAlignment = VerticalAlignment.Center;
            icon.Margin = new Thickness(0, 0, 4, 0);
            icon.Source = iconSource;
            stack.Children.Add(icon);
            textBlock = new TextBlock();
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            stack.Children.Add(textBlock);
        }
        public ImageSource Icon
        {
            set { iconSource = value;icon.Source = iconSource; }
            get { return iconSource; }
        }
        public string HeaderText
        {
            set { textBlock.Text = value; }
            get { return textBlock.Text; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取TreeView.Header属性里的Text文本
        /// </summary>
        /// <param name="stackPanel"></param>
        /// <returns></returns>
        public string GetText(StackPanel stackPanel)
        {
            StringBuilder sb = new StringBuilder(10);
            foreach (var s in stackPanel.Children)
            {
                if (s.GetType().Name == "TextBlock")
                {
                    TextBlock temp = (TextBlock)s;
                    sb.Append(temp.Text);
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}
