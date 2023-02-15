using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Media;
using System.Windows;

namespace Canvas2DNet
{
    /// <summary>
    /// Object drawn on the <see cref="Canvas2D"/>
    /// </summary>
    public abstract class DrawingObject : ObservableObject
    {
        #region Properties

        /// <summary>
        /// X Position on canvas
        /// </summary>
        public double X
        {
            get => _x;
            set => SetProperty(ref _x, value);
        }
        private double _x;

        /// <summary>
        /// Y Position on canvas
        /// </summary>
        public double Y
        {
            get => _y;
            set => SetProperty(ref _y, value);
        }
        private double _y;

        /// <summary>
        /// ZIndex on canvas
        /// </summary>
        public int ZIndex
        {
            get => _zIndex;
            set => SetProperty(ref _zIndex, value);
        }
        private int _zIndex;

        /// <summary>
        /// Width
        /// </summary>
        public double Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }
        private double _width;

        /// <summary>
        /// Height
        /// </summary>
        public double Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }
        private double _height;

        /// <summary>
        /// Transform information
        /// </summary>
        public Transform? RenderTransform
        {
            get => _renderTransform;
            set => SetProperty(ref _renderTransform, value);
        }
        private Transform? _renderTransform;

        /// <summary>
        /// Transform origin point
        /// </summary>
        public Point RenderTransformOrigin
        {
            get => _renderTransformOrigin;
            set => SetProperty(ref _renderTransformOrigin, value);
        }
        private Point _renderTransformOrigin;

        /// <summary>
        /// Specify the display state of the item
        /// </summary>
        public Visibility Visibility
        {
            get => _visibility;
            set => SetProperty(ref _visibility, value);
        }
        private Visibility _visibility;

        /// <summary>
        /// Determines if the item has a fixed position in the canvas
        /// </summary>
        public bool FixedPosition
        {
            get => _fixedPosition;
            set => SetProperty(ref _fixedPosition, value);
        }
        private bool _fixedPosition;

        #endregion
    }
}
