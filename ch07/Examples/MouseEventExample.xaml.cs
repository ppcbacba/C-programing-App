using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// MouseEventExample.xaml 的交互逻辑
    /// </summary>
    public partial class MouseEventExample : Window
    {
        public MouseEventExample()
        {
            InitializeComponent();
            this.Closing += MouseEventExample_Closing;
        }

        private void MouseEventExample_Closing(object sender, CancelEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void Parentanvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Rect_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
            var rect=e.Source as Rectangle;
            var rectTag = new RectTag()
            {
                RectFillBrush = rect.Fill,
                RectOpacity = rect.Opacity
            };
            rect.Tag = rectTag;
            rect.Fill = Brushes.Red;
        }

        private void Rect_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
            var rect = e.Source as Rectangle;
            if (rect == null) return;
            var rectTag = rect.Tag as RectTag;
            if (rectTag == null) return;
            rect.Fill = rectTag.RectFillBrush;
            rect.Opacity = rectTag.RectOpacity;
        }

        private void Border_MouseEnter_1(object sender, MouseEventArgs e)
        {
            ellipse.Width = 85;
            ellipse.Height = 85;
            statusTextBlock.Text = "将鼠标移动到椭圆内，上下滚动滚轮观察效果";
        }

        private void Border_MouseMove_1(object sender, MouseEventArgs e)
        {
            var element = Mouse.DirectlyOver as FrameworkElement;
            Mouse.OverrideCursor = element.Cursor;
        }

        private void ellipse_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            int delta = 10;
            if (e.Delta > 0)
            {
                ellipse.Width += delta;
                ellipse.Height += delta;
            }
            else if(e.Delta<0)
            {
                ellipse.Width -= delta;
                ellipse.Height -= delta;
            }

            statusTextBlock.Text = $"current Delta:{e.Delta}";

        }

        private void ParentCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var senderElement = sender as FrameworkElement;
            var sourceElement = e.OriginalSource as FrameworkElement;
            var sourceObject = e.Source as FrameworkElement;
            var rect = e.Source as Rectangle;
            var p = Mouse.GetPosition(null);
            ellipse.Width = p.X;
            ellipse.Height = p.Y;
            statusTextBlock.Text =
                $"发送事件的对象：{senderElement.Name}\t事件源:{sourceElement.Name}\t引发事件的对象：{sourceObject.Name}\n鼠标位置：x={p.X},y={p.Y}";

        }
    }

    internal class RectTag
    {
        public System.Windows.Media.Brush RectFillBrush { get; set; }
        public double RectOpacity { get; set; }
    }
}
