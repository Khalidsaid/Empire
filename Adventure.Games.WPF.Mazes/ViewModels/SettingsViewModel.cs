using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Adventure.Games.WPF.Mazes.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {

        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Implement INotifyPopertyChanged

        private int width;
        private int height;

        public int Width
        {
            get { return this.width; }
            set
            {
                SetProperty(ref this.width, value);
            }
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                SetProperty(ref this.height, value);
            }
        }

        public SettingsViewModel() : this(0, 0) { }

        public SettingsViewModel(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
