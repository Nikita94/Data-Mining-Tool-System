using dms.models;
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
        public QualityAnalysisManagerViewModel()
        {
            Tasks = new CheckableObservableCollection<string>();
            foreach (string task in getTasks())
            {

                Tasks.Add(task);
            }
        }

        private CheckableObservableCollection<string> _Tasks;

        private CheckableObservableCollection<string> _Selections;

        public CheckableObservableCollection<string> Tasks
        {
            get { return _Tasks; }
            set
            {
                _Tasks = value;
                NotifyPropertyChanged("Tasks");
            }
        }


        public CheckableObservableCollection<string> Selections
        {
            get
            {
                foreach (CheckWrapper<string> task in Tasks)
                {
                      if (task.IsChecked)
                        _Selections.Add("lol");
                }
                return _Selections;
            }
            set
            {
                _Selections = value;
                NotifyPropertyChanged("Selections");
            }
        }

        public void refresh()
        {
            Selections = Selections;
        }

        private string[] getTasks()
        {
            List<Entity> tasks = dms.models.Task.all(typeof(dms.models.Task));
            List<string> listNameTasks = new List<string>();
            foreach (dms.models.Task task in tasks)
            {
                listNameTasks.Add(task.Name);
            }
            return listNameTasks.ToArray();
        }
    }


    public class CreateTableQualityViewModel : ViewmodelBase
    {

    }

    public class GenerateDataForAnalysis : ViewmodelBase
    {
        
    }
}
