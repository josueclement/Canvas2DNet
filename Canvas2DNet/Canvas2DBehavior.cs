using System.Windows.Input;
using System.Windows;

namespace Canvas2DNet
{
    /// <summary>
    /// Base behavior for <see cref="Canvas2D"/>
    /// </summary>
    public abstract class Canvas2DBehavior
    {
        /// <inheritdoc/>
        public virtual void OnMouseDown(MouseButtonEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseUp(MouseButtonEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseDoubleClick(MouseButtonEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseWheel(MouseWheelEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseMove(MouseEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseEnter(MouseEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseLeave(MouseEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnKeyDown(KeyEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnKeyUp(KeyEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnPreviewDragEnter(DragEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnPreviewDragLeave(DragEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnPreviewDragOver(DragEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnPreviewDrop(DragEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnDragEnter(DragEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnDragLeave(DragEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnDragOver(DragEventArgs e)
        { }

        /// <inheritdoc/>
        public virtual void OnDrop(DragEventArgs e)
        { }
    }

    /// <summary>
    /// Default behavior for <see cref="Canvas2D"/>
    /// </summary>
    public class Canvas2DDefaultBehavior : Canvas2DBehavior
    { }
}
