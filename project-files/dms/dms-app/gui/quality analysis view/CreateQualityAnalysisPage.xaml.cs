using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using dms.view_models.quality_analysis_view_models;

namespace dms.gui.quality_analysis_view
{
    /// <summary>
    /// Логика взаимодействия для CreateQualityAnalysisPage.xaml
    /// </summary>
    public partial class CreateQualityAnalysisPage : UserControl
    {
        public event Action<string, UserControl> OnShowPage;

        public CreateQualityAnalysisPage(QualityAnalysisManagerViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            //vm.requestShowQualityAnalysis += (p) => { var t = new CreateQualityAnalysisPage(p); OnShowPage?.Invoke("Качество обучения", t); };
        }
    }
}
