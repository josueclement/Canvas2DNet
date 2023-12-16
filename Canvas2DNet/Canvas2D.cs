using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
        static Canvas2D()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Canvas2D), new FrameworkPropertyMetadata(typeof(Canvas2D)));
        }
        
        #region DrawingObjects

        /// <summary>
        /// DrawingObjects
        /// </summary>
        [Bindable(true)]
        public ObservableCollection<DrawingObject>? DrawingObjects
        {
            get => (ObservableCollection<DrawingObject>?)GetValue(DrawingObjectsProperty);
            set => SetValue(DrawingObjectsProperty, value);
        }

        /// <summary>
        /// DrawingObjects property
        /// </summary>
        public static readonly DependencyProperty DrawingObjectsProperty =
            DependencyProperty.Register(
                name: nameof(DrawingObjects),
                propertyType: typeof(ObservableCollection<DrawingObject>),
                ownerType: typeof(Canvas2D),
                typeMetadata: new PropertyMetadata(new ObservableCollection<DrawingObject>()));
        
        #endregion
        
        #region DrawingObjectsGroups

        /// <summary>
        /// DrawingObjectsGroups
        /// </summary>
        [Bindable(true)]
        public ObservableCollection<DrawingObjectsGroup>? DrawingObjectsGroups
        {
            get => (ObservableCollection<DrawingObjectsGroup>?)GetValue(DrawingObjectsGroupsProperty);
            set => SetValue(DrawingObjectsGroupsProperty, value);
        }

        /// <summary>
        /// DrawingObjectsGroups property
        /// </summary>
        public static readonly DependencyProperty DrawingObjectsGroupsProperty =
            DependencyProperty.Register(
                name: nameof(DrawingObjectsGroups),
                propertyType: typeof(ObservableCollection<DrawingObjectsGroup>),
                ownerType: typeof(Canvas2D),
                typeMetadata: new PropertyMetadata(
                    defaultValue: new ObservableCollection<DrawingObjectsGroup>(),
                    propertyChangedCallback: OnDrawingObjectsGroupsPropertyChanged));

        /// <summary>
        /// Called when <see cref="DrawingObjectsGroupsProperty"/> has changed
        /// </summary>
        /// <param name="obj">Canvas</param>
        /// <param name="args">Event args</param>
        private static void OnDrawingObjectsGroupsPropertyChanged(
            DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            if (obj is Canvas2D canvas)
            {
                if (args.OldValue is ObservableCollection<DrawingObjectsGroup> oldValue)
                {
                    oldValue.CollectionChanged -= canvas.OnDrawingObjectsGroupsChanged;
                    canvas.RemoveGroupsDrawingObjects(oldValue);
                }

                if (args.NewValue is ObservableCollection<DrawingObjectsGroup> newValue)
                {
                    newValue.CollectionChanged += canvas.OnDrawingObjectsGroupsChanged;
                    canvas.AddGroupsDrawingObjects(newValue);
                }
            }
        }

        /// <summary>
        /// Called when <see cref="DrawingObjectsGroups"/> has changed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Event args</param>
        private void OnDrawingObjectsGroupsChanged(
            object? sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs args)
        {
            if (args.OldItems != null)
                RemoveGroupsDrawingObjects(args.OldItems);
            if (args.NewItems != null)
                AddGroupsDrawingObjects(args.NewItems);
        }

        private void AddGroupsDrawingObjects(IEnumerable? groups)
        {
            foreach (DrawingObjectsGroup group in groups ?? Enumerable.Empty<DrawingObjectsGroup>())
            {
                foreach (DrawingObject drawingObject in group.DrawingObjects)
                    DrawingObjects?.Add(drawingObject);
            }
        }
        
        private void RemoveGroupsDrawingObjects(IEnumerable? groups)
        {
            foreach (DrawingObjectsGroup group in groups ?? Enumerable.Empty<DrawingObjectsGroup>())
            {
                group.UnregisterDrawingObjectsEvents();
        
                foreach (DrawingObject drawingObject in group.DrawingObjects)
                    DrawingObjects?.Remove(drawingObject);
            }
        }
        
        #endregion
        
        #region DrawingObjectsDataTemplateSelector

        /// <summary>
        /// DrawingObjectsDataTemplateSelector
        /// </summary>
        [Bindable(true)]
        public DrawingObjectsDataTemplateSelector? DrawingObjectsDataTemplateSelector
        {
            get => (DrawingObjectsDataTemplateSelector?)GetValue(DrawingObjectsDataTemplateSelectorProperty); 
            set => SetValue(DrawingObjectsDataTemplateSelectorProperty, value); 
        }

        /// <summary>
        /// DrawingObjectsDataTemplateSelectorProperty
        /// </summary>
        public static readonly DependencyProperty DrawingObjectsDataTemplateSelectorProperty =
            DependencyProperty.Register(
                name: nameof(DrawingObjectsDataTemplateSelector),
                propertyType: typeof(DrawingObjectsDataTemplateSelector),
                ownerType: typeof(Canvas2D),
                typeMetadata: new PropertyMetadata(defaultValue: null));
        
        #endregion
        
        #region CanvasInteractions

        /// <summary>
        /// Canvas interactions
        /// </summary>
        [Bindable(true)]
        public Canvas2DInteractions? CanvasInteractions
        {
            get => (Canvas2DInteractions?)GetValue(CanvasInteractionsProperty);
            set =>  SetValue(CanvasInteractionsProperty, value);
        }

        /// <summary>
        /// Canvas interactions dependency property
        /// </summary>
        public static readonly DependencyProperty CanvasInteractionsProperty =
            DependencyProperty.Register(
                name: nameof(CanvasInteractions),
                propertyType: typeof(Canvas2DInteractions),
                ownerType: typeof(Canvas2D),
                typeMetadata: new PropertyMetadata(
                    defaultValue: null,
                    propertyChangedCallback: OnCanvasInteractionPropertyChanged));

        /// <summary>
        /// Called when <see cref="CanvasInteractionsProperty"/> has changed
        /// </summary>
        /// <param name="obj">Sender</param>
        /// <param name="args">Event args</param>
        private static void OnCanvasInteractionPropertyChanged(
            DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue is Canvas2DInteractions ci)
                ci.Dispose();
        }
        
        #endregion

        #region Mouse-Keyboard events handlers

        /// <inheritdoc/>
        protected override void OnMouseDown(MouseButtonEventArgs args)
            => CanvasInteractions?.OnMouseDown(this, args);

        /// <inheritdoc/>
        protected override void OnMouseUp(MouseButtonEventArgs args)
            => CanvasInteractions?.OnMouseUp(this, args);

        /// <inheritdoc/>
        protected override void OnMouseDoubleClick(MouseButtonEventArgs args)
            => CanvasInteractions?.OnMouseDoubleClick(this, args);

        /// <inheritdoc/>
        protected override void OnMouseWheel(MouseWheelEventArgs args)
            => CanvasInteractions?.OnMouseWheel(this, args);

        /// <inheritdoc/>
        protected override void OnMouseMove(MouseEventArgs args)
            => CanvasInteractions?.OnMouseMove(this, args);

        /// <inheritdoc/>
        protected override void OnMouseEnter(MouseEventArgs args)
            => CanvasInteractions?.OnMouseEnter(this, args);

        /// <inheritdoc/>
        protected override void OnMouseLeave(MouseEventArgs args)
            => CanvasInteractions?.OnMouseLeave(this, args);

        /// <inheritdoc/>
        protected override void OnKeyDown(KeyEventArgs args)
            => CanvasInteractions?.OnKeyDown(this, args);

        /// <inheritdoc/>
        protected override void OnKeyUp(KeyEventArgs args)
            => CanvasInteractions?.OnKeyUp(this, args);

        /// <inheritdoc/>
        protected override void OnPreviewDragEnter(DragEventArgs args)
            => CanvasInteractions?.OnPreviewDragEnter(this, args);

        /// <inheritdoc/>
        protected override void OnPreviewDragLeave(DragEventArgs args)
            => CanvasInteractions?.OnPreviewDragLeave(this, args);

        /// <inheritdoc/>
        protected override void OnPreviewDragOver(DragEventArgs args)
            => CanvasInteractions?.OnPreviewDragOver(this, args);

        /// <inheritdoc/>
        protected override void OnPreviewDrop(DragEventArgs args)
            => CanvasInteractions?.OnPreviewDrop(this, args);

        /// <inheritdoc/>
        protected override void OnDragEnter(DragEventArgs args)
            => CanvasInteractions?.OnDragEnter(this, args);

        /// <inheritdoc/>
        protected override void OnDragLeave(DragEventArgs args)
            => CanvasInteractions?.OnDragLeave(this, args);

        /// <inheritdoc/>
        protected override void OnDragOver(DragEventArgs args)
            => CanvasInteractions?.OnDragOver(this, args);

        /// <inheritdoc/>
        protected override void OnDrop(DragEventArgs args)
            => CanvasInteractions?.OnDrop(this, args);

        #endregion
    }
}
