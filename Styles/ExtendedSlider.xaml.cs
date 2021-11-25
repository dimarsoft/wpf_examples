using System.Windows.Input;

namespace AkaScan.EddyCurrent.UI.Styles
{
    public partial class ExtendedSlider
    {
        public ExtendedSlider()
        {
            InitializeComponent();

            MouseWheel += UsmSliderMouseWheel;
        }
        private void UsmSliderMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var lines = e.Delta / Mouse.MouseWheelDeltaForOneLine;

            CheckAndSetValue(Value + lines * SmallChange);

            e.Handled = true;

        }
        private void CheckAndSetValue(double newValue)
        {
            if (newValue > Maximum)
                newValue = Maximum;
            else
            {
                if (newValue < Minimum)
                    newValue = Minimum;
            }
            Value = newValue;
        }
    }
}
