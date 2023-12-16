using System;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

namespace Canvas2DNet
{
    /// <summary>
    /// Base interactions for <see cref="Canvas2D"/>
    /// </summary>
    public abstract class Canvas2DInteractions : IDisposable
    {
        /// <summary>
        /// Is the object disposed
        /// </summary>
        protected bool Disposed { get;  set; }
        
        /// <summary>
        /// Invoked when a MouseDown event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnMouseDown(Canvas2D canvas, MouseButtonEventArgs args)
        { }

        /// <summary>
        /// Invoked when a MouseUp event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnMouseUp(Canvas2D canvas, MouseButtonEventArgs args)
        { }

        /// <summary>
        /// Invoked when a MouseDoubleClick event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnMouseDoubleClick(Canvas2D canvas, MouseButtonEventArgs args)
        { }

        /// <summary>
        /// Invoked when a MouseWheel event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnMouseWheel(Canvas2D canvas, MouseWheelEventArgs args)
        { }

        /// <summary>
        /// Invoked when a MouseMove event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnMouseMove(Canvas2D canvas, MouseEventArgs args)
        { }

        /// <summary>
        /// Invoked when a MouseEnter event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnMouseEnter(Canvas2D canvas, MouseEventArgs args)
        { }

        /// <summary>
        /// Invoked when a MouseLeave event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnMouseLeave(Canvas2D canvas, MouseEventArgs args)
        { }

        /// <summary>
        /// Invoked when a KeyDown event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnKeyDown(Canvas2D canvas, KeyEventArgs args)
        { }

        /// <summary>
        /// Invoked when a KeyUp event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnKeyUp(Canvas2D canvas, KeyEventArgs args)
        { }

        /// <summary>
        /// Invoked when a PreviewDragEnter event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnPreviewDragEnter(Canvas2D canvas, DragEventArgs args)
        { }

        /// <summary>
        /// Invoked when a PreviewDragLeave event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnPreviewDragLeave(Canvas2D canvas, DragEventArgs args)
        { }

        /// <summary>
        /// Invoked when a PreviewDragOver event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnPreviewDragOver(Canvas2D canvas, DragEventArgs args)
        { }

        /// <summary>
        /// Invoked when a PreviewDrop event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnPreviewDrop(Canvas2D canvas, DragEventArgs args)
        { }

        /// <summary>
        /// Invoked when a DragEnter event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnDragEnter(Canvas2D canvas, DragEventArgs args)
        { }

        /// <summary>
        /// Invoked when a DragLeave event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnDragLeave(Canvas2D canvas, DragEventArgs args)
        { }

        /// <summary>
        /// Invoked when a DragOver event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnDragOver(Canvas2D canvas, DragEventArgs args)
        { }

        /// <summary>
        /// Invoked when a Drop event is raised
        /// </summary>
        /// <param name="canvas">Canvas</param>
        /// <param name="args">Event args</param>
        public virtual void OnDrop(Canvas2D canvas, DragEventArgs args)
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

        /// <inheritdoc/>
        public virtual void Dispose()
        {
            
        }

        // private List<DependencyObject> _hitTestObjects = new List<DependencyObject>();
        //
        // /// <summary>
        // /// Get the objects under the mouse cursor
        // /// </summary>
        // /// <param name="root">Root visual object</param>
        // /// <param name="mousePosition">Mouse position on the root visual object</param>
        // /// <returns></returns>
        // protected IEnumerable<DependencyObject>? HitTestFull(Visual root, Point mousePosition)
        // {
        //     lock (_hitTestObjects)
        //     {
        //         _hitTestObjects.Clear();
        //
        //         VisualTreeHelper.HitTest(root, null,
        //             new HitTestResultCallback(MyHitTestResult),
        //             new PointHitTestParameters(mousePosition));
        //
        //         return _hitTestObjects.ToList();
        //     }
        // }
        //
        // /// <summary>
        // /// Get the objects DataContext under the mouse cursor
        // /// </summary>
        // /// <param name="root">Root visual object</param>
        // /// <param name="mousePosition">Mouse position on the root visual object</param>
        // /// <returns></returns>
        // protected IEnumerable<DrawingObject>? HitTestFullDataContext(Visual root, Point mousePosition)
        // {
        //     foreach (DependencyObject obj in HitTestFull(root, mousePosition) ?? Enumerable.Empty<DependencyObject>())
        //     {
        //         if (obj is FrameworkElement element && element.DataContext is DrawingObject drawingObject)
        //             yield return drawingObject;
        //     }
        // }
        //
        // private HitTestResultBehavior MyHitTestResult(HitTestResult result)
        // {
        //     _hitTestObjects.Add(result.VisualHit);
        //     return HitTestResultBehavior.Continue;
        // }

        #endregion
    }
}
