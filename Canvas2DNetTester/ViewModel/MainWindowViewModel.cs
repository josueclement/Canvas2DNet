﻿using Canvas2DNet;
using Canvas2DNet.Behaviors;
using Canvas2DNet.DrawingObjects;
using Canvas2DNetTester.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace Canvas2DNetTester.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            Behavior = new Canvas2DInteractiveBehavior();
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
            MyItems.Add(new Canvas2DEllipse
            {
                X = 130,
                Y = 20,
                Width = 40,
                Height = 20,
                Stroke = new SolidColorBrush(Colors.Black)
            });
            MyItems.Add(new Canvas2DPath
            {
                X = 190,
                Y = 20,
                Width = 50,
                Height = 50,
                StrokeThickness = new Thickness(1),
                Stroke = new SolidColorBrush(Colors.Black),
                Fill = new SolidColorBrush(Colors.Red),
                Data = GetGeometry()
            });
            MyItems.Add(new TestObject
            {
                X = 300,
                Y = 300,
                Width = 100,
                Height = 25,
                Content = "Blah"
            });

            TestDrawingObjectsGroup testGroup = new TestDrawingObjectsGroup(MyItems);
        }

        private Geometry GetGeometry()
        {
            StreamGeometry stream = new StreamGeometry();
            stream.FillRule = FillRule.EvenOdd;

            using (StreamGeometryContext ctx = stream.Open())
            {
                ctx.BeginFigure(new Point(0, 0), true, false);
                ctx.LineTo(new Point(40, 0), true, false);
                ctx.LineTo(new Point(20, 40), true, false);
                ctx.ArcTo(new Point(0, 0), new Size(30, 30), 0, false, SweepDirection.Clockwise, true, false);

                stream.Freeze();
                return stream;
            }
        }

        public ObservableCollection<DrawingObject> MyItems { get; set; } = new ObservableCollection<DrawingObject>();
        public DrawingObjectsDataTemplateSelector DrawingObjectsDataTemplateSelector { get; set; } = new DrawingObjectsDataTemplateSelector();

        public Canvas2DBehavior? Behavior
        {
            get => _behavior;
            set => SetProperty(ref _behavior, value);
        }
        private Canvas2DBehavior? _behavior;
    }
}
