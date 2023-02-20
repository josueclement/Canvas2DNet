using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        public List<DrawingObject> DrawingObjects { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Show the drawing objects
        /// </summary>
        public void Show()
            => DrawingObjects?.ForEach(x => x.Visibility = System.Windows.Visibility.Visible);

        /// <summary>
        /// Hide the drawing objects
        /// </summary>
        public void Hide()
            => DrawingObjects?.ForEach(x => x.Visibility = System.Windows.Visibility.Collapsed);

        /// <summary>
        /// Override this method to unregister 
        /// </summary>
        protected virtual void UnregisterEvents()
        { }

        #endregion
    }
}
