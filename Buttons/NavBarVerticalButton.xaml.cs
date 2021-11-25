using System.Windows;
using System.Windows.Media;

namespace AkaScan.EddyCurrent.UI.Buttons
{
    /// <summary>
    /// Interaction logic for NavBarVerticalButton.xaml
    /// </summary>
    public partial class NavBarVerticalButton
    {
        public NavBarVerticalButton()
        {
            InitializeComponent();
        }
        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
        public Brush BorderColor
        {
            get => (Brush)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource),
            typeof(NavBarVerticalButton),
            new UIPropertyMetadata(null));
        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("BorderColor", typeof(Brush),
            typeof(NavBarVerticalButton),
            new UIPropertyMetadata(null));
        public static readonly DependencyProperty ButtonContentProperty = DependencyProperty.Register("ButtonContent", typeof(FrameworkElement), typeof(NavBarVerticalButton));
        /// <summary>
        /// Легенда оси Y
        /// </summary>
        public FrameworkElement ButtonContent
        {
            get => (FrameworkElement)GetValue(ButtonContentProperty);
            set => SetValue(ButtonContentProperty, value);
        }
    }
}
