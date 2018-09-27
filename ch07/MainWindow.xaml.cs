using System;
using System.Windows;
using System.Windows.Controls;
using ch07.Examples;

namespace ch07
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //this.SourceInitialized += MainWindow_SourceInitialized;
        }

        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.ShowDialog();
            this.Title = $"欢迎您,{login.UserName}";
        }

        private RadioButton rb = null;

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            rb = e.Source as RadioButton;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rb == null)
            {
                MessageBox.Show("请先选择一个例子", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (rb == null) return;
            var content = rb.Content.ToString();
            Window w = null;
            switch (content)
            {
                case "HelloWorld": w = new HelloWorldWindow(); break;
                case "DialogBox":
                    var dw = new DialogBoxWindow
                    {
                        Owner = this
                    };
                    var result = dw.ShowDialog();
                    if (result == true)
                    {
                        MessageBox.Show($"来自对话框:{dw.TextString}");
                        //tray
                    }
                    break;

                case "PageExample1":
                    w = new Window();
                    w.Content = new Pages.Page1();
                    break;

                case "PageExample2":
                    w = new System.Windows.Navigation.NavigationWindow
                    {
                        Content = new Pages.Page2()
                    };
                    break;

                case "PageExample3":
                    w = new Pages.FrameExample();
                    break;
                case "RectangleExample":
                    w=new RetangleExample();
                    break;
                case "SampleStyleExample":
                    w=new SampleStyleExample();
                    break;
                case "MouseEventExample":
                    w=new MouseEventExample();
                    break;
            }

            if (w == null) return;
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Owner = this;
            w.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
