namespace Canvas2DNet.DrawingObjects
{
    /// <summary>
    /// Line drawing object
    /// </summary>
    public class Canvas2DLine : Canvas2DShape
    {
        /// <summary>
        /// X position for point A
        /// </summary>
        public double Ax
        {
            get => _ax;
            set => SetProperty(ref _ax, value);
        }
        private double _ax;

        /// <summary>
        /// Y position for point A
        /// </summary>
        public double Ay
        {
            get => _ay;
            set => SetProperty(ref _ay, value);
        }
        private double _ay;

        /// <summary>
        /// X position for point B
        /// </summary>
        public double Bx
        {
            get => _bx;
            set => SetProperty(ref _bx, value);
        }
        private double _bx;

        /// <summary>
        /// Y position for point B
        /// </summary>
        public double By
        {
            get => _by;
            set => SetProperty(ref _by, value);
        }
        private double _by;
    }
}
