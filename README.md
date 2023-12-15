# Canvas2DNet example

## Add control

```XML
<Window x:Class="Canvas2DNetTester.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:Canvas2DNetTester"
        xmlns:canvas="clr-namespace:Canvas2DNet;assembly=Canvas2DNet"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <canvas:Canvas2D Background="#1e1e1e"
                         Items="{Binding MyItems}"
                         Groups="{Binding MyGroups}"
                         DrawingObjectsDataTemplateSelector="{Binding DrawingObjectsDataTemplateSelector}"
                         CanvasInteractions="{Binding Interactions}"/>
    </Grid>
</Window>

```

## ViewModel

Binding properties :

```CSharp
public ObservableCollection<DrawingObject> MyItems { get; set; } = new ObservableCollection<DrawingObject>();
public ObservableCollection<DrawingObjectsGroup> MyGroups { get; set; } = new ObservableCollection<DrawingObjectsGroup>();
public DrawingObjectsDataTemplateSelector DrawingObjectsDataTemplateSelector { get; set; } = new DrawingObjectsDataTemplateSelector();

public Canvas2DInteractions? Interactions
{
    get => _interactions;
    set => SetProperty(ref _interactions, value);
}
private Canvas2DInteractions? _interactions;

```

Initialization :

```CSharp
Interactions = new StandardInteractions();
DrawingObjectsDataTemplateSelector.AddDataTemplate(typeof(TestObject), typeof(TestObjectView));
```

## Path geometry example

```CSharp
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

```