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

        private static void OnDrawingObjectsGroupsPropertyChanged(
            DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            if (obj is Canvas2D canvas)
            {
                if (args.OldValue is ObservableCollection<DrawingObjectsGroup> oldValue)
                {
                    oldValue.CollectionChanged -= canvas.OnDrawingObjectsGroupsChanged;
                    canvas.RemoveDrawingObjects(oldValue);
                }

                if (args.NewValue is ObservableCollection<DrawingObjectsGroup> newValue)
                {
                    newValue.CollectionChanged += canvas.OnDrawingObjectsGroupsChanged;
                    canvas.AddDrawingObjects(newValue);
                }
            }
        }

        private void OnDrawingObjectsGroupsChanged(
            object? sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                RemoveDrawingObjects(e.OldItems);
            if (e.NewItems != null)
                AddDrawingObjects(e.NewItems);
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
                typeMetadata: new PropertyMetadata(defaultValue: null));
        
        #endregion

        #region Dependency properties

        private void AddDrawingObjects(IEnumerable? groups)
        {
            foreach (DrawingObjectsGroup group in groups ?? Enumerable.Empty<DrawingObjectsGroup>())
            {
                foreach (DrawingObject drawingObject in group.GetDrawingObjectsToAdd() ?? Enumerable.Empty<DrawingObject>())
                    DrawingObjects?.Add(drawingObject);
            }
        }
        
        private void RemoveDrawingObjects(IEnumerable? groups)
        {
            foreach (DrawingObjectsGroup group in groups ?? Enumerable.Empty<DrawingObjectsGroup>())
            {
                group.UnregisterDrawingObjectsEvents();
        
                foreach (DrawingObject drawingObject in group.GetDrawingObjectsToRemove() ?? Enumerable.Empty<DrawingObject>())
                    DrawingObjects?.Remove(drawingObject);
            }
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
