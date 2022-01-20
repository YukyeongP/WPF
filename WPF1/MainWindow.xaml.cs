using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Text.RegularExpressions;

namespace WPF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _birthYearIsValid = false;
        private bool _birthMonthIsValid = false;
        private bool _birthDayIsValid = false;

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
            {
                tbkPwC.Visibility = Visibility.Hidden;
                if(tbxPwC.Text == tbxPw.Text)
                    PwCError.Visibility = Visibility.Hidden;
                else
                    PwCError.Visibility = Visibility.Visible;
            }
        }
        private void tbxPwC_GotFocus(object sender, RoutedEventArgs e)
        {
            tbkPwC.Visibility = Visibility.Hidden;
        }
        private void tbxPwC_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxPwC.Text == "")
            {
                tbkPwC.Visibility = Visibility.Visible;
            }
        }

        // Name
        private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxName.Text == "")
                tbkName.Visibility = Visibility.Visible;
            else
            { 
                tbkName.Visibility = Visibility.Hidden;
            }
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

        // Birthday watermark
        // Year
        private void tbxBthYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxBirthYear.Text == "")
                tbkBirthYear.Visibility = Visibility.Visible;
            else
            {
                tbkBirthYear.Visibility = Visibility.Hidden;
                if (!Enumerable.Range(1500, 2022).Contains(ToNumeric(tbxBirthYear.Text)))
                    BYearError.Visibility = Visibility.Visible;
                else
                    BYearError.Visibility = Visibility.Hidden;
            }  
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
            {
                tbkBirthMonth.Visibility = Visibility.Hidden;
                if (!Enumerable.Range(1, 12).Contains(ToNumeric(tbxBirthMonth.Text)))
                    //tbxBMonthError.Visibility = Visibility.Visible;
                    BYearError.Visibility = Visibility.Visible;
                else
                    //tbxBMonthError.Visibility = Visibility.Hidden;
                    BYearError.Visibility = Visibility.Hidden;
            }
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
            {
                tbkBirthDay.Visibility = Visibility.Hidden;
                if (!Enumerable.Range(1, 31).Contains(ToNumeric(tbxBirthDay.Text)))
                    //tbxBDayError.Visibility = Visibility.Visible;
                    BYearError.Visibility = Visibility.Visible;
                else
                    //tbxBDayError.Visibility = Visibility.Hidden;
                    BYearError.Visibility = Visibility.Hidden;
            }
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

        private void tbxBYearError_Show(object sender, RoutedEventArgs e)
        {
            BYearError.Visibility = Visibility.Visible;
        }
       /* private void tbxBMonthError_Show(object sender, RoutedEventArgs e)
        {
            BMonthError.Visibility = Visibility.Visible;
        }
        private void tbxBDayError_Show(object sender, RoutedEventArgs e)
        {
            BDayError.Visibility = Visibility.Visible;
        }*/

        private void SignUpBtnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxId.Text) || string.IsNullOrEmpty(tbxPw.Text) || string.IsNullOrEmpty(tbxPwC.Text) || string.IsNullOrEmpty(tbxName.Text) ||
                (radio1.IsChecked != true && radio2.IsChecked != true) || tbxBirthYear.Text.Length == 0 || tbxBirthMonth.Text.Length == 0 || tbxBirthDay.Text.Length == 0)
            {
                btSignUp.IsEnabled = true;
            }

            /* if((!IsNumeric(tbxBirthYear.Text) || !IsNumeric(tbxBirthMonth.Text) || !IsNumeric(tbxBirthDay.Text))
                 && (!Enumerable.Range(1500, 2022).Contains(ToNumeric(tbxBirthYear.Text)) || !Enumerable.Range(1, 12).Contains(ToNumeric(tbxBirthMonth.Text)) || !Enumerable.Range(1, 31).Contains(ToNumeric(tbxBirthDay.Text))))
             {
                 MessageBox.Show("생년월일을 정확하게 입력해주세요", "SignUp Error", MessageBoxButton.OK, MessageBoxImage.Error);
             }*/
            /*if (!Enumerable.Range(1500, 2022).Contains(ToNumeric(tbxBirthYear.Text)))
                tbxBYearError_Show(sender, e);
            if (!Enumerable.Range(1, 12).Contains(ToNumeric(tbxBirthMonth.Text)))
                tbxBMonthError_Show(sender, e);
                MessageBox.Show("태어난 일을 정확하게 입력해주세요", "SignUp Error", MessageBoxButton.OK, MessageBoxImage.Error);
*/
        }
     
        private bool IsNumeric(string text)
        {
            //return int.TryParse(text, out int num);
            Regex regex = new Regex("[^0-9]+");
            return regex.IsMatch(text);
        }

        private int ToNumeric(string text)
        {
            int.TryParse(text, out int num);
            return num;
        }

        // only number
        private void tbxBthPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = !IsNumeric(e.Text);
            //e.Handled = !int.TryParse(e.Text, out int num);
        }

        private void tbxId_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        /*  private void tbkBdayMonthPreviewTextInput(object sender, TextCompositionEventArgs e)
          {
              //int check;
              //if (!int.TryParse(e.Text, out check) || Convert.ToInt32(e.Text) < 1 || Convert.ToInt32(e.Text) > 12)
              //{
              //    BirthMonthIsValid = false;
              //}
              //else
              //    BirthMonthIsValid = true;
          }

          private void tbkBirthDayTextInput(object sender, TextCompositionEventArgs e)
          {
              //int check;
              //if (!int.TryParse(e.Text, out check) || Convert.ToInt32(e.Text) < 1 || Convert.ToInt32(e.Text) > 31)
              //{
              //    BirthDayIsValid = false;
              //}
              //BirthDayIsValid = true;
          }*/

    }
}