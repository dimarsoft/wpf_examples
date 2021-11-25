using System.Windows;
using System.Windows.Media;

namespace AkaScan.EddyCurrent.UI.Buttons
{
    /// <summary>
    /// Interaction logic for ImagedToggleButton.xaml
    /// </summary>
    public partial class ImagedToggleButton
    {
        public static readonly DependencyProperty CaptionTextProperty = DependencyProperty.Register("CaptionText", typeof(string), typeof(ImagedToggleButton), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty ImageOnProperty = DependencyProperty.Register("ImageOn", typeof(ImageSource), typeof(ImagedToggleButton), new PropertyMetadata(null));
        public static readonly DependencyProperty ImageOffProperty = DependencyProperty.Register("ImageOff", typeof(ImageSource), typeof(ImagedToggleButton), new PropertyMetadata(null));
        public static readonly DependencyProperty CaptionTextColorProperty = DependencyProperty.Register("CaptionTextColor", typeof(Brush), typeof(ImagedToggleButton), new PropertyMetadata(null));
        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("BorderColor", typeof(Brush),
            typeof(ImagedToggleButton),
            new UIPropertyMetadata(null));

        public ImagedToggleButton()
        {
            InitializeComponent();
        }
        public Brush BorderColor
        {
            get => (Brush)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        public string CaptionText
        {
            get => (string)GetValue(CaptionTextProperty);
            set => SetValue(CaptionTextProperty, value);
        }

        public ImageSource ImageOn
        {
            get => (ImageSource)GetValue(ImageOnProperty);
            set => SetValue(ImageOnProperty, value);
        }
        public ImageSource ImageOff
        {
            get => (ImageSource)GetValue(ImageOffProperty);
            set => SetValue(ImageOffProperty, value);
        }

        public Brush CaptionTextColor
        {
            get => (Brush)GetValue(CaptionTextColorProperty);
            set => SetValue(CaptionTextColorProperty, value);
        }
    }
}