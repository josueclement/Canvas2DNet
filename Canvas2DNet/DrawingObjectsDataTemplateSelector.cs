using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Canvas2DNet.Utils;

namespace Canvas2DNet
{
    /// <summary>
    /// Drawing objects DataTemplateSelector
    /// </summary>
    public class DrawingObjectsDataTemplateSelector : DataTemplateSelector
    {
        private readonly Dictionary<Type, DataTemplate> _vmDataTemplateMapping = new Dictionary<Type, DataTemplate>();

        /// <summary>
        /// Add and store a DataTemplate from ViewModel type and View type
        /// </summary>
        /// <param name="viewModelType">ViewModel type</param>
        /// <param name="viewType">View type</param>
        public void RegisterDataTemplate(Type viewModelType, Type viewType)
        {
            DataTemplate dataTemplate = DataTemplateHelper.CreateDataTemplate(viewModelType, viewType);
            _vmDataTemplateMapping.Add(viewModelType, dataTemplate);
        }

        /// <inheritdoc/>
        public override DataTemplate? SelectTemplate(object? item, DependencyObject container)
        {
            if (item == null)
                return null;
            
            var itemType = item.GetType();

            if (_vmDataTemplateMapping.TryGetValue(itemType, out var template))
                return template;
            
            return base.SelectTemplate(item, container);
        }
    }
}
