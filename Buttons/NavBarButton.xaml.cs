using System.Windows;
using System.Windows.Media;

namespace AkaScan.EddyCurrent.UI.Buttons
{
    /// <summary>
    /// Interaction logic for NavBarButton.xaml
    /// </summary>
    public partial class NavBarButton
    {
        //Unless you override the style it will never be rendered
        /*static NavBarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavBarButton), new FrameworkPropertyMetadata(typeof(NavBarButton)));
        }*/
        public NavBarButton()
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
            typeof(NavBarButton),
            new UIPropertyMetadata(null));
        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("BorderColor", typeof(Brush),
            typeof(NavBarButton),
            new UIPropertyMetadata(null));
    }
}
