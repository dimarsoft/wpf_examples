using System.Windows;
using System.Windows.Media;

namespace AkaScan.EddyCurrent.UI.Buttons
{
    public partial class ParamViewerControl
    {
        public ParamViewerControl()
        {
            InitializeComponent();
        }
        public Brush BorderColor
        {
            get => (Brush)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        public Brush CaptionTextColor
        {
            get => (Brush)GetValue(CaptionColorProperty);
            set => SetValue(CaptionColorProperty, value);
        }
        public Brush ValueTextColor
        {
            get => (Brush)GetValue(ValueColorProperty);
            set => SetValue(ValueColorProperty, value);
        }
        public string CaptionText
        {
            get => (string)GetValue(CaptionTextProperty);
            set => SetValue(CaptionTextProperty, value);
        }
        public string ValueText
        {
            get => (string)GetValue(CaptionTextProperty);
            set => SetValue(CaptionTextProperty, value);
        }
        public bool HideValueText
        {
            get => (bool)GetValue(HideValueTextProperty);
            set => SetValue(HideValueTextProperty, value);
        }

        public static readonly DependencyProperty CaptionTextProperty = DependencyProperty.Register("CaptionText", typeof(string),
            typeof(ParamViewerControl),
            new UIPropertyMetadata(null));
        public static readonly DependencyProperty ValueTextProperty = DependencyProperty.Register("ValueText", typeof(string),
            typeof(ParamViewerControl),
            new UIPropertyMetadata(null));
        public static readonly DependencyProperty HideValueTextProperty = DependencyProperty.Register("HideValueText", typeof(bool),
            typeof(ParamViewerControl),
            new UIPropertyMetadata(null));
        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("BorderColor", typeof(Brush),
            typeof(ParamViewerControl),
            new UIPropertyMetadata(null));
        public static readonly DependencyProperty CaptionColorProperty = DependencyProperty.Register("CaptionTextColor", typeof(Brush),
            typeof(ParamViewerControl),
            new UIPropertyMetadata(null));
        public static readonly DependencyProperty ValueColorProperty = DependencyProperty.Register("ValueTextColor", typeof(Brush),
            typeof(ParamViewerControl),
            new UIPropertyMetadata(null));
    }
}
