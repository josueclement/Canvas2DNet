using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Canvas2DNet.Utils;

namespace Canvas2DNet
{
    public class DrawingObjectsDataTemplateSelector : DataTemplateSelector
    {
        private static Dictionary<Type, DataTemplate> _vmDataTemplateMapping = new Dictionary<Type, DataTemplate>();

        public static void AddDataTemplate(Type viewModelType, Type viewType)
        {
            DataTemplate dataTemplate = DataTemplateHelper.CreateDataTemplate(viewModelType, viewType);
            _vmDataTemplateMapping.Add(viewModelType, dataTemplate);
        }

        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        {
            Type itemType = item.GetType();

            if (_vmDataTemplateMapping.ContainsKey(itemType))
                return _vmDataTemplateMapping[itemType];
            return null;
        }
    }
}
