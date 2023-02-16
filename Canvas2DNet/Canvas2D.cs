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
    }
}
