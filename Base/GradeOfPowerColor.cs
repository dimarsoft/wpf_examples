using AkaScan.EddyCurrent.Core.Signal;
using System.Collections.Generic;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace AkaScan.EddyCurrent.Core.Base
{
    public class GradeOfPowerColor
    {
        public static readonly Color Grade0 = Color.Gray;
        public static readonly Color Grade1 = Color.Blue;
        public static readonly Color Grade2 = Color.Green;
        public static readonly Color Grade3 = Color.Yellow;
        public static readonly Color Grade4 = Color.Red;

        private readonly IDictionary<GradeOfPower, Color> _dic = new Dictionary<GradeOfPower, Color>()
        {
            { GradeOfPower.Grade0,  Grade0 },
            { GradeOfPower.Grade1,  Grade1 },
            { GradeOfPower.Grade2,  Grade2 },
            { GradeOfPower.Grade3,  Grade3 },
            { GradeOfPower.Grade4,  Grade4 }
        };
        private readonly IDictionary<GradeOfPower, Brush> _dicBrush = new Dictionary<GradeOfPower, Brush>();

        public GradeOfPowerColor()
        {
            foreach (var k in _dic)
            {
                var color = k.Value;
                _dicBrush.Add(k.Key,
                    new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B)));
            }
            foreach (var brush in _dicBrush)
            {
                brush.Value.Freeze();
            }
        }
        public Color GradeColor(GradeOfPower grade)
        {
            return _dic[grade];
        }
        public Brush GradeBrush(GradeOfPower grade)
        {
            return _dicBrush[grade];
        }
    }
}