
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
    /// The class representing the dbo.Navigation table.
    /// </summary>
    [Table(Name="dbo.Navigation")]
    public partial class Navigation
        : YouXiArticleEntity
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Navigation"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Navigation()
        {
            OnCreated();
            _siteSiteInfo = default(EntityRef<SiteInfo>);
            _urlActionList = new EntitySet<UrlAction>(
                new System.Action<UrlAction>(this.Attach_UrlActionList),
                new System.Action<UrlAction>(this.Detach_UrlActionList));
            _articleList = new EntitySet<Article>(
                new System.Action<Article>(this.Attach_ArticleList),
                new System.Action<Article>(this.Detach_ArticleList));
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
        
        private long _siteID;

        /// <summary>
        /// Gets or sets the SiteID column value.
        /// </summary>
        [Column(Name="SiteID", Storage="_siteID", DbType="bigint NOT NULL", CanBeNull=false)]
        public long SiteID
        {
            get { return _siteID; }
            set
            {
                if (_siteID != value)
                {
                    if (_siteSiteInfo.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnSiteIDChanging(value);
                    OnPropertyChanging("SiteID");
                    _siteID = value;
                    OnPropertyChanged("SiteID");
                    OnSiteIDChanged();
                }
            }
        }
        
        private bool _hasArticle;

        /// <summary>
        /// Gets or sets the HasArticle column value.
        /// </summary>
        [Column(Name="HasArticle", Storage="_hasArticle", DbType="bit NOT NULL", CanBeNull=false)]
        public bool HasArticle
        {
            get { return _hasArticle; }
            set
            {
                if (_hasArticle != value)
                {
                    OnHasArticleChanging(value);
                    OnPropertyChanging("HasArticle");
                    _hasArticle = value;
                    OnPropertyChanged("HasArticle");
                    OnHasArticleChanged();
                }
            }
        }
        
        private string _url;

        /// <summary>
        /// Gets or sets the Url column value.
        /// </summary>
        [Column(Name="Url", Storage="_url", DbType="nvarchar(250)")]
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
        
        private bool _hasUrl;

        /// <summary>
        /// Gets or sets the HasUrl column value.
        /// </summary>
        [Column(Name="HasUrl", Storage="_hasUrl", DbType="bit NOT NULL", CanBeNull=false)]
        public bool HasUrl
        {
            get { return _hasUrl; }
            set
            {
                if (_hasUrl != value)
                {
                    OnHasUrlChanging(value);
                    OnPropertyChanging("HasUrl");
                    _hasUrl = value;
                    OnPropertyChanged("HasUrl");
                    OnHasUrlChanged();
                }
            }
        }
        
        private byte _navType;

        /// <summary>
        /// Gets or sets the NavType column value.
        /// </summary>
        [Column(Name="NavType", Storage="_navType", DbType="tinyint NOT NULL", CanBeNull=false)]
        public byte NavType
        {
            get { return _navType; }
            set
            {
                if (_navType != value)
                {
                    OnNavTypeChanging(value);
                    OnPropertyChanging("NavType");
                    _navType = value;
                    OnPropertyChanged("NavType");
                    OnNavTypeChanged();
                }
            }
        }
        #endregion
        
        #region Association Mapped Properties
        
        private EntityRef<SiteInfo> _siteSiteInfo;

        /// <summary>
        /// Gets or sets the SiteInfo association.
        /// </summary>
        [Association(Name="FK_Navigation_SiteInfo", Storage="_siteSiteInfo", ThisKey="SiteID", OtherKey="ID", IsForeignKey=true)]
        public SiteInfo SiteSiteInfo
        {
            get { return _siteSiteInfo.Entity; }
            set
            {
                SiteInfo previousValue = _siteSiteInfo.Entity;
                if (previousValue != value || _siteSiteInfo.HasLoadedOrAssignedValue == false)
                {
                    OnPropertyChanging("SiteSiteInfo");
                    if (previousValue != null)
                    {
                        _siteSiteInfo.Entity = null;
                        previousValue.SiteNavigationList.Remove(this);
                    }
                    _siteSiteInfo.Entity = value;
                    if (value != null)
                    {
                        value.SiteNavigationList.Add(this);
                        _siteID = value.ID;
                    }
                    else
                    {
                        _siteID = default(long);
                    }
                    OnPropertyChanged("SiteSiteInfo");
                }
            }
        }
        
        private EntitySet<UrlAction> _urlActionList;
        
        /// <summary>
        /// Gets or sets the UrlAction association.
        /// </summary>
        [Association(Name="FK_UrlAction_Category", Storage="_urlActionList", ThisKey="ID", OtherKey="NavigationID")]
        public EntitySet<UrlAction> UrlActionList
        {
            get { return _urlActionList; }
            set { _urlActionList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_UrlActionList(UrlAction entity)
        {
            OnPropertyChanging(null);
            entity.Navigation = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_UrlActionList(UrlAction entity)
        {
            OnPropertyChanging(null);
            entity.Navigation = null;
            OnPropertyChanged(null);
        }
        
        private EntitySet<Article> _articleList;
        
        /// <summary>
        /// Gets or sets the Article association.
        /// </summary>
        [Association(Name="FK_Article_Navigation", Storage="_articleList", ThisKey="ID", OtherKey="NavigationID")]
        public EntitySet<Article> ArticleList
        {
            get { return _articleList; }
            set { _articleList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_ArticleList(Article entity)
        {
            OnPropertyChanging(null);
            entity.Navigation = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_ArticleList(Article entity)
        {
            OnPropertyChanging(null);
            entity.Navigation = null;
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
        /// <summary>Called when SiteID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnSiteIDChanging(long value);
        /// <summary>Called after SiteID has Changed.</summary>
        partial void OnSiteIDChanged();
        /// <summary>Called when HasArticle is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnHasArticleChanging(bool value);
        /// <summary>Called after HasArticle has Changed.</summary>
        partial void OnHasArticleChanged();
        /// <summary>Called when Url is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnUrlChanging(string value);
        /// <summary>Called after Url has Changed.</summary>
        partial void OnUrlChanged();
        /// <summary>Called when HasUrl is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnHasUrlChanging(bool value);
        /// <summary>Called after HasUrl has Changed.</summary>
        partial void OnHasUrlChanged();
        /// <summary>Called when NavType is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnNavTypeChanging(byte value);
        /// <summary>Called after NavType has Changed.</summary>
        partial void OnNavTypeChanged();
        #endregion
        
    }
}
