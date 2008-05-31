
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;

namespace YouXiArticle.Models
{
    /// <summary>
    /// The class representing the dbo.UrlAction table.
    /// </summary>
    [Table(Name="dbo.UrlAction")]
    public partial class UrlAction
        : YouXiArticleEntity
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlAction"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public UrlAction()
        {
            OnCreated();
            _navigation = default(EntityRef<Navigation>);
            _categoryUrlList = new EntitySet<CategoryUrl>(
                new System.Action<CategoryUrl>(this.Attach_CategoryUrlList),
                new System.Action<CategoryUrl>(this.Detach_CategoryUrlList));
            _urlTagList = new EntitySet<UrlTag>(
                new System.Action<UrlTag>(this.Attach_UrlTagList),
                new System.Action<UrlTag>(this.Detach_UrlTagList));
        }
        #endregion
        
        #region Column Mapped Properties
        
        private long _iD = default(long);

        /// <summary>
        /// Gets the ID column value.
        /// </summary>
        [Column(Name="ID", Storage="_iD", DbType="bigint NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public long ID
        {
            get { return _iD; }
            set
            {
                if (_iD != value)
                {
                    OnIDChanging(value);
                    OnPropertyChanging("ID");
                    _iD = value;
                    OnPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        
        private string _title;

        /// <summary>
        /// Gets or sets the Title column value.
        /// </summary>
        [Column(Name="Title", Storage="_title", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    OnTitleChanging(value);
                    OnPropertyChanging("Title");
                    _title = value;
                    OnPropertyChanged("Title");
                    OnTitleChanged();
                }
            }
        }
        
        private string _url;

        /// <summary>
        /// Gets or sets the Url column value.
        /// </summary>
        [Column(Name="Url", Storage="_url", DbType="nvarchar(250) NOT NULL", CanBeNull=false)]
        public string Url
        {
            get { return _url; }
            set
            {
                if (_url != value)
                {
                    OnUrlChanging(value);
                    OnPropertyChanging("Url");
                    _url = value;
                    OnPropertyChanged("Url");
                    OnUrlChanged();
                }
            }
        }
        
        private System.DateTime _addTime;

        /// <summary>
        /// Gets or sets the AddTime column value.
        /// </summary>
        [Column(Name="AddTime", Storage="_addTime", DbType="smalldatetime NOT NULL", CanBeNull=false)]
        public System.DateTime AddTime
        {
            get { return _addTime; }
            set
            {
                if (_addTime != value)
                {
                    OnAddTimeChanging(value);
                    OnPropertyChanging("AddTime");
                    _addTime = value;
                    OnPropertyChanged("AddTime");
                    OnAddTimeChanged();
                }
            }
        }
        
        private long _navigationID;

        /// <summary>
        /// Gets or sets the NavigationID column value.
        /// </summary>
        [Column(Name="NavigationID", Storage="_navigationID", DbType="bigint NOT NULL", CanBeNull=false)]
        public long NavigationID
        {
            get { return _navigationID; }
            set
            {
                if (_navigationID != value)
                {
                    if (_navigation.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnNavigationIDChanging(value);
                    OnPropertyChanging("NavigationID");
                    _navigationID = value;
                    OnPropertyChanged("NavigationID");
                    OnNavigationIDChanged();
                }
            }
        }
        
        private string _author;

        /// <summary>
        /// Gets or sets the Author column value.
        /// </summary>
        [Column(Name="Author", Storage="_author", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        public string Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    OnAuthorChanging(value);
                    OnPropertyChanging("Author");
                    _author = value;
                    OnPropertyChanged("Author");
                    OnAuthorChanged();
                }
            }
        }
        #endregion
        
        #region Association Mapped Properties
        
        private EntityRef<Navigation> _navigation;

        /// <summary>
        /// Gets or sets the Navigation association.
        /// </summary>
        [Association(Name="FK_UrlAction_Category", Storage="_navigation", ThisKey="NavigationID", OtherKey="ID", IsForeignKey=true)]
        public Navigation Navigation
        {
            get { return _navigation.Entity; }
            set
            {
                Navigation previousValue = _navigation.Entity;
                if (previousValue != value || _navigation.HasLoadedOrAssignedValue == false)
                {
                    OnPropertyChanging("Navigation");
                    if (previousValue != null)
                    {
                        _navigation.Entity = null;
                        previousValue.UrlActionList.Remove(this);
                    }
                    _navigation.Entity = value;
                    if (value != null)
                    {
                        value.UrlActionList.Add(this);
                        _navigationID = value.ID;
                    }
                    else
                    {
                        _navigationID = default(long);
                    }
                    OnPropertyChanged("Navigation");
                }
            }
        }
        
        private EntitySet<CategoryUrl> _categoryUrlList;
        
        /// <summary>
        /// Gets or sets the CategoryUrl association.
        /// </summary>
        [Association(Name="FK_CategoryUrl_UrlAction", Storage="_categoryUrlList", ThisKey="ID", OtherKey="UrlActionID")]
        public EntitySet<CategoryUrl> CategoryUrlList
        {
            get { return _categoryUrlList; }
            set { _categoryUrlList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_CategoryUrlList(CategoryUrl entity)
        {
            OnPropertyChanging(null);
            entity.UrlAction = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_CategoryUrlList(CategoryUrl entity)
        {
            OnPropertyChanging(null);
            entity.UrlAction = null;
            OnPropertyChanged(null);
        }
        
        private EntitySet<UrlTag> _urlTagList;
        
        /// <summary>
        /// Gets or sets the UrlTag association.
        /// </summary>
        [Association(Name="FK_UrlTag_UrlAction", Storage="_urlTagList", ThisKey="ID", OtherKey="UrlActionID")]
        public EntitySet<UrlTag> UrlTagList
        {
            get { return _urlTagList; }
            set { _urlTagList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_UrlTagList(UrlTag entity)
        {
            OnPropertyChanging(null);
            entity.UrlAction = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_UrlTagList(UrlTag entity)
        {
            OnPropertyChanging(null);
            entity.UrlAction = null;
            OnPropertyChanged(null);
        }
        #endregion
        
        #region Extensibility Method Definitions
        /// <summary>Called when this instance is loaded.</summary>
        partial void OnLoaded();
        /// <summary>Called when this instance is being saved.</summary>
        partial void OnValidate(ChangeAction action);
        /// <summary>Called when this instance is created.</summary>
        partial void OnCreated();
        /// <summary>Called when ID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIDChanging(long value);
        /// <summary>Called after ID has Changed.</summary>
        partial void OnIDChanged();
        /// <summary>Called when Title is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTitleChanging(string value);
        /// <summary>Called after Title has Changed.</summary>
        partial void OnTitleChanged();
        /// <summary>Called when Url is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnUrlChanging(string value);
        /// <summary>Called after Url has Changed.</summary>
        partial void OnUrlChanged();
        /// <summary>Called when AddTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnAddTimeChanging(System.DateTime value);
        /// <summary>Called after AddTime has Changed.</summary>
        partial void OnAddTimeChanged();
        /// <summary>Called when NavigationID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnNavigationIDChanging(long value);
        /// <summary>Called after NavigationID has Changed.</summary>
        partial void OnNavigationIDChanged();
        /// <summary>Called when Author is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnAuthorChanging(string value);
        /// <summary>Called after Author has Changed.</summary>
        partial void OnAuthorChanged();
        #endregion
        
    }
}
