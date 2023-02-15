using System.Globalization;
using System.Windows.Media;

namespace Canvas2DNet.Utils
{
    public static class ColorsExtensions
    {
        /// <summary>
        /// Returns a color from a RGBA hex string
        /// </summary>
        /// <param name="rgbaHex">RGBA hex string</param>
        /// <returns><see cref="Color"/></returns>
        public static Color RgbaHexToColor(this string rgbaHex)
        {
            int startIndex = rgbaHex.StartsWith("#") ? 1 : 0;

            // Parse the hex string and extract the red, green, blue, and alpha components
            byte r = byte.Parse(rgbaHex.Substring(startIndex + 0, 2), NumberStyles.HexNumber);
            byte g = byte.Parse(rgbaHex.Substring(startIndex + 2, 2), NumberStyles.HexNumber);
            byte b = byte.Parse(rgbaHex.Substring(startIndex + 4, 2), NumberStyles.HexNumber);
            byte a = byte.Parse(rgbaHex.Substring(startIndex + 6, 2), NumberStyles.HexNumber);

            // Create and return a new Color object
            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// Returns a Brush from a RGBA hex string
        /// </summary>
        /// <param name="rgbaHex">RGBA hex string</param>
        /// <returns><see cref="Brush"/></returns>
        public static Brush RgbaHexToBrush(this string rgbaHex)
            => new SolidColorBrush(rgbaHex.RgbaHexToColor());
    }
}
