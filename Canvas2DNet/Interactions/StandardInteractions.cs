using System.Windows;
using System.Windows.Input;

namespace Canvas2DNet.Interactions;

/// <summary>
/// Default interactions for <see cref="Canvas2D"/>
/// </summary>
public class StandardInteractions : Canvas2DInteractions
{
    /// <summary>
    /// Moving object
    /// </summary>
    private DrawingObject? _movingObject;

    /// <summary>
    /// Moving position
    /// </summary>
    private Point _movingPosition;

    /// <summary>
    /// Object under the mouse cursor
    /// </summary>
    private DrawingObject? _mouseOverObject;

    /// <inheritdoc/>
    public override void OnMouseDown(Canvas2D canvas, MouseButtonEventArgs args)
    {
        if (Disposed)
            return;
        
        Point mousePosition = args.GetPosition(canvas);
        DrawingObject? drawingObject = HitTestDataContext(canvas, mousePosition);

        if (args.ChangedButton == MouseButton.Left && drawingObject != null)
        {
            _movingObject = drawingObject;
            _movingPosition = mousePosition;
            _movingObject.RaiseClicked(mousePosition);
        }
    }

    /// <inheritdoc/>
    public override void OnMouseUp(Canvas2D canvas, MouseButtonEventArgs args)
    {
        if (Disposed)
            return;
        
        Point mousePosition = args.GetPosition(canvas);

        if (args.ChangedButton == MouseButton.Left && _movingObject != null)
        {
            _movingObject.RaiseMoved(mousePosition, mousePosition - _movingPosition);
            _movingObject = null;
        }
    }

    /// <inheritdoc/>
    public override void OnMouseMove(Canvas2D canvas, MouseEventArgs args)
    {
        if (Disposed)
            return;
        
        Point mousePosition = args.GetPosition(canvas);
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

    /// <inheritdoc />
    public override void Dispose()
    {
        _movingObject = null;
        _mouseOverObject = null;

        Disposed = true;
    }
}
