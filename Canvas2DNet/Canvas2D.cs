using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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
            DependencyProperty.Register(nameof(DrawingObjectsDataTemplateSelector), typeof(DrawingObjectsDataTemplateSelector), typeof(Canvas2D), new PropertyMetadata(null));

        /// <summary>
        /// Drawing objects DataTemplateSelector
        /// </summary>
        public DrawingObjectsDataTemplateSelector DrawingObjectsDataTemplateSelector
        {
            get { return (DrawingObjectsDataTemplateSelector)GetValue(DrawingObjectsDataTemplateSelectorProperty); }
            set { SetValue(DrawingObjectsDataTemplateSelectorProperty, value); }
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
    }
}
