using System.Windows;
using System.Windows.Input;

namespace Canvas2DNet.Interactions
{
    /// <summary>
    /// Default interactions for <see cref="Canvas2D"/>
    /// </summary>
    public class StandardInteractions : Canvas2DInteractions
    {
        /// <summary>
        /// Moving object
        /// </summary>
        protected DrawingObject? _movingObject;

        /// <summary>
        /// Moving position
        /// </summary>
        protected Point _movingPosition;

        /// <summary>
        /// Object under the mouse cursor
        /// </summary>
        protected DrawingObject? _mouseOverObject;

        /// <inheritdoc/>
        public override void OnMouseDown(MouseButtonEventArgs e, Canvas2D canvas)
        {
            Point mousePosition = e.GetPosition(canvas);
            DrawingObject? drawingObject = HitTestDataContext(canvas, mousePosition);

            if (e.ChangedButton == MouseButton.Left && drawingObject != null)
            {
                _movingObject = drawingObject;
                _movingPosition = mousePosition;
                _movingObject.RaiseClicked(mousePosition);
            }
        }

        /// <inheritdoc/>
        public override void OnMouseUp(MouseButtonEventArgs e, Canvas2D canvas)
        {
            Point mousePosition = e.GetPosition(canvas);

            if (e.ChangedButton == MouseButton.Left && _movingObject != null)
            {
                _movingObject.RaiseMoved(mousePosition, mousePosition - _movingPosition);
                _movingObject = null;
            }
        }

        /// <inheritdoc/>
        public override void OnMouseMove(MouseEventArgs e, Canvas2D canvas)
        {
            Point mousePosition = e.GetPosition(canvas);
            if (_movingObject != null)
            {
                _movingObject.RaiseMoving(mousePosition, mousePosition - _movingPosition);
                _movingPosition = mousePosition;
                return;
            }

            DrawingObject? drawingObject = HitTestDataContext(canvas, mousePosition);

            if (_mouseOverObject == null && drawingObject != null)
            {
                _mouseOverObject = drawingObject;
                _mouseOverObject.RaiseMouseEnter();
            }
            else if (_mouseOverObject != null)
            {
                if (drawingObject == null)
                {
                    _mouseOverObject.RaiseMouseLeave();
                    _mouseOverObject = null;
                }
                else if (_mouseOverObject != drawingObject)
                {
                    _mouseOverObject.RaiseMouseLeave();
                    _mouseOverObject = drawingObject;
                    _mouseOverObject.RaiseMouseEnter();
                }
                else
                {
                    _mouseOverObject.RaiseMouseMovingOver(mousePosition);
                }
            }
        }
    }
}
