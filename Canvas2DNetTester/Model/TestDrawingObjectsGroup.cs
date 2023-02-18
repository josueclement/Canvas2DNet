using Canvas2DNet;
using Canvas2DNet.DrawingObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Canvas2DNetTester.Model
{
    public class TestDrawingObjectsGroup : DrawingObjectsGroup
    {
        public TestDrawingObjectsGroup(ObservableCollection<DrawingObject> drawingObjects)
            : base(drawingObjects)
        {
            Canvas2DRectangle r1 = new Canvas2DRectangle
            {
                X = 400,
                Y = 20,
                Width = 10,
                Height = 10,
                Stroke = new SolidColorBrush(Colors.Yellow),
                Fill = new SolidColorBrush(Colors.Black)
            };
            Canvas2DRectangle r2 = new Canvas2DRectangle
            {
                X = 440,
                Y = 20,
                Width = 10,
                Height = 10,
                Stroke = new SolidColorBrush(Colors.Yellow),
                Fill = new SolidColorBrush(Colors.Black)
            };

            DrawingObjects?.Add(r1);
            DrawingObjects?.Add(r2);

            AddToCanvas();
        }
    }
}
