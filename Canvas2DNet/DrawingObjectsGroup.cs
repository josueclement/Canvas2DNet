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
        /// <summary>
        /// Canvas drawing objects
        /// </summary>
        protected ObservableCollection<DrawingObject> _canvasDrawingObjects;

        #region Constructor

        /// <summary>
        /// Constructor for <see cref="DrawingObjectsGroup"/>
        /// </summary>
        /// <param name="canvasDrawingObjects">Canvas drawing objects</param>
        public DrawingObjectsGroup(ObservableCollection<DrawingObject> canvasDrawingObjects)
        {
            _canvasDrawingObjects = canvasDrawingObjects;
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
        /// Add the drawing objects to canvas
        /// </summary>
        public void AddToCanvas()
            => DrawingObjects?.ForEach(x => _canvasDrawingObjects?.Add(x));

        /// <summary>
        /// Remove the drawing objects from canvas
        /// </summary>
        public void RemoveFromCanvas()
            => DrawingObjects?.ForEach(x => _canvasDrawingObjects?.Remove(x));

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
