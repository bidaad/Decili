﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Decili.Code.DAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SDB")]
	public partial class BannersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBannerPositions(BannerPositions instance);
    partial void UpdateBannerPositions(BannerPositions instance);
    partial void DeleteBannerPositions(BannerPositions instance);
    partial void InsertBanners(Banners instance);
    partial void UpdateBanners(Banners instance);
    partial void DeleteBanners(Banners instance);
    #endregion
		
		public BannersDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DeciliConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BannersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BannersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BannersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BannersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BannerPositions> BannerPositions
		{
			get
			{
				return this.GetTable<BannerPositions>();
			}
		}
		
		public System.Data.Linq.Table<Banners> Banners
		{
			get
			{
				return this.GetTable<Banners>();
			}
		}
		
		public System.Data.Linq.Table<vBannerPositions> vBannerPositions
		{
			get
			{
				return this.GetTable<vBannerPositions>();
			}
		}
		
		public System.Data.Linq.Table<vBanners> vBanners
		{
			get
			{
				return this.GetTable<vBanners>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BannerPositions")]
	public partial class BannerPositions : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Code;
		
		private string _Name;
		
		private System.Nullable<int> _Width;
		
		private System.Nullable<int> _Height;
		
		private EntitySet<Banners> _Banners;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCodeChanging(int value);
    partial void OnCodeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnWidthChanging(System.Nullable<int> value);
    partial void OnWidthChanged();
    partial void OnHeightChanging(System.Nullable<int> value);
    partial void OnHeightChanged();
    #endregion
		
		public BannerPositions()
		{
			this._Banners = new EntitySet<Banners>(new Action<Banners>(this.attach_Banners), new Action<Banners>(this.detach_Banners));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(500)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Width", DbType="Int")]
		public System.Nullable<int> Width
		{
			get
			{
				return this._Width;
			}
			set
			{
				if ((this._Width != value))
				{
					this.OnWidthChanging(value);
					this.SendPropertyChanging();
					this._Width = value;
					this.SendPropertyChanged("Width");
					this.OnWidthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Height", DbType="Int")]
		public System.Nullable<int> Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				if ((this._Height != value))
				{
					this.OnHeightChanging(value);
					this.SendPropertyChanging();
					this._Height = value;
					this.SendPropertyChanged("Height");
					this.OnHeightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BannerPositions_Banners", Storage="_Banners", ThisKey="Code", OtherKey="PositionCode")]
		public EntitySet<Banners> Banners
		{
			get
			{
				return this._Banners;
			}
			set
			{
				this._Banners.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Banners(Banners entity)
		{
			this.SendPropertyChanging();
			entity.BannerPositions = this;
		}
		
		private void detach_Banners(Banners entity)
		{
			this.SendPropertyChanging();
			entity.BannerPositions = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Banners")]
	public partial class Banners : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Code;
		
		private string _BanFile;
		
		private string _TargetUrl;
		
		private System.Nullable<int> _HCTypeCode;
		
		private string _Text;
		
		private System.Nullable<int> _PositionCode;
		
		private string _Keywords;
		
		private System.Nullable<int> _ViewNum;
		
		private System.Nullable<int> _ClickNum;
		
		private EntityRef<BannerPositions> _BannerPositions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCodeChanging(int value);
    partial void OnCodeChanged();
    partial void OnBanFileChanging(string value);
    partial void OnBanFileChanged();
    partial void OnTargetUrlChanging(string value);
    partial void OnTargetUrlChanged();
    partial void OnHCTypeCodeChanging(System.Nullable<int> value);
    partial void OnHCTypeCodeChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    partial void OnPositionCodeChanging(System.Nullable<int> value);
    partial void OnPositionCodeChanged();
    partial void OnKeywordsChanging(string value);
    partial void OnKeywordsChanged();
    partial void OnViewNumChanging(System.Nullable<int> value);
    partial void OnViewNumChanged();
    partial void OnClickNumChanging(System.Nullable<int> value);
    partial void OnClickNumChanged();
    #endregion
		
		public Banners()
		{
			this._BannerPositions = default(EntityRef<BannerPositions>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BanFile", DbType="NVarChar(200)")]
		public string BanFile
		{
			get
			{
				return this._BanFile;
			}
			set
			{
				if ((this._BanFile != value))
				{
					this.OnBanFileChanging(value);
					this.SendPropertyChanging();
					this._BanFile = value;
					this.SendPropertyChanged("BanFile");
					this.OnBanFileChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TargetUrl", DbType="NVarChar(200)")]
		public string TargetUrl
		{
			get
			{
				return this._TargetUrl;
			}
			set
			{
				if ((this._TargetUrl != value))
				{
					this.OnTargetUrlChanging(value);
					this.SendPropertyChanging();
					this._TargetUrl = value;
					this.SendPropertyChanged("TargetUrl");
					this.OnTargetUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HCTypeCode", DbType="Int")]
		public System.Nullable<int> HCTypeCode
		{
			get
			{
				return this._HCTypeCode;
			}
			set
			{
				if ((this._HCTypeCode != value))
				{
					this.OnHCTypeCodeChanging(value);
					this.SendPropertyChanging();
					this._HCTypeCode = value;
					this.SendPropertyChanged("HCTypeCode");
					this.OnHCTypeCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Text", DbType="NVarChar(1000)")]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PositionCode", DbType="Int")]
		public System.Nullable<int> PositionCode
		{
			get
			{
				return this._PositionCode;
			}
			set
			{
				if ((this._PositionCode != value))
				{
					if (this._BannerPositions.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPositionCodeChanging(value);
					this.SendPropertyChanging();
					this._PositionCode = value;
					this.SendPropertyChanged("PositionCode");
					this.OnPositionCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Keywords", DbType="NVarChar(1000)")]
		public string Keywords
		{
			get
			{
				return this._Keywords;
			}
			set
			{
				if ((this._Keywords != value))
				{
					this.OnKeywordsChanging(value);
					this.SendPropertyChanging();
					this._Keywords = value;
					this.SendPropertyChanged("Keywords");
					this.OnKeywordsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ViewNum", DbType="Int")]
		public System.Nullable<int> ViewNum
		{
			get
			{
				return this._ViewNum;
			}
			set
			{
				if ((this._ViewNum != value))
				{
					this.OnViewNumChanging(value);
					this.SendPropertyChanging();
					this._ViewNum = value;
					this.SendPropertyChanged("ViewNum");
					this.OnViewNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClickNum", DbType="Int")]
		public System.Nullable<int> ClickNum
		{
			get
			{
				return this._ClickNum;
			}
			set
			{
				if ((this._ClickNum != value))
				{
					this.OnClickNumChanging(value);
					this.SendPropertyChanging();
					this._ClickNum = value;
					this.SendPropertyChanged("ClickNum");
					this.OnClickNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BannerPositions_Banners", Storage="_BannerPositions", ThisKey="PositionCode", OtherKey="Code", IsForeignKey=true)]
		public BannerPositions BannerPositions
		{
			get
			{
				return this._BannerPositions.Entity;
			}
			set
			{
				BannerPositions previousValue = this._BannerPositions.Entity;
				if (((previousValue != value) 
							|| (this._BannerPositions.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._BannerPositions.Entity = null;
						previousValue.Banners.Remove(this);
					}
					this._BannerPositions.Entity = value;
					if ((value != null))
					{
						value.Banners.Add(this);
						this._PositionCode = value.Code;
					}
					else
					{
						this._PositionCode = default(Nullable<int>);
					}
					this.SendPropertyChanged("BannerPositions");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vBannerPositions")]
	public partial class vBannerPositions
	{
		
		private int _Code;
		
		private string _Name;
		
		private System.Nullable<int> _Width;
		
		private System.Nullable<int> _Height;
		
		public vBannerPositions()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this._Code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(500)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Width", DbType="Int")]
		public System.Nullable<int> Width
		{
			get
			{
				return this._Width;
			}
			set
			{
				if ((this._Width != value))
				{
					this._Width = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Height", DbType="Int")]
		public System.Nullable<int> Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				if ((this._Height != value))
				{
					this._Height = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vBanners")]
	public partial class vBanners
	{
		
		private int _Code;
		
		private string _BanFile;
		
		private string _TargetUrl;
		
		private string _BannerType;
		
		private string _BannerPosition;
		
		private System.Nullable<int> _ViewNum;
		
		private System.Nullable<int> _ClickNum;
		
		private System.Nullable<int> _PositionCode;
		
		private string _Keywords;
		
		private System.Nullable<int> _HCTypeCode;
		
		private string _Text;
		
		private System.Nullable<int> _Width;
		
		private System.Nullable<int> _Height;
		
		public vBanners()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", DbType="Int NOT NULL")]
		public int Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this._Code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BanFile", DbType="NVarChar(200)")]
		public string BanFile
		{
			get
			{
				return this._BanFile;
			}
			set
			{
				if ((this._BanFile != value))
				{
					this._BanFile = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TargetUrl", DbType="NVarChar(200)")]
		public string TargetUrl
		{
			get
			{
				return this._TargetUrl;
			}
			set
			{
				if ((this._TargetUrl != value))
				{
					this._TargetUrl = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BannerType", DbType="NVarChar(500)")]
		public string BannerType
		{
			get
			{
				return this._BannerType;
			}
			set
			{
				if ((this._BannerType != value))
				{
					this._BannerType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BannerPosition", DbType="NVarChar(500)")]
		public string BannerPosition
		{
			get
			{
				return this._BannerPosition;
			}
			set
			{
				if ((this._BannerPosition != value))
				{
					this._BannerPosition = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ViewNum", DbType="Int")]
		public System.Nullable<int> ViewNum
		{
			get
			{
				return this._ViewNum;
			}
			set
			{
				if ((this._ViewNum != value))
				{
					this._ViewNum = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClickNum", DbType="Int")]
		public System.Nullable<int> ClickNum
		{
			get
			{
				return this._ClickNum;
			}
			set
			{
				if ((this._ClickNum != value))
				{
					this._ClickNum = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PositionCode", DbType="Int")]
		public System.Nullable<int> PositionCode
		{
			get
			{
				return this._PositionCode;
			}
			set
			{
				if ((this._PositionCode != value))
				{
					this._PositionCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Keywords", DbType="NVarChar(1000)")]
		public string Keywords
		{
			get
			{
				return this._Keywords;
			}
			set
			{
				if ((this._Keywords != value))
				{
					this._Keywords = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HCTypeCode", DbType="Int")]
		public System.Nullable<int> HCTypeCode
		{
			get
			{
				return this._HCTypeCode;
			}
			set
			{
				if ((this._HCTypeCode != value))
				{
					this._HCTypeCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Text", DbType="NVarChar(1000)")]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this._Text = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Width", DbType="Int")]
		public System.Nullable<int> Width
		{
			get
			{
				return this._Width;
			}
			set
			{
				if ((this._Width != value))
				{
					this._Width = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Height", DbType="Int")]
		public System.Nullable<int> Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				if ((this._Height != value))
				{
					this._Height = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
