using System.Windows.Input;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Media;

namespace Canvas2DNet
{
    /// <summary>
    /// Base behavior for <see cref="Canvas2D"/>
    /// </summary>
    public abstract class Canvas2DBehavior
    {
        /// <inheritdoc/>
        public virtual void OnMouseDown(MouseButtonEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseUp(MouseButtonEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseDoubleClick(MouseButtonEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseWheel(MouseWheelEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseMove(MouseEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseEnter(MouseEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnMouseLeave(MouseEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnKeyDown(KeyEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnKeyUp(KeyEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnPreviewDragEnter(DragEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnPreviewDragLeave(DragEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnPreviewDragOver(DragEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnPreviewDrop(DragEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnDragEnter(DragEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnDragLeave(DragEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnDragOver(DragEventArgs e, Canvas2D canvas)
        { }

        /// <inheritdoc/>
        public virtual void OnDrop(DragEventArgs e, Canvas2D canvas)
        { }

        #region Helpers

        /// <summary>
        /// Get the object under the mouse cursor
        /// </summary>
        /// <param name="root">Root visual object</param>
        /// <param name="mousePosition">Mouse position on the root visual object</param>
        /// <returns></returns>
        protected DependencyObject? HitTest(Visual root, Point mousePosition)
            => VisualTreeHelper.HitTest(root, mousePosition).VisualHit;

        /// <summary>
        /// Get the object DataContext under the mouse cursor
        /// </summary>
        /// <param name="root"></param>
        /// <param name="mousePosition"></param>
        /// <returns></returns>
        protected DrawingObject? HitTestDataContext(Visual root, Point mousePosition)
        {
            DependencyObject? obj = HitTest(root, mousePosition);
            if (obj != null && obj is FrameworkElement element && element.DataContext is DrawingObject drawingObj)
                return drawingObj;
            return null;
        }

        private List<DependencyObject> _hitTestObjects = new List<DependencyObject>();

        /// <summary>
        /// Get the objects
        /// </summary>
        /// <param name="root">Root visual object</param>
        /// <param name="mousePosition">Mouse position on the root visual object</param>
        /// <returns></returns>
        protected List<DependencyObject> HitTestFull(Visual root, Point mousePosition)
        {
            lock (_hitTestObjects)
            {
                _hitTestObjects.Clear();

                VisualTreeHelper.HitTest(root, null,
                    new HitTestResultCallback(MyHitTestResult),
                    new PointHitTestParameters(mousePosition));

                return _hitTestObjects;
            }
        }

        private HitTestResultBehavior MyHitTestResult(HitTestResult result)
        {
            _hitTestObjects.Add(result.VisualHit);
            return HitTestResultBehavior.Continue;
        }

        #endregion
    }
}
