using Canvas2DNet;
using Canvas2DNet.DrawingObjects;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace Canvas2DNetTester.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            //DrawingObjectsDataTemplateSelector = new DrawingObjectsDataTemplateSelector();
            DrawingObjectsDataTemplateSelector.AddDataTemplate(typeof(TestObject), typeof(TestObjectView));

            MyItems.Add(new Canvas2DRectangle
            {
                X = 100,
                Y = 100,
                Width = 200,
                Height = 100,
                Fill = new SolidColorBrush(Colors.DeepSkyBlue)
            });
            MyItems.Add(new Canvas2DLine
            {
                Ax = 20,
                Ay = 20,
                Bx = 100,
                By = 30,
                Stroke = new SolidColorBrush(Colors.Black)
            });
            MyItems.Add(new TestObject
            {
                X = 300,
                Y = 300,
                Width = 100,
                Height = 25,
                Content = "Blah"
            });
        }

        public ObservableCollection<DrawingObject> MyItems { get; set; } = new ObservableCollection<DrawingObject>();
        public DrawingObjectsDataTemplateSelector DrawingObjectsDataTemplateSelector { get; set; } = new DrawingObjectsDataTemplateSelector();
    }
}
