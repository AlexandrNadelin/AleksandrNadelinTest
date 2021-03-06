﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Staff
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Staff")]
	public partial class LinqToSqlStaffdbmlDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertDepartments(Departments instance);
    partial void UpdateDepartments(Departments instance);
    partial void DeleteDepartments(Departments instance);
    partial void InsertWorkers(Workers instance);
    partial void UpdateWorkers(Workers instance);
    partial void DeleteWorkers(Workers instance);
    #endregion
		
		public LinqToSqlStaffdbmlDataContext() : 
				base(global::Staff.Properties.Settings.Default.StaffConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlStaffdbmlDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlStaffdbmlDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlStaffdbmlDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlStaffdbmlDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Departments> Departments
		{
			get
			{
				return this.GetTable<Departments>();
			}
		}
		
		public System.Data.Linq.Table<Workers> Workers
		{
			get
			{
				return this.GetTable<Workers>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Departments")]
	public partial class Departments : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Department;
		
		private int _ParentId_;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnDepartmentChanging(string value);
    partial void OnDepartmentChanged();
    partial void OnParentId_Changing(int value);
    partial void OnParentId_Changed();
    #endregion
		
		public Departments()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Department", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Department
		{
			get
			{
				return this._Department;
			}
			set
			{
				if ((this._Department != value))
				{
					this.OnDepartmentChanging(value);
					this.SendPropertyChanging();
					this._Department = value;
					this.SendPropertyChanged("Department");
					this.OnDepartmentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[ParentId ]", Storage="_ParentId_", DbType="Int NOT NULL")]
		public int ParentId_
		{
			get
			{
				return this._ParentId_;
			}
			set
			{
				if ((this._ParentId_ != value))
				{
					this.OnParentId_Changing(value);
					this.SendPropertyChanging();
					this._ParentId_ = value;
					this.SendPropertyChanged("ParentId_");
					this.OnParentId_Changed();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Workers")]
	public partial class Workers : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _individualTaxNumber;
		
		private string _fullName;
		
		private string _positionWorker;
		
		private string _phoneNumber;
		
		private string _email;
		
		private string _department;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnindividualTaxNumberChanging(string value);
    partial void OnindividualTaxNumberChanged();
    partial void OnfullNameChanging(string value);
    partial void OnfullNameChanged();
    partial void OnpositionWorkerChanging(string value);
    partial void OnpositionWorkerChanged();
    partial void OnphoneNumberChanging(string value);
    partial void OnphoneNumberChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OndepartmentChanging(string value);
    partial void OndepartmentChanged();
    #endregion
		
		public Workers()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_individualTaxNumber", DbType="NVarChar(12) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string individualTaxNumber
		{
			get
			{
				return this._individualTaxNumber;
			}
			set
			{
				if ((this._individualTaxNumber != value))
				{
					this.OnindividualTaxNumberChanging(value);
					this.SendPropertyChanging();
					this._individualTaxNumber = value;
					this.SendPropertyChanged("individualTaxNumber");
					this.OnindividualTaxNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fullName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string fullName
		{
			get
			{
				return this._fullName;
			}
			set
			{
				if ((this._fullName != value))
				{
					this.OnfullNameChanging(value);
					this.SendPropertyChanging();
					this._fullName = value;
					this.SendPropertyChanged("fullName");
					this.OnfullNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_positionWorker", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string positionWorker
		{
			get
			{
				return this._positionWorker;
			}
			set
			{
				if ((this._positionWorker != value))
				{
					this.OnpositionWorkerChanging(value);
					this.SendPropertyChanging();
					this._positionWorker = value;
					this.SendPropertyChanged("positionWorker");
					this.OnpositionWorkerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phoneNumber", DbType="NVarChar(11) NOT NULL", CanBeNull=false)]
		public string phoneNumber
		{
			get
			{
				return this._phoneNumber;
			}
			set
			{
				if ((this._phoneNumber != value))
				{
					this.OnphoneNumberChanging(value);
					this.SendPropertyChanging();
					this._phoneNumber = value;
					this.SendPropertyChanged("phoneNumber");
					this.OnphoneNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_department", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string department
		{
			get
			{
				return this._department;
			}
			set
			{
				if ((this._department != value))
				{
					this.OndepartmentChanging(value);
					this.SendPropertyChanging();
					this._department = value;
					this.SendPropertyChanged("department");
					this.OndepartmentChanged();
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
