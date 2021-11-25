using System.Windows;
using System.Windows.Media;

namespace AkaScan.EddyCurrent.UI.Buttons
{
    /// <summary>
    /// Interaction logic for ImagedButton.xaml
    /// </summary>
    public partial class ImagedButton
    {
        public static readonly DependencyProperty CaptionTextProperty = DependencyProperty.Register("CaptionText", typeof(string), typeof(ImagedButton), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(ImagedButton), new PropertyMetadata(null));
        public static readonly DependencyProperty CaptionTextColorProperty = DependencyProperty.Register("CaptionTextColor", typeof(Brush), typeof(ImagedButton), new PropertyMetadata(null));

        public ImagedButton()
        {
            InitializeComponent();
        }

        public string CaptionText
        {
            get => (string)GetValue(CaptionTextProperty);
            set => SetValue(CaptionTextProperty, value);
        }

        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public Brush CaptionTextColor
        {
            get => (Brush)GetValue(CaptionTextColorProperty);
            set => SetValue(CaptionTextColorProperty, value);
        }
    }
}
