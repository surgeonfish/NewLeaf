﻿using System.ComponentModel;

namespace NewLeaf
{
    public class DatabaseEntry : INotifyPropertyChanged
    {
        public int LeafId
        {
            get { return LeafIdProperty;  }
            set
            {
                if (LeafIdProperty != value)
                {
                    LeafIdProperty = value;
                    OnPropertyChanged(nameof(LeafId));
                }
            }
        }
        private int LeafIdProperty;

        public string LeafContent
        {
            get { return LeafContentProperty; }
            set
            {
                if (LeafContentProperty != value)
                {
                    LeafContentProperty = value;
                    OnPropertyChanged(nameof(LeafContent));
                }
            }
        }
        private string LeafContentProperty;

        public string LeafColor
        {
            get { return LeafColorProperty; }
            set
            {
                if (LeafColorProperty != value)
                {
                    LeafColorProperty = value;
                    OnPropertyChanged(nameof(LeafColor));
                }
            }
        }
        private string LeafColorProperty;

        public string DateCreated
        {
            get { return DateCreatedProperty; }
            set
            {
                if (DateCreatedProperty != value)
                {
                    DateCreatedProperty = value;
                    OnPropertyChanged(nameof(DateCreated));
                }
            }
        }
        private string DateCreatedProperty;

        public string DateLastUpdated
        {
            get { return DateLastUpdatedProperty; }
            set
            {
                if (DateLastUpdatedProperty != value)
                {
                    DateLastUpdatedProperty = value;
                    OnPropertyChanged(nameof(DateLastUpdated));
                }
            }
        }
        private string DateLastUpdatedProperty;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
