using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            get => (ObservableCollection<DrawingObject>)GetValue(ItemsProperty); 
            set => SetValue(ItemsProperty, value); 
        }

        /// <summary>
        /// Drawing objects groups dependency property
        /// </summary>
        public static readonly DependencyProperty GroupsProperty =
            DependencyProperty.Register(nameof(Groups), typeof(ObservableCollection<DrawingObjectsGroup>), typeof(Canvas2D), new PropertyMetadata(default, OnGroupsChanged));

        /// <summary>
        /// Drawing objects groups
        /// </summary>
        public ObservableCollection<DrawingObjectsGroup> Groups
        {
            get => (ObservableCollection<DrawingObjectsGroup>)GetValue(GroupsProperty);
            set => SetValue(GroupsProperty, value);
        }

        private static void OnGroupsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Canvas2D canvas)
            {
                if (e.OldValue is ObservableCollection<DrawingObjectsGroup> oldValue)
                {
                    oldValue.CollectionChanged -= canvas!.Groups_CollectionChanged;
                    canvas?.RemoveDrawingObjects(oldValue);
                }
                if (e.NewValue is ObservableCollection<DrawingObjectsGroup> newValue)
                {
                    newValue.CollectionChanged += canvas!.Groups_CollectionChanged;
                    canvas?.AddDrawingObjects(newValue);
                }
            }
        }

        private void Groups_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                RemoveDrawingObjects(e.OldItems);
            if (e.NewItems != null)
                AddDrawingObjects(e.NewItems);
        }

        private void AddDrawingObjects(IEnumerable? groups)
        {
            foreach (DrawingObjectsGroup group in groups ?? Enumerable.Empty<DrawingObjectsGroup>())
            {
                foreach (DrawingObject drawingObject in group.GetDrawingObjectsToAdd() ?? Enumerable.Empty<DrawingObject>())
                    Items.Add(drawingObject);
            }
        }

        private void RemoveDrawingObjects(IEnumerable? groups)
        {
            foreach (DrawingObjectsGroup group in groups ?? Enumerable.Empty<DrawingObjectsGroup>())
            {
                group.UnregisterDrawingObjectsEvents();

                foreach (DrawingObject drawingObject in group.GetDrawingObjectsToRemove() ?? Enumerable.Empty<DrawingObject>())
                    Items.Remove(drawingObject);
            }
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
            get => (DrawingObjectsDataTemplateSelector)GetValue(DrawingObjectsDataTemplateSelectorProperty); 
            set => SetValue(DrawingObjectsDataTemplateSelectorProperty, value); 
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
            get => (Canvas2DInteractions)GetValue(CanvasInteractionsProperty);
            set =>  SetValue(CanvasInteractionsProperty, value);
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
