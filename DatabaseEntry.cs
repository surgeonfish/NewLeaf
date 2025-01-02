using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLeaf
{
    public class DatabaseEntry : INotifyPropertyChanged
    {
        public int Id
        {
            get { return IdProperty;  }
            set
            {
                if (IdProperty != value)
                {
                    IdProperty = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        private int IdProperty;

        public string Date
        {
            get { return DateProperty; }
            set
            {
                if (DateProperty != value)
                {
                    DateProperty = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }
        private string DateProperty;

        public string Content
        {
            get { return ContentProperty; }
            set
            {
                if (ContentProperty != value)
                {
                    ContentProperty = value;
                    OnPropertyChanged(nameof(Content));
                }
            }
        }
        private string ContentProperty;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
