namespace Canvas2DNet.DrawingObjects
{
    /// <summary>
    /// Rectangle drawing object
    /// </summary>
    public class Rectangle : Shape
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
