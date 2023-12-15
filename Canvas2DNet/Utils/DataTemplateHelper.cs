using System;
using System.Windows.Markup;
using System.Windows;

namespace Canvas2DNet.Utils
{
    /// <summary>
    /// Helper class for DataTemplates
    /// </summary>
    public static class DataTemplateHelper
    {
        /// <summary>
        /// Create a DataTemplate based on the ViewModel type and the View type
        /// </summary>
        /// <param name="viewModelType">ViewModel type</param>
        /// <param name="viewType">View type</param>
        /// <returns>DataTemplate</returns>
        public static DataTemplate CreateDataTemplate(Type viewModelType, Type viewType)
        {
            const string xamlTemplate = "<DataTemplate DataType=\"{{x:Type vm:{0}}}\"><v:{1} /></DataTemplate>";
            var xaml = string.Format(xamlTemplate, viewModelType.Name, viewType.Name);

            var context = new ParserContext
            {
                XamlTypeMapper = new XamlTypeMapper(Array.Empty<string>())
            };

            if (viewModelType.Namespace != null)
                context.XamlTypeMapper.AddMappingProcessingInstruction("vm", viewModelType.Namespace, viewModelType.Assembly.FullName);
            if (viewType.Namespace != null)
                context.XamlTypeMapper.AddMappingProcessingInstruction("v", viewType.Namespace, viewType.Assembly.FullName);

            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("vm", "vm");
            context.XmlnsDictionary.Add("v", "v");

            var template = (DataTemplate)XamlReader.Parse(xaml, context);
            return template;
        }
    }
}
