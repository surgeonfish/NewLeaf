﻿using NewLeaf.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace NewLeaf.ViewModel
{
    public partial class SettingsViewModel : SettingsModel, INotifyPropertyChanged
    {
        public override string Theme
        {
            get { return base.Theme; }
            set
            {
                base.Theme = value;
                ((App)Application.Current).OnSwitchTheme(value);
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
