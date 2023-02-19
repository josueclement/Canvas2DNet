using System.Windows;
using System.Windows.Media;

namespace Canvas2DNet.DrawingObjects
{
    /// <summary>
    /// Base drawing object shape
    /// </summary>
    public abstract class Shape : DrawingObject
    {
        #region Properties

        /// <summary>
        /// Fill brush
        /// </summary>
        public Brush? Fill
        {
            get => _fill;
            set => SetProperty(ref _fill, value);
        }
        private Brush? _fill;

        /// <summary>
        /// Stroke brush
        /// </summary>
        public Brush? Stroke
        {
            get => _stroke;
            set => SetProperty(ref _stroke, value);
        }
        private Brush? _stroke;

        /// <summary>
        /// Stroke thickness
        /// </summary>
        public Thickness StrokeThickness
        {
            get => _strokeThickness;
            set => SetProperty(ref _strokeThickness, value);
        }
        private Thickness _strokeThickness;

        /// <summary>
        /// Stroke dash array
        /// </summary>
        public DoubleCollection? StrokeDashArray
        {
            get => _strokeDashArray;
            set => SetProperty(ref _strokeDashArray, value);
        }
        private DoubleCollection? _strokeDashArray;

        #endregion
    }
}
