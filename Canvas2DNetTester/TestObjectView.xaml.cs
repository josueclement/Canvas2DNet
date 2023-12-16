using Canvas2DNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Canvas2DNetTester;

/// <summary>
/// Interaction logic for TestObjectView.xaml
/// </summary>
public partial class TestObjectView : UserControl
{
    public TestObjectView()
    {
        InitializeComponent();
    }
}

public class TestObject : DrawingObject
{
    public object? Content
    {
        get => _content;
        set => SetProperty(ref _content, value);
    }
    private object? _content;
}