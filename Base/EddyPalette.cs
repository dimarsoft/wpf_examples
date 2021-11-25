using AkaScan.EddyCurrent.Core.Settings;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;
using Color = System.Drawing.Color;
using WpfColor = System.Windows.Media.Color;

namespace AkaScan.EddyCurrent.Core.Base
{
    public interface IEddyPalette
    {
        Brush GetPaletteBrush(double v);
        Brush GetPaletteBrush(int v);
    }
    public class EddyPalette : IEddyPalette
    {
        public EddyPalette()
        {
            StopsToDefault();
        }
        private void StopsToDefault()
        {
            var defaultStops = DefaultStopsLight;
            Stops = new GradientStop[defaultStops.Length];

            for (var i = 0; i < defaultStops.Length; i++)
            {
                Stops[i] = defaultStops[i].Clone();
            }
        }

        public GradientStop[] Stops { get; set; }
        /// <summary>
        /// Настройка по умолчанию.
        /// </summary>
        private static readonly GradientStop[] DefaultStops =
        {
            new GradientStop(0.00, Color.FromArgb(0x00, 0x00, 0xff)),
            new GradientStop(0.33, Color.FromArgb(0x00, 0xff, 0x00)),
            new GradientStop(0.66, Color.FromArgb(0xff, 0xff, 0x00)),
            new GradientStop(1.00, Color.FromArgb(0xff, 0x00, 0x00))
        };
        /// <summary>
        /// Настройка по умолчанию.
        /// </summary>
        private static readonly GradientStop[] DefaultStopsLight =
        {
            new GradientStop(0.00, Color.FromArgb(0x00, 0xff, 0xff)),
            new GradientStop(0.33, Color.FromArgb(0x00, 0xff, 0x00)),
            new GradientStop(0.66, Color.FromArgb(0xff, 0xff, 0x00)),
            new GradientStop(1.00, Color.FromArgb(0xff, 0x00, 0x00))
        };

        public Brush GetPaletteBrush(double v)
        {
            var color = GetPaletteColor(v);

            return new SolidColorBrush(WpfColor.FromArgb(color.A, color.R, color.G, color.B));
        }

        public Brush GetPaletteBrush(int v)
        {
            var color = GetPaletteColor(v);

            return new SolidColorBrush(WpfColor.FromArgb(color.A, color.R, color.G, color.B));
        }

        public Color GetPaletteColor(double v)
        {
            GradientStop left = null;
            GradientStop right = null;
            foreach (var p in Stops)
            {
                if (p.Offset <= v)
                {
                    if (left == null || p.Offset > left.Offset)
                        left = p;
                }
                if (p.Offset >= v)
                {
                    if (right == null || p.Offset < right.Offset)
                        right = p;
                }
            }

            if (left == null && right == null)
                throw new NullReferenceException($"{nameof(left)}, {nameof(right)}");

            if (left == null)
                return right.Color;
            if (right == null)
                return left.Color;

            if (v <= left.Offset)
                return left.Color;
            if (v >= right.Offset)
                return right.Color;

            double toLeft = Math.Abs(left.Offset - v);
            double leftToRight = Math.Abs(right.Offset - left.Offset);

            double deltaR = (right.Color.R - left.Color.R) / leftToRight;
            double deltaG = (right.Color.G - left.Color.G) / leftToRight;
            double deltaB = (right.Color.B - left.Color.B) / leftToRight;

            double r = left.Color.R + deltaR * toLeft;
            double g = left.Color.G + deltaG * toLeft;
            double b = left.Color.B + deltaB * toLeft;

            return Color.FromArgb((int)r, (int)g, (int)b);
        }
        public Color GetPaletteColor(int v)
        {
            Color? color = null;
            /*
             * Цветов 8 и 2 варианта alpha, получаем 16 цветов для каналов
             */
            var index = (v % ChannelsSettings.DefaultChannelsCount16) / 2;
            var isOdd = v % 2 == 1;
            var alpha = isOdd ? 0xff >> 1 : 0xff;

            switch (index + 1)
            {
                case 1:
                    color = Color.FromArgb(alpha, 0xff, 0x00, 0x00);
                    break;
                case 2:
                    color = Color.FromArgb(alpha, 0xff, 0xff, 0x00);
                    break;
                case 3:
                    color = Color.FromArgb(alpha, 0x00, 0xff, 0x00);
                    break;
                case 4:
                    color = Color.FromArgb(alpha, 0x00, 0xff, 0xff);
                    break;
                case 5:
                    color = Color.FromArgb(alpha, 0x00, 0x00, 0xff);
                    break;
                case 6:
                    color = Color.FromArgb(alpha, 0xff, 0x00, 0xff);
                    break;
                case 7:
                    color = Color.FromArgb(alpha, 0x00, 0xff, 0x7f);
                    break;
                case 8:
                    color = Color.FromArgb(alpha, 0x80, 0x80, 0x80);
                    break;
            }
            return color ?? Color.White;
        }
        [Serializable]
        public sealed class GradientStop : IComparable<GradientStop>, ICloneable<GradientStop>
        {
            #region Equals
            public bool Equals(GradientStop other)
            {
                return Offset.Equals(other.Offset) && Color.Equals(other.Color);
            }

            public GradientStop Clone()
            {
                return new GradientStop(Offset, Color);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals((GradientStop)obj);
            }

            public override int GetHashCode()
            {
                return (Offset.GetHashCode() * 397) ^ Color.GetHashCode();
            }

            public static bool operator ==(GradientStop left, GradientStop right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(GradientStop left, GradientStop right)
            {
                return !Equals(left, right);
            }
            #endregion

            public GradientStop()
            {
            }

            public GradientStop(double offset, Color color)
            {
                Offset = offset;
                Color = color;
            }
            /// <summary>
            /// Смещение точки градиента. (0.0-1.0)
            /// </summary>
            public double Offset { get; }
            /// <summary>
            /// Цвет точки градиента.
            /// </summary>
            public Color Color { get; }
            /// <summary>
            /// Цвет точки градиента.WPF формат.
            /// </summary>
            public WpfColor WpfColor => WpfColor.FromArgb(Color.A, Color.R, Color.G, Color.B);

            public int CompareTo(GradientStop other)
            {
                return Offset.CompareTo(other.Offset);
            }
        }

        public class EddyPaletteCash : IEddyPalette
        {
            private readonly IEddyPalette _baseEddyPalette;
            private readonly Dictionary<int, Brush> _brushes = new Dictionary<int, Brush>();
            private readonly Dictionary<int, Brush> _brushesByInt = new Dictionary<int, Brush>();

            public EddyPaletteCash(IEddyPalette baseEddyPalette)
            {
                _baseEddyPalette = baseEddyPalette;
            }

            public Brush GetPaletteBrush(double v)
            {
                int key = (int)(v * 1000);
                if (_brushes.TryGetValue(key, out var nr))
                {
                    return nr;
                }

                var newBr = _baseEddyPalette.GetPaletteBrush(v);
                _brushes[key] = newBr;
                return newBr;
            }

            public Brush GetPaletteBrush(int v)
            {
                if (_brushesByInt.TryGetValue(v, out var nr))
                {
                    return nr;
                }

                var newBr = _baseEddyPalette.GetPaletteBrush(v);
                _brushesByInt[v] = newBr;
                return newBr;
            }
        }
    }
}