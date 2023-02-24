using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace Canvas2DNet
{
    /// <summary>
    /// Group object 
    /// </summary>
    public abstract class DrawingObjectsGroup : ObservableObject
    {
        #region Constructor

        /// <summary>
        /// Constructor for <see cref="DrawingObjectsGroup"/>
        /// </summary>
        public DrawingObjectsGroup()
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
        /// Get the drawing objects to add to the canvas
        /// </summary>
        public virtual IEnumerable<DrawingObject>? GetDrawingObjectsToAdd()
            => DrawingObjects;

        /// <summary>
        /// Get the drawing objects to remove from the canvas
        /// </summary>
        public virtual IEnumerable<DrawingObject>? GetDrawingObjectsToRemove()
            => DrawingObjects;

        /// <summary>
        /// Unregister drawing objects events
        /// </summary>
        public virtual void UnregisterDrawingObjectsEvents() { }

        /// <summary>
        /// Show the drawing objects
        /// </summary>
        public virtual void Show()
            => DrawingObjects?.ForEach(x => x.Visibility = System.Windows.Visibility.Visible);

        /// <summary>
        /// Hide the drawing objects
        /// </summary>
        public virtual void Hide()
            => DrawingObjects?.ForEach(x => x.Visibility = System.Windows.Visibility.Collapsed);

        #endregion
    }
}
