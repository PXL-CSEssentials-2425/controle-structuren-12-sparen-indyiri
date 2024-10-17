using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H3Oef12Sparen
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

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            weeklyRaiseTextBox.Clear();
            allowanceTextBox.Clear();
            desiredSavingsAmountTextBox.Clear();
            resultTextBox.Clear();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            string inputAllowance = allowanceTextBox.Text;
            string inputWeeklyRaise = weeklyRaiseTextBox.Text;
            string inputDesiredSavingsAmount = desiredSavingsAmountTextBox.Text;

            double allowance;
            double weeklyRaise;
            double desiredSavingsAmount;
            int amountOfWeeks = 0;
            double savingsAtThatMoment = 0;
            double extraAllowance = 0;

            bool isInputAllowanceValid = double.TryParse(inputAllowance, out allowance);
            bool isInputWeeklyRaiseValid = double.TryParse(inputWeeklyRaise, out weeklyRaise);
            bool isInputDesiredSavingsAmountValid = double.TryParse(inputDesiredSavingsAmount, out desiredSavingsAmount);

            if (isInputAllowanceValid || isInputWeeklyRaiseValid || isInputDesiredSavingsAmountValid)
            {
                while (savingsAtThatMoment < desiredSavingsAmount)
                {
                    amountOfWeeks++;
                    savingsAtThatMoment = amountOfWeeks * allowance;
                    extraAllowance = (amountOfWeeks - 1 ) * weeklyRaise;
                    
                    //savingsAtThatMoment += (allowance * (weeklyRaise + 1));                   
                    

                    //allowance = (allowance * (weeklyRaise + 1));
                    //savingsAtThatMoment += allowance;
                    //amountOfWeeks++;

                }               
                resultTextBox.Text = $"Spaarbedrag na {amountOfWeeks - 1} weken: €{Math.Round(savingsAtThatMoment - allowance,2)} \n\rExtra weekgeld op dat moment: €{Math.Round(extraAllowance, 2)} \n\rTotaal spaargeld: €{Math.Round((savingsAtThatMoment - allowance) + extraAllowance, 2)} ";                
            }
            else
            {
                resultTextBox.Text = "Geef correcte waarden in!";
            }
        }
    }
}