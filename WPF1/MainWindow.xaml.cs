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

namespace WPF1
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

        // Id
        private void tbxId_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxId.Text == "")
                tbkId.Visibility = Visibility.Visible;
            else
            {
                tbkId.Visibility = Visibility.Hidden;
            }
        }
        private void tbxId_GotFocus(object sender, RoutedEventArgs e)
        {
            tbkId.Visibility = Visibility.Hidden;
        }
        private void tbxId_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxId.Text == "")
                tbkId.Visibility = Visibility.Visible;
        }

        // Password
        private void tbxPw_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxPw.Text == "")
                tbkPw.Visibility = Visibility.Visible;
            else
                tbkPw.Visibility = Visibility.Hidden;
        }
        private void tbxPw_GotFocus(object sender, RoutedEventArgs e)
        {
            tbkPw.Visibility = Visibility.Hidden;
        }
        private void tbxPw_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxPw.Text == "")
                tbkPw.Visibility = Visibility.Visible;
        }

        // Password Check
        private void tbxPwC_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxPwC.Text == "")
                tbkPwC.Visibility = Visibility.Visible;
            else
                tbkPwC.Visibility = Visibility.Hidden;
        }
        private void tbxPwC_GotFocus(object sender, RoutedEventArgs e)
        {
            tbkPwC.Visibility = Visibility.Hidden;
        }
        private void tbxPwC_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxPwC.Text == "")
                tbkPwC.Visibility = Visibility.Visible;
        }

        // Name
        private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxName.Text == "")
                tbkName.Visibility = Visibility.Visible;
            else
                tbkName.Visibility = Visibility.Hidden;
        }
        private void tbxName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbkName.Visibility = Visibility.Hidden;
        }
        private void tbxName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxName.Text == "")
                tbkName.Visibility = Visibility.Visible;
        }

        // Birthday
        // Year
        private void tbxBthYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxBirthYear.Text == "")
                tbkBirthYear.Visibility = Visibility.Visible;
            else
                tbkBirthYear.Visibility = Visibility.Hidden;
        }
        private void tbxBthYear_GotFocus(object sender, RoutedEventArgs e)
        {
            tbkBirthYear.Visibility = Visibility.Hidden;
        }
        private void tbxBthYear_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxBirthYear.Text == "")
                tbkBirthYear.Visibility = Visibility.Visible;
        }

        // Month
        private void tbxBthMonth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxBirthMonth.Text == "")
                tbkBirthMonth.Visibility = Visibility.Visible;
            else
                tbkBirthMonth.Visibility = Visibility.Hidden;
        }
        private void tbxBthMonth_GotFocus(object sender, RoutedEventArgs e)
        {
            tbkBirthMonth.Visibility = Visibility.Hidden;
        }
        private void tbxBthMonth_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxBirthMonth.Text == "")
                tbkBirthMonth.Visibility = Visibility.Visible;
        }

        // Day
        private void tbxBthDay_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxBirthDay.Text == "")
                tbkBirthDay.Visibility = Visibility.Visible;
            else
                tbkBirthDay.Visibility = Visibility.Hidden;
        }
        private void tbxBthDay_GotFocus(object sender, RoutedEventArgs e)
        {
            tbkBirthDay.Visibility = Visibility.Hidden;
        }
        private void tbxBthDay_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxBirthDay.Text == "")
                tbkBirthDay.Visibility = Visibility.Visible;
        }

        private void SignUpBtnClick(object sender, RoutedEventArgs e)
        {
           /* if (string.IsNullOrEmpty(tbxId.Text) || string.IsNullOrEmpty(tbxPw.Text) || string.IsNullOrEmpty(tbxPwC.Text) ||
                 string.IsNullOrEmpty(tbxName.Text) || tbxBirthYear.Text.Length == 1 || tbxBirthMonth.Text.Length == 1 || tbxBirthDay.Text.Length == 1)
            {
                MessageBox.Show("정보를 정확히 입력해주세요", "SignUp Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }*/

            // IdIsValid()
        }

        private bool IdIsValid()
        {
            if (4 < tbxId.Text.Length && tbxId.Text.Length < 20)
                return true;
            else
                return false;
        }

    }
}
