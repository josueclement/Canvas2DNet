namespace Canvas2DNet.DrawingObjects
{
    /// <summary>
    /// Ellipse drawing object
    /// </summary>
    public class Ellipse : Shape
    {
        #region Properties

        /// <summary>
        /// Center point X coordinate
        /// </summary>
        public double CenterX
        {
            get => X + Width / 2;
            set => X = value - Width / 2;
        }

        /// <summary>
        /// Center point Y coordinate
        /// </summary>
        public double CenterY
        {
            get => Y + Height / 2;
            set => Y = value - Height / 2;
        }

        #endregion
    }
}
