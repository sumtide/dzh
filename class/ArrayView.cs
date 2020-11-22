using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace dzh
{
    /// <summary>
    /// 矩阵显示成员类
    /// </summary>
    class ArrayView:ListBoxItem
    {
        #region 字段
        ImageSource iconSoure;
        Image icon;
        TextBlock number;
        TextBlock text;
        #endregion

        #region 属性
        public ArrayView()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Vertical;
            Content = stackPanel;
            number = new TextBlock();
            number.TextAlignment = TextAlignment.Center;
            number.Height = 20;
            stackPanel.Children.Add(number);
            icon = new Image();
            icon.Height = 50;
            icon.Source = iconSoure;
            stackPanel.Children.Add(icon);
            text = new TextBlock();
            text.TextAlignment = TextAlignment.Center;
            number.Height = 20;
            stackPanel.Children.Add(text);
        }
        public ImageSource Icon
        {
            get { return iconSoure; }
            set { iconSoure = value;icon.Source = iconSoure; }
        }
        public string Text
        {
            get { return text.Text; }
            set { text.Text = value; }
        }
        public string Number
        {
            get { return number.Text; }
            set { number.Text = value; }
        }
        #endregion

        #region 方法

        #endregion
    }
}
