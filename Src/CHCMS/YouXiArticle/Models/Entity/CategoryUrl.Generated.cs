
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
    /// The class representing the dbo.CategoryUrl table.
    /// </summary>
    [Table(Name="dbo.CategoryUrl")]
    public partial class CategoryUrl
        : YouXiArticleEntity
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryUrl"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public CategoryUrl()
        {
            OnCreated();
            _category = default(EntityRef<Category>);
            _urlAction = default(EntityRef<UrlAction>);
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
        
        private long _urlActionID;

        /// <summary>
        /// Gets or sets the UrlActionID column value.
        /// </summary>
        [Column(Name="UrlActionID", Storage="_urlActionID", DbType="bigint NOT NULL", CanBeNull=false)]
        public long UrlActionID
        {
            get { return _urlActionID; }
            set
            {
                if (_urlActionID != value)
                {
                    if (_urlAction.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnUrlActionIDChanging(value);
                    OnPropertyChanging("UrlActionID");
                    _urlActionID = value;
                    OnPropertyChanged("UrlActionID");
                    OnUrlActionIDChanged();
                }
            }
        }
        
        private long _categoryID;

        /// <summary>
        /// Gets or sets the CategoryID column value.
        /// </summary>
        [Column(Name="CategoryID", Storage="_categoryID", DbType="bigint NOT NULL", CanBeNull=false)]
        public long CategoryID
        {
            get { return _categoryID; }
            set
            {
                if (_categoryID != value)
                {
                    if (_category.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnCategoryIDChanging(value);
                    OnPropertyChanging("CategoryID");
                    _categoryID = value;
                    OnPropertyChanged("CategoryID");
                    OnCategoryIDChanged();
                }
            }
        }
        #endregion
        
        #region Association Mapped Properties
        
        private EntityRef<Category> _category;

        /// <summary>
        /// Gets or sets the Category association.
        /// </summary>
        [Association(Name="FK_CategoryUrl_Category", Storage="_category", ThisKey="CategoryID", OtherKey="ID", IsForeignKey=true)]
        public Category Category
        {
            get { return _category.Entity; }
            set
            {
                Category previousValue = _category.Entity;
                if (previousValue != value || _category.HasLoadedOrAssignedValue == false)
                {
                    OnPropertyChanging("Category");
                    if (previousValue != null)
                    {
                        _category.Entity = null;
                        previousValue.CategoryUrlList.Remove(this);
                    }
                    _category.Entity = value;
                    if (value != null)
                    {
                        value.CategoryUrlList.Add(this);
                        _categoryID = value.ID;
                    }
                    else
                    {
                        _categoryID = default(long);
                    }
                    OnPropertyChanged("Category");
                }
            }
        }
        
        private EntityRef<UrlAction> _urlAction;

        /// <summary>
        /// Gets or sets the UrlAction association.
        /// </summary>
        [Association(Name="FK_CategoryUrl_UrlAction", Storage="_urlAction", ThisKey="UrlActionID", OtherKey="ID", IsForeignKey=true)]
        public UrlAction UrlAction
        {
            get { return _urlAction.Entity; }
            set
            {
                UrlAction previousValue = _urlAction.Entity;
                if (previousValue != value || _urlAction.HasLoadedOrAssignedValue == false)
                {
                    OnPropertyChanging("UrlAction");
                    if (previousValue != null)
                    {
                        _urlAction.Entity = null;
                        previousValue.CategoryUrlList.Remove(this);
                    }
                    _urlAction.Entity = value;
                    if (value != null)
                    {
                        value.CategoryUrlList.Add(this);
                        _urlActionID = value.ID;
                    }
                    else
                    {
                        _urlActionID = default(long);
                    }
                    OnPropertyChanged("UrlAction");
                }
            }
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
        /// <summary>Called when UrlActionID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnUrlActionIDChanging(long value);
        /// <summary>Called after UrlActionID has Changed.</summary>
        partial void OnUrlActionIDChanged();
        /// <summary>Called when CategoryID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCategoryIDChanging(long value);
        /// <summary>Called after CategoryID has Changed.</summary>
        partial void OnCategoryIDChanged();
        #endregion
        
    }
}

