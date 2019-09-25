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

namespace UserService
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CoffeeSquaredDB")]
	public partial class ProductdbmlDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertProduct(Product instance);
    partial void UpdateProduct(Product instance);
    partial void DeleteProduct(Product instance);
    #endregion
		
		public ProductdbmlDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["CoffeeSquaredDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ProductdbmlDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProductdbmlDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProductdbmlDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProductdbmlDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Product> Products
		{
			get
			{
				return this.GetTable<Product>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Product")]
	public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _name;
		
		private string _desc;
		
		private string _region;
		
		private string _roast;
		
		private int _altitude_max;
		
		private int _altitude_min;
		
		private System.DateTime _created_at;
		
		private System.DateTime _updated_at;
		
		private byte _isDeleted;
		
		private string _bean_type;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OndescChanging(string value);
    partial void OndescChanged();
    partial void OnregionChanging(string value);
    partial void OnregionChanged();
    partial void OnroastChanging(string value);
    partial void OnroastChanged();
    partial void Onaltitude_maxChanging(int value);
    partial void Onaltitude_maxChanged();
    partial void Onaltitude_minChanging(int value);
    partial void Onaltitude_minChanged();
    partial void Oncreated_atChanging(System.DateTime value);
    partial void Oncreated_atChanged();
    partial void Onupdated_atChanging(System.DateTime value);
    partial void Onupdated_atChanged();
    partial void OnisDeletedChanging(byte value);
    partial void OnisDeletedChanged();
    partial void Onbean_typeChanging(string value);
    partial void Onbean_typeChanged();
    #endregion
		
		public Product()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[desc]", Storage="_desc", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string desc
		{
			get
			{
				return this._desc;
			}
			set
			{
				if ((this._desc != value))
				{
					this.OndescChanging(value);
					this.SendPropertyChanging();
					this._desc = value;
					this.SendPropertyChanged("desc");
					this.OndescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_region", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string region
		{
			get
			{
				return this._region;
			}
			set
			{
				if ((this._region != value))
				{
					this.OnregionChanging(value);
					this.SendPropertyChanging();
					this._region = value;
					this.SendPropertyChanged("region");
					this.OnregionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_roast", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string roast
		{
			get
			{
				return this._roast;
			}
			set
			{
				if ((this._roast != value))
				{
					this.OnroastChanging(value);
					this.SendPropertyChanging();
					this._roast = value;
					this.SendPropertyChanged("roast");
					this.OnroastChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_altitude_max", DbType="Int NOT NULL")]
		public int altitude_max
		{
			get
			{
				return this._altitude_max;
			}
			set
			{
				if ((this._altitude_max != value))
				{
					this.Onaltitude_maxChanging(value);
					this.SendPropertyChanging();
					this._altitude_max = value;
					this.SendPropertyChanged("altitude_max");
					this.Onaltitude_maxChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_altitude_min", DbType="Int NOT NULL")]
		public int altitude_min
		{
			get
			{
				return this._altitude_min;
			}
			set
			{
				if ((this._altitude_min != value))
				{
					this.Onaltitude_minChanging(value);
					this.SendPropertyChanging();
					this._altitude_min = value;
					this.SendPropertyChanged("altitude_min");
					this.Onaltitude_minChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_at", DbType="DateTime NOT NULL")]
		public System.DateTime created_at
		{
			get
			{
				return this._created_at;
			}
			set
			{
				if ((this._created_at != value))
				{
					this.Oncreated_atChanging(value);
					this.SendPropertyChanging();
					this._created_at = value;
					this.SendPropertyChanged("created_at");
					this.Oncreated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updated_at", DbType="DateTime NOT NULL")]
		public System.DateTime updated_at
		{
			get
			{
				return this._updated_at;
			}
			set
			{
				if ((this._updated_at != value))
				{
					this.Onupdated_atChanging(value);
					this.SendPropertyChanging();
					this._updated_at = value;
					this.SendPropertyChanged("updated_at");
					this.Onupdated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isDeleted", DbType="TinyInt NOT NULL")]
		public byte isDeleted
		{
			get
			{
				return this._isDeleted;
			}
			set
			{
				if ((this._isDeleted != value))
				{
					this.OnisDeletedChanging(value);
					this.SendPropertyChanging();
					this._isDeleted = value;
					this.SendPropertyChanged("isDeleted");
					this.OnisDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bean_type", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string bean_type
		{
			get
			{
				return this._bean_type;
			}
			set
			{
				if ((this._bean_type != value))
				{
					this.Onbean_typeChanging(value);
					this.SendPropertyChanging();
					this._bean_type = value;
					this.SendPropertyChanged("bean_type");
					this.Onbean_typeChanged();
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
}
#pragma warning restore 1591
