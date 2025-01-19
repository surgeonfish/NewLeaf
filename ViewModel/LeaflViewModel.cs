using NewLeaf.Model;

namespace NewLeaf.ViewModel
{
    public class LeaflViewModel : ViewModelBase
    {
        public LeafModel LeafModel
        {
            get { return LeafModelProperty;  }
            set
            {
                LeafModelProperty = value;
                OnPropertyChanged();
            }
        }
        private LeafModel LeafModelProperty;

        public LeaflViewModel(LeafModel leafModel)
        {
            LeafModel = leafModel;
        }
    }
}
