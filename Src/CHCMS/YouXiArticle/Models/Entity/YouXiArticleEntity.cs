
using System;
using System.ComponentModel;

namespace YouXiArticle.Models
{
    /// <summary>
    /// A base class for Linq entities that implements notification events.
    /// </summary>
    [Serializable]
    public abstract class YouXiArticleEntity :
        INotifyPropertyChanging,
        INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YouXiArticleEntity"/> class.
        /// </summary>
        protected YouXiArticleEntity()
        { }

        #region Notification Events

        /// <summary>
        /// Implements a PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise the PropertyChanged event for a specific property.
        /// </summary>
        /// <param name="propertyName">Name of the property that has changed.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Implements a PropertyChanging event.
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Raise the PropertyChanging event for a specific property.
        /// </summary>
        /// <param name="propertyName">Name of the property that is changing.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            
        }
        #endregion
    }
}