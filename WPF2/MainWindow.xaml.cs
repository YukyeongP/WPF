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

namespace WPF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool IsValidArea()
        {
            return SystemParameters.WorkArea.Left <= Left && Left < SystemParameters.WorkArea.Right
                && SystemParameters.WorkArea.Top <= Top && Top < SystemParameters.WorkArea.Bottom;
        }

        /// <summary>
        /// Button 컨트롤 클릭 이벤트 핸들러
        /// </summary>
        private void BtnClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            MainWindow mainWindow = new MainWindow();
            var screenWidth = System.Windows.SystemParameters.WorkArea.Width;
            var screeHeight = System.Windows.SystemParameters.WorkArea.Height;

            var previousArea = new Rect(mainWindow.Left, mainWindow.Top, mainWindow.Width, mainWindow.Height);

            // 변경
            if (btn.Name == "LeftBtn")
            {
                Left -= 10;
            }

            // 검사
            if (!IsValidArea())
            {
                mainWindow.Left = previousArea.Left;
                mainWindow.Top = previousArea.Top;
                mainWindow.Width = previousArea.Width;
                mainWindow.Height = previousArea.Height;
            }

            ////////////////////////

            if (btn.Name == "UpBtn")
            {
                Top -= 10;                
            }

            if (btn.Name == "DownBtn")
            {
                Top += 10;
            }

            if (btn.Name == "RightBtn")
            {
                Left += 10;
            }

            if (btn.Name == "BiggerBtn")
            {
                Width += 100;
                Height += 100;
            }            

            if (btn.Name == "SmallerBtn")
            {
                if (Height < 100)
                {
                    return;
                }
                Width -= 100;
                Height -= 100;

                if (Width < MinWidth)
                {
                    MessageBox.Show("최소크기입니다.", "error");
                    //SmallerButton.IsEnabled = false;
                }
            }


        }
    }
}
