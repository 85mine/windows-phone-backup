using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;


namespace STOP_Music.Model
{
    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name = "Timers.sdf")]
    public partial class TimersContext : System.Data.Linq.DataContext
    {
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

        #region Extensibility Method Definitions

        partial void OnCreated();
        partial void InsertTimer(Timer instance);
        partial void UpdateTimer(Timer instance);
        partial void DeleteTimer(Timer instance);

        #endregion

        public TimersContext(string connection) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public TimersContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public System.Data.Linq.Table<Timer> Timer
        {
            get { return this.GetTable<Timer>(); }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute()]
    public partial class Timer : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ID;

        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(string value);
        partial void OnIDChanged();

        #endregion

        public Timer()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", DbType = "NVarChar(100) NOT NULL",
            CanBeNull = false, IsPrimaryKey = true)]
        public string ID
        {
            get { return this._ID; }
            set
            {
                if ((this._ID != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
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
#pragma warning restore 1591
}