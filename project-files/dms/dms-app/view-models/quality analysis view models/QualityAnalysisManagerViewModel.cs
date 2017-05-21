using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace dms.view_models.quality_analysis_view_models
{
    public class QualityAnalysisManagerViewModel : ViewmodelBase
    {

        public event Action<QualityAnalysisManagerViewModel> requestShowQualityAnalysis;
    }


    public class CreateTableQualityViewModel : ViewmodelBase
    {
        private ObservableCollection<DataGridColumn> _columnCollection = new ObservableCollection<DataGridColumn>();
        public ObservableCollection<DataGridColumn> ColumnCollection
        {
            get
            {
                return this._columnCollection;
            }
            set
            {
                _columnCollection = value;
                NotifyPropertyChanged("ColumnCollection");
            }
        }
        public CreateTableQualityViewModel()
        {
            ColumnCollection.Add(
                new DataGridTextColumn()
                {
                    Header = "Column1"
                });
        }

        public string[] Tasks { get; set; }
    }
}
