using System.Windows;
namespace ch07.Examples
{
    /// <summary>
    /// DialogBoxWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DialogBoxWindow : Window
    {
        public DialogBoxWindow()
        {
            InitializeComponent();
            buttonOK.IsDefault = true;
            buttonCancel.IsCancel = true;
        }
        public  string TextString { get; set; }
        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            TextString = textBox1.Text;
            this.DialogResult = true;

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
