using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AkaScan.EddyCurrent.UI.Buttons
{
    /// <summary>
    /// Interaction logic for NavBarButtonTemplate.xaml
    /// </summary>
    public partial class NavBarButtonTemplate
    {
        public static readonly DependencyProperty TemplateButtonProperty = DependencyProperty.Register("TemplateButton", typeof(ControlTemplate), typeof(NavBarButtonTemplate), new PropertyMetadata(default(object)));
        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("BorderColor", typeof(Brush),
            typeof(NavBarButtonTemplate),
            new UIPropertyMetadata(null));
        public NavBarButtonTemplate()
        {
            InitializeComponent();
        }
        public Brush BorderColor
        {
            get => (Brush)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        public ControlTemplate TemplateButton
        {
            get => (ControlTemplate)GetValue(TemplateButtonProperty);
            set => SetValue(TemplateButtonProperty, value);
        }
    }
}
