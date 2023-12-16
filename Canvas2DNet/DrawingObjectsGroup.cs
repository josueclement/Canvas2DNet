using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace Canvas2DNet;

/// <summary>
/// Group object 
/// </summary>
public abstract class DrawingObjectsGroup : ObservableObject
{
    #region Constructor

    /// <summary>
    /// Constructor for <see cref="DrawingObjectsGroup"/>
    /// </summary>
    protected DrawingObjectsGroup()
    {
            DrawingObjects = new List<DrawingObject>();
        }

    #endregion

    #region Properties

    /// <summary>
    /// Drawing objects
    /// </summary>
    public List<DrawingObject> DrawingObjects { get; }

    #endregion

    #region Methods

    /// <summary>
    /// Unregister drawing objects events
    /// </summary>
    public virtual void UnregisterDrawingObjectsEvents() { }

    /// <summary>
    /// Show the drawing objects
    /// </summary>
    public virtual void Show()
        => DrawingObjects.ForEach(x => x.Visibility = System.Windows.Visibility.Visible);

    /// <summary>
    /// Hide the drawing objects
    /// </summary>
    public virtual void Hide()
        => DrawingObjects.ForEach(x => x.Visibility = System.Windows.Visibility.Collapsed);

    #endregion
}