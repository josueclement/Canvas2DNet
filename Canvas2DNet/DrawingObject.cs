using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Media;
using System.Windows;
using System;

namespace Canvas2DNet;

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

    #region Events

    /// <summary>
    /// Occurs when the DrawingObject is clicked in the canvas
    /// </summary>
    public event EventHandler<Point>? Clicked;

    /// <summary>
    /// Raise the <see cref="Clicked"/> event
    /// </summary>
    /// <param name="point">Mouse point on the canvas</param>
    public void RaiseClicked(Point point)
        => Clicked?.Invoke(this, point);

    /// <summary>
    /// Occurs when the DrawingObject is moving in the canvas
    /// </summary>
    public event MouseMovementEventHandler? Moving;

    /// <summary>
    /// Raise the <see cref="Moving"/> event
    /// </summary>
    /// <param name="mousePosition">Mouse point on the canvas</param>
    /// <param name="offset">Offset from last position</param>
    public void RaiseMoving(Point mousePosition, Vector offset)
        => Moving?.Invoke(this, new MouseMovementEventArgs(mousePosition, offset));

    /// <summary>
    /// Occurs when the DrawingObject is moved in the canvas
    /// </summary>
    public event MouseMovementEventHandler? Moved;

    /// <summary>
    /// Raise the <see cref="Moved"/> event
    /// </summary>
    /// <param name="mousePosition">Mouse point on the canvas</param>
    /// <param name="offset">Offset from last position</param>
    public void RaiseMoved(Point mousePosition, Vector offset)
        => Moved?.Invoke(this, new MouseMovementEventArgs(mousePosition, offset));

    /// <summary>
    /// Occurs when the mouse is entering the DrawingObject in the canvas
    /// </summary>
    public event EventHandler? MouseEnter;

    /// <summary>
    /// Raise the <see cref="MouseEnter"/> event
    /// </summary>
    public void RaiseMouseEnter()
        => MouseEnter?.Invoke(this, EventArgs.Empty);

    /// <summary>
    /// Occurs when the mouse is leaving the DrawingObject in the canvas
    /// </summary>
    public event EventHandler? MouseLeave;

    /// <summary>
    /// Raise the <see cref="MouseLeave"/> event
    /// </summary>
    public void RaiseMouseLeave()
        => MouseLeave?.Invoke(this, EventArgs.Empty);

    /// <summary>
    /// Occurs when the mouse is moving over the DrawingObject
    /// </summary>
    public event EventHandler<Point>? MouseMovingOver;

    /// <summary>
    /// Raise the <see cref="MouseMovingOver"/> event
    /// </summary>
    /// <param name="mousePosition">Mouse position on the canvas</param>
    public void RaiseMouseMovingOver(Point mousePosition)
        => MouseMovingOver?.Invoke(this, mousePosition);

    #endregion
}

/// <summary>
/// Event args for mouse movements
/// </summary>
public class MouseMovementEventArgs : EventArgs
{
    /// <summary>
    /// Constructor for <see cref="MouseMovementEventArgs"/>
    /// </summary>
    /// <param name="mousePosition">Mouse position</param>
    /// <param name="offset">Offset from last position</param>
    public MouseMovementEventArgs(Point mousePosition, Vector offset)
    {
        MousePosition = mousePosition;
        Offset = offset;
    }

    /// <summary>
    /// Mouse position
    /// </summary>
    public Point MousePosition { get; }
    /// <summary>
    /// Offset from last position
    /// </summary>
    public Vector Offset { get; }
}

/// <summary>
/// Event handler for mouse movements
/// </summary>
/// <param name="sender">Sender</param>
/// <param name="args">Mouse movement args</param>
public delegate void MouseMovementEventHandler(object sender, MouseMovementEventArgs args);