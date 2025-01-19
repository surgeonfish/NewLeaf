using NewLeaf.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NewLeaf.ViewModel
{
    public class LeaflViewModel : LeafModel, INotifyPropertyChanged
    {
        public override string Content
        {
            get { return base.Content; }
            set
            {
                base.Content = value;
                OnPropertyChanged();
            }
        }

        public override string Color
        {
            get { return base.Color; }
            set
            {
                base.Color = value;
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
