using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace TextBoxAndSlider
{
    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var binding = new Binding("Value") {Source = Slider1};
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            var rvr = new RangeValidationRule();
            rvr.ValidatesOnTargetUpdated = true;
            binding.ValidationRules.Add(rvr);
            binding.NotifyOnValidationError = true;
            TextBox1.SetBinding(TextBox.TextProperty, binding);

            TextBox1.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(this.ValidationError));
        }

        public class RangeValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                double d = 0;
                if (double.TryParse(value.ToString(), out d))
                {
                    if (d >= 0 && d <= 100)
                    {
                        return new ValidationResult(true, null);
                    }
                }
                return new ValidationResult(false, "Validation Failed.");
            }
        }

        void ValidationError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(this.TextBox1).Count > 0)
            {
                this.TextBox1.ToolTip = Validation.GetErrors(this.TextBox1)[0].ErrorContent.ToString();
            }
        }
        
        
    }
}