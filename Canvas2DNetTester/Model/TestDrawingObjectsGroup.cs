using Canvas2DNet;
using Canvas2DNet.DrawingObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Canvas2DNetTester.Model
{
    public class TestDrawingObjectsGroup : DrawingObjectsGroup
    {
        public TestDrawingObjectsGroup()
        {
            Rectangle r1 = new Rectangle
            {
                X = 400,
                Y = 20,
                Width = 20,
                Height = 20,
                Stroke = new SolidColorBrush(Colors.Yellow),
                Fill = new SolidColorBrush(Colors.Black),
                StrokeThickness = 1d
            };
            Rectangle r2 = new Rectangle
            {
                X = 440,
                Y = 20,
                Width = 20,
                Height = 20,
                Stroke = new SolidColorBrush(Colors.Yellow),
                Fill = new SolidColorBrush(Colors.Black),
                StrokeThickness = 1d
            };

            r1.Clicked += (s, e) =>
            {
                Debug.WriteLine($"CLICKED: {e}");
                Clicked?.Invoke(this, EventArgs.Empty);
            };

            r1.Moving += (s, e) =>
            {
                r1.X += e.Offset.X;
                r1.Y += e.Offset.Y;
                r2.X += e.Offset.X;
                r2.Y += e.Offset.Y;
            };

            r1.Moved += (s, e) =>
            {
                Debug.WriteLine($"MOVED: {e}");
            };

            r1.MouseEnter += (s, e) =>
            {
                r1.Stroke = new SolidColorBrush(Colors.Red);
                Debug.WriteLine($"MOUSEENTER");
            };

            r1.MouseLeave += (s, e) =>
            {
                r1.Stroke = new SolidColorBrush(Colors.Yellow);
                Debug.WriteLine($"MOUSELEAVE");
            };

            r1.MouseMovingOver += (s, e) =>
            {
                Debug.WriteLine($"MOUSEMOVINGOVER: {e}");
            };

            DrawingObjects.Add(r1);
            DrawingObjects.Add(r2);
        }

        public event EventHandler? Clicked;
        
    }
}
