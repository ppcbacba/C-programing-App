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
using System.Windows.Shapes;

namespace ch07.Examples
{
    /// <summary>
    /// RetangleExample.xaml 的交互逻辑
    /// </summary>
    public partial class RetangleExample : Window
    {
        public RetangleExample()
        {
            InitializeComponent();
        }

        private void rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            Point p1 = e.GetPosition(canvas1);
            Rectangle r=sender as Rectangle;
            Point p2 = e.GetPosition(r);
            textBlock1.Text = $"相对于canvas左上角的位置：X={p1.X},y={p1.Y}\n相对于矩形左上角的位置：X={p2.X},Y={p2.Y}";

        }

        private void rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle r=e.Source as Rectangle;
            r.Fill=new SolidColorBrush(Color.FromArgb(0xFF,0x89,0xD4,0x55));

        }

        private void rectangel_MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle r=e.Source as Rectangle;
            r.Fill = Brushes.Red;
            textBlock1.Text = "鼠标未在矩形内";
        }

        private void rectangel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("OK");

        }
    }
}
