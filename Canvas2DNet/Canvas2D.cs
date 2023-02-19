using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Canvas2DNet
{
    /// <summary>
    /// Canvas2D control that will display drawing objects
    /// </summary>
    public class Canvas2D : Control
    {
        private FrameworkElement? PART_container;

        static Canvas2D()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Canvas2D), new FrameworkPropertyMetadata(typeof(Canvas2D)));
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            PART_container = (FrameworkElement)Template.FindName("PART_container", this);
            if (PART_container != null )
            {
                PART_container.Loaded += (s, e) => RaiseCanvasLoadedEvent();
            }
            base.OnApplyTemplate();
        }

        #region Dependency properties

        /// <summary>
        /// Drawing objects dependency property
        /// </summary>
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(ObservableCollection<DrawingObject>), typeof(Canvas2D), new PropertyMetadata(default));

        /// <summary>
        /// Drawing objects
        /// </summary>
        public ObservableCollection<DrawingObject> Items
        {
            get { return (ObservableCollection<DrawingObject>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        /// <summary>
        /// Drawing objects DataTemplateSelector dependency property
        /// </summary>
        public static readonly DependencyProperty DrawingObjectsDataTemplateSelectorProperty =
            DependencyProperty.Register(nameof(DrawingObjectsDataTemplateSelector), typeof(DrawingObjectsDataTemplateSelector), typeof(Canvas2D), new PropertyMetadata(default));

        /// <summary>
        /// Drawing objects DataTemplateSelector
        /// </summary>
        public DrawingObjectsDataTemplateSelector DrawingObjectsDataTemplateSelector
        {
            get { return (DrawingObjectsDataTemplateSelector)GetValue(DrawingObjectsDataTemplateSelectorProperty); }
            set { SetValue(DrawingObjectsDataTemplateSelectorProperty, value); }
        }

        /// <summary>
        /// Canvas interactions dependency property
        /// </summary>
        public static readonly DependencyProperty CanvasInteractionsProperty =
            DependencyProperty.Register(nameof(CanvasInteractions), typeof(Canvas2DInteractions), typeof(Canvas2D), new PropertyMetadata(default));

        /// <summary>
        /// Canvas interactions
        /// </summary>
        public Canvas2DInteractions CanvasInteractions
        {
            get { return (Canvas2DInteractions)GetValue(CanvasInteractionsProperty); }
            set {  SetValue(CanvasInteractionsProperty, value); }
        }

        #endregion

        #region Events

        /// <summary>
        /// Routed event for CanvasLoaded
        /// </summary>
        public static readonly RoutedEvent CanvasLoadedEvent = EventManager.RegisterRoutedEvent(
            name: nameof(CanvasLoaded),
            routingStrategy: RoutingStrategy.Bubble,
            handlerType: typeof(RoutedEventHandler),
            ownerType: typeof(Canvas2D));

        /// <summary>
        /// Occurs when the canvas is loaded
        /// </summary>
        public event RoutedEventHandler CanvasLoaded
        {
            add { AddHandler(CanvasLoadedEvent, value); }
            remove { RemoveHandler(CanvasLoadedEvent, value); }
        }

        /// <summary>
        /// Raise the CanvasLoadedEvent RoutedEvent
        /// </summary>
        protected void RaiseCanvasLoadedEvent()
        {
            RoutedEventArgs routedEventArgs = new(routedEvent: CanvasLoadedEvent);
            RaiseEvent(routedEventArgs);
        }

        #endregion

        #region Mouse-Keyboard events handlers

        /// <inheritdoc/>
        protected override void OnMouseDown(MouseButtonEventArgs e)
            => CanvasInteractions?.OnMouseDown(e, this);

        /// <inheritdoc/>
        protected override void OnMouseUp(MouseButtonEventArgs e)
            => CanvasInteractions?.OnMouseUp(e, this);

        /// <inheritdoc/>
        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
            => CanvasInteractions?.OnMouseDoubleClick(e, this);

        /// <inheritdoc/>
        protected override void OnMouseWheel(MouseWheelEventArgs e)
            => CanvasInteractions?.OnMouseWheel(e, this);

        /// <inheritdoc/>
        protected override void OnMouseMove(MouseEventArgs e)
            => CanvasInteractions?.OnMouseMove(e, this);

        /// <inheritdoc/>
        protected override void OnMouseEnter(MouseEventArgs e)
            => CanvasInteractions?.OnMouseEnter(e, this);

        /// <inheritdoc/>
        protected override void OnMouseLeave(MouseEventArgs e)
            => CanvasInteractions?.OnMouseLeave(e, this);

        /// <inheritdoc/>
        protected override void OnKeyDown(KeyEventArgs e)
            => CanvasInteractions?.OnKeyDown(e, this);

        /// <inheritdoc/>
        protected override void OnKeyUp(KeyEventArgs e)
            => CanvasInteractions?.OnKeyUp(e, this);

        /// <inheritdoc/>
        protected override void OnPreviewDragEnter(DragEventArgs e)
            => CanvasInteractions?.OnPreviewDragEnter(e, this);

        /// <inheritdoc/>
        protected override void OnPreviewDragLeave(DragEventArgs e)
            => CanvasInteractions?.OnPreviewDragLeave(e, this);

        /// <inheritdoc/>
        protected override void OnPreviewDragOver(DragEventArgs e)
            => CanvasInteractions?.OnPreviewDragOver(e, this);

        /// <inheritdoc/>
        protected override void OnPreviewDrop(DragEventArgs e)
            => CanvasInteractions?.OnPreviewDrop(e, this);

        /// <inheritdoc/>
        protected override void OnDragEnter(DragEventArgs e)
            => CanvasInteractions?.OnDragEnter(e, this);

        /// <inheritdoc/>
        protected override void OnDragLeave(DragEventArgs e)
            => CanvasInteractions?.OnDragLeave(e, this);

        /// <inheritdoc/>
        protected override void OnDragOver(DragEventArgs e)
            => CanvasInteractions?.OnDragOver(e, this);

        /// <inheritdoc/>
        protected override void OnDrop(DragEventArgs e)
            => CanvasInteractions?.OnDrop(e, this);

        #endregion
    }
}
