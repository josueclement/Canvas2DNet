using Canvas2DNet;
using Canvas2DNet.DrawingObjects;
using System.Windows.Media;

namespace Canvas2DNetTester.Model;

public class TestDrawingObjectsGroup2 : DrawingObjectsGroup
{
    public TestDrawingObjectsGroup2()
    {
        Rectangle rect = new Rectangle
        {
            X = 0,
            Y = 0,
            Width = 10,
            Height = 10,
            Fill = new SolidColorBrush(Colors.Brown)
        };

        DrawingObjects.Add(rect);
    }
}