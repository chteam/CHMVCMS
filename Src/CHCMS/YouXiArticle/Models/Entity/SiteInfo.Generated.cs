
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
    /// The class representing the dbo.SiteInfo table.
    /// </summary>
    [Table(Name="dbo.SiteInfo")]
    public partial class SiteInfo
        : YouXiArticleEntity
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteInfo"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public SiteInfo()
        {
            OnCreated();
            _siteCategoryList = new EntitySet<Category>(
                new System.Action<Category>(this.Attach_SiteCategoryList),
                new System.Action<Category>(this.Detach_SiteCategoryList));
            _siteNavigationList = new EntitySet<Navigation>(
                new System.Action<Navigation>(this.Attach_SiteNavigationList),
                new System.Action<Navigation>(this.Detach_SiteNavigationList));
            _siteTagList = new EntitySet<Tag>(
                new System.Action<Tag>(this.Attach_SiteTagList),
                new System.Action<Tag>(this.Detach_SiteTagList));
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
        
        private string _domain;

        /// <summary>
        /// Gets or sets the Domain column value.
        /// </summary>
        [Column(Name="Domain", Storage="_domain", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        public string Domain
        {
            get { return _domain; }
            set
            {
                if (_domain != value)
                {
                    OnDomainChanging(value);
                    OnPropertyChanging("Domain");
                    _domain = value;
                    OnPropertyChanged("Domain");
                    OnDomainChanged();
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
        
        private string _stylePath;

        /// <summary>
        /// Gets or sets the StylePath column value.
        /// </summary>
        [Column(Name="StylePath", Storage="_stylePath", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        public string StylePath
        {
            get { return _stylePath; }
            set
            {
                if (_stylePath != value)
                {
                    OnStylePathChanging(value);
                    OnPropertyChanging("StylePath");
                    _stylePath = value;
                    OnPropertyChanged("StylePath");
                    OnStylePathChanged();
                }
            }
        }
        #endregion
        
        #region Association Mapped Properties
        
        private EntitySet<Category> _siteCategoryList;
        
        /// <summary>
        /// Gets or sets the Category association.
        /// </summary>
        [Association(Name="FK_Category_SiteInfo", Storage="_siteCategoryList", ThisKey="ID", OtherKey="SiteID")]
        public EntitySet<Category> SiteCategoryList
        {
            get { return _siteCategoryList; }
            set { _siteCategoryList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_SiteCategoryList(Category entity)
        {
            OnPropertyChanging(null);
            entity.SiteSiteInfo = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_SiteCategoryList(Category entity)
        {
            OnPropertyChanging(null);
            entity.SiteSiteInfo = null;
            OnPropertyChanged(null);
        }
        
        private EntitySet<Navigation> _siteNavigationList;
        
        /// <summary>
        /// Gets or sets the Navigation association.
        /// </summary>
        [Association(Name="FK_Navigation_SiteInfo", Storage="_siteNavigationList", ThisKey="ID", OtherKey="SiteID")]
        public EntitySet<Navigation> SiteNavigationList
        {
            get { return _siteNavigationList; }
            set { _siteNavigationList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_SiteNavigationList(Navigation entity)
        {
            OnPropertyChanging(null);
            entity.SiteSiteInfo = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_SiteNavigationList(Navigation entity)
        {
            OnPropertyChanging(null);
            entity.SiteSiteInfo = null;
            OnPropertyChanged(null);
        }
        
        private EntitySet<Tag> _siteTagList;
        
        /// <summary>
        /// Gets or sets the Tag association.
        /// </summary>
        [Association(Name="FK_Tag_SiteInfo", Storage="_siteTagList", ThisKey="ID", OtherKey="SiteID")]
        public EntitySet<Tag> SiteTagList
        {
            get { return _siteTagList; }
            set { _siteTagList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_SiteTagList(Tag entity)
        {
            OnPropertyChanging(null);
            entity.SiteSiteInfo = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_SiteTagList(Tag entity)
        {
            OnPropertyChanging(null);
            entity.SiteSiteInfo = null;
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
        /// <summary>Called when Domain is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnDomainChanging(string value);
        /// <summary>Called after Domain has Changed.</summary>
        partial void OnDomainChanged();
        /// <summary>Called when Title is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTitleChanging(string value);
        /// <summary>Called after Title has Changed.</summary>
        partial void OnTitleChanged();
        /// <summary>Called when StylePath is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnStylePathChanging(string value);
        /// <summary>Called after StylePath has Changed.</summary>
        partial void OnStylePathChanged();
        #endregion
        
    }
}

