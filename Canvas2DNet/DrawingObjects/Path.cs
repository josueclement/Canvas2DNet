using System.Windows.Media;

namespace Canvas2DNet.DrawingObjects;

/// <summary>
/// Path drawing object
/// </summary>
public class Path : Shape
{
    #region Properties

    /// <summary>
    /// Path geometry data
    /// </summary>
    public Geometry? Data
    {
        get => _data;
        set => SetProperty(ref _data, value);
    }
    private Geometry? _data;

    #endregion
}