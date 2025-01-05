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

namespace UnitConverterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, double> ConversionFactors = new Dictionary<string, double>
        {
            { "MetersToKilometers", 0.001 },
            { "MetersToFeet", 3.28084 },
            { "MetersToMiles", 0.000621371 },
            { "KilometersToMeters", 1000 },
            { "KilometersToFeet", 3280.84 },
            { "KilometersToMiles", 0.621371 },
            { "FeetToMeters", 0.3048 },
            { "FeetToKilometers", 0.0003048 },
            { "FeetToMiles", 0.000189394 },
            { "MilesToMeters", 1609.34 },
            { "MilesToKilometers", 1.60934 },
            { "MilesToFeet", 5280 }
         };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InputValue_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ConvertUnits();
        }

        private void Unit_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ConvertUnits();
        }

        private void ConvertUnits()
        {
            if (double.TryParse(InputValue.Text, out double input) && FromUnit.SelectedItem is ComboBoxItem fromUnit && ToUnit.SelectedItem is ComboBoxItem toUnit)
            {
                string conversionKey = $"{fromUnit.Content}To{toUnit.Content}";
                if (ConversionFactors.TryGetValue(conversionKey, out double factor))
                {
                    double result = input * factor;
                    OutputValue.Text = $"{result:F2} {toUnit.Content}";
                }
                else if (fromUnit.Content.ToString() == toUnit.Content.ToString())
                {
                    OutputValue.Text = $"{input:F2} {toUnit.Content}";
                }
                else
                {
                    OutputValue.Text = "Conversion not available";
                }
            }
            else
            {
                OutputValue.Text = "Invalid input";
            }
        }

    }
}