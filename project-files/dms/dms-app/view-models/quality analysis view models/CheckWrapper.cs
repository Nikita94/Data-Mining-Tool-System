using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dms.view_models.quality_analysis_view_models
{
    public class CheckWrapper<T> : INotifyPropertyChanged
    {
        private readonly CheckableObservableCollection<T> _parent;
        
        public CheckWrapper(CheckableObservableCollection<T> parent)
        {
            _parent = parent;
        }

        private T _value;

        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                CheckChanged();
                OnPropertyChanged("IsChecked");
                QualityAnalysisManagerViewModel vm = new QualityAnalysisManagerViewModel();
                vm.refresh();
            }
        }

        private void CheckChanged()
        {
            
            _parent.Refresh();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler pceh = PropertyChanged;
            if (pceh != null)
            {
                pceh(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
